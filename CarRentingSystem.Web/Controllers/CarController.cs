namespace CarRentingSystem.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Services.Data.Contracts;
    using CarRentingSystem.Web.ViewModels.Car;
    using CarRentingSystem.Web.ViewModels.Category;
    using CarRentingSystem.Web.Infrastructure.Extensions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        public CarController(ICarService carService, IDealerService dealerService, ICategoryService categoryService, IUserService userService)
        {
            this.carService = carService;
            this.dealerService = dealerService;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            ICollection<CarCardViewModel> model = await this.carService.GetAllCarsAsync();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> DealerCars(string? dealerId)
        {
            string title = string.Empty;

            if (string.IsNullOrWhiteSpace(dealerId))
            {
                string userId = this.User.GetUserId()!;
                bool dealerExists = await this.dealerService.DealerExistsByUserIdAsync(userId);

                if (!dealerExists)
                {
                    this.TempData[ErrorMessage] = "You should be a dealer in order to have cars!";

                    return RedirectToAction("Become", "Dealer");
                }
                else
                {
                    dealerId = await this.dealerService.TakeDealerIdByUserId(userId);
                    title = "My Cars";
                }
            }
            else
            {
                bool dealerExists = await this.dealerService.DealerExistsByIdAsync(dealerId);
                if (!dealerExists)
                {
                    this.TempData[ErrorMessage] = "Dealer not found!";

                    return RedirectToAction("Index", "Home");
                }

                title = "Current Dealer Cars";
            }

            try
            {
                ICollection<CarCardViewModel> model = await this.carService.GetAllCarsByDealerIdAsync(dealerId);

                this.TempData["title"] = title;

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = this.User.GetUserId()!;
            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(userId);

            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You must be a dealer in order to add car ad!";

                return RedirectToAction("Become", "Dealer");
            }

            try
            {
                ICollection<CategoryViewModel> categories = await this.categoryService.GetAllCategoriesAsync();

                CarFormModel model = new CarFormModel();
                model.Categories = categories;

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel formModel)
        {
            string userId = this.User.GetUserId()!;
            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(userId);

            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You must be a dealer in order to add car ad!";

                return RedirectToAction("Become", "Dealer");
            }

            bool isCategoryValid = await this.categoryService.CategoryExistsByIdAsync(formModel.CategoryId);

            if (!isCategoryValid)
            {
                ModelState.AddModelError(nameof(formModel.CategoryId), "Selected category is not valid!");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return View(formModel);
            }

            try
            {
                string dealerId = await this.dealerService.TakeDealerIdByUserId(userId);
                string carId = await this.carService.AddCarAndReturnIdAsync(formModel, dealerId);

                this.TempData[SuccessMessage] = "Successfully added car!";
                return RedirectToAction("Details", "Car", new {id = carId});
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }
            try
            {
                CarDetailsViewModel model = await this.carService.GetCarDetailsByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetUserId()!);
            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You have to become a dealer in order to edit a car!";

                return RedirectToAction("Become", "Dealer");
            }

            bool isDealerOwner = await this.dealerService.DealerIsOwnerOfTheCarByUserIdAsync(this.User.GetUserId()!, id);
            if (!isDealerOwner)
            {
                this.TempData[ErrorMessage] = "You have to be owner in order to edit this car!";

                return RedirectToAction("DealerCars", "Car");
            }

            try
            {
                CarFormModel model = await this.carService.GetCarForEditByIdAsync(id);

                model.Categories = await this.categoryService.GetAllCategoriesAsync();

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return View(formModel);
            }
            bool carExists = await this.carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetUserId()!);
            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You have to become a dealer in order to edit a car!";

                return RedirectToAction("Become", "Dealer");
            }

            bool isDealerOwner = await this.dealerService.DealerIsOwnerOfTheCarByUserIdAsync(this.User.GetUserId()!, id);
            if (!isDealerOwner)
            {
                this.TempData[ErrorMessage] = "You have to be owner in order to edit this car!";

                return RedirectToAction("DealerCars", "Car");
            }

            try
            {
                await this.carService.EditCarByIdAsync(id, formModel);

                this.TempData[SuccessMessage] = "Successfully edited!";

                return RedirectToAction("Details", "Car", new {id});
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetUserId()!);
            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You have to become a dealer in order to edit a car!";

                return RedirectToAction("Become", "Dealer");
            }

            bool isDealerOwner = await this.dealerService.DealerIsOwnerOfTheCarByUserIdAsync(this.User.GetUserId()!, id);
            if (!isDealerOwner)
            {
                this.TempData[ErrorMessage] = "You have to be owner in order to edit this car!";

                return RedirectToAction("DealerCars", "Car");
            }

            try
            {
                DeleteCarViewModel model = await this.carService.GetCarForDeleteByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, DeleteCarViewModel deleteCarModel)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetUserId()!);
            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You have to become a dealer in order to edit a car!";

                return RedirectToAction("Become", "Dealer");
            }

            bool isDealerOwner = await this.dealerService.DealerIsOwnerOfTheCarByUserIdAsync(this.User.GetUserId()!, id);
            if (!isDealerOwner)
            {
                this.TempData[ErrorMessage] = "You have to be owner in order to edit this car!";

                return RedirectToAction("DealerCars", "Car");
            }

            try
            {
                await this.carService.DeleteCarByIdAsync(id);

                this.TempData[WarningMessage] = "Successfully deleted!";

                return RedirectToAction("DealerCars", "Car");
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rent(string carId)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(carId);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "This car do not exists!";

                return RedirectToAction("All", "Car");
            }

            bool carIsRented = await this.carService.CarIsRentedByIdAsync(carId);
            if (carIsRented)
            {
                this.TempData[ErrorMessage] = "This car is already rented! Please choose another car.";

                return RedirectToAction("All", "Car");
            }

            bool userHasRentedCar = await this.userService.UserHasRentedCarByIdAsync(this.User.GetUserId()!);
            if (userHasRentedCar)
            {
                this.TempData[ErrorMessage] = "You can rent only one car!";

                return RedirectToAction("MyRentedCar", "Cars");
            }

            try
            {
                await this.carService.RentACarByIdAsync(this.User.GetUserId()!, carId);


                this.TempData[SuccessMessage] = "Successfully rented!";


                return RedirectToAction("MyRentedCar", "Cars");
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        private RedirectToActionResult GeneralExceptionHandler()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again later.";

            return RedirectToAction("Index", "Home");
        }
    }
}
