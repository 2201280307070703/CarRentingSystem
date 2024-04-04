namespace CarRentingSystem.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Services.Data.Contracts;
    using CarRentingSystem.Web.ViewModels.Car;
    using CarRentingSystem.Web.ViewModels.Category;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;
        private readonly ICategoryService categoryService;

        public CarController(ICarService carService, IDealerService dealerService, ICategoryService categoryService)
        {
            this.carService = carService;
            this.dealerService = dealerService;
            this.categoryService = categoryService;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public Task<IActionResult> IAll()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> MyOwned()
        {
            string userId = GetUserId();
            bool isUserDealer = await dealerService.DealerExistsByUserIdAsync(userId);

            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You are not dealer!";

                return RedirectToAction("Become", "Dealer");
            }
            try
            {
                ICollection<CarCardViewModel> model = await carService.GetAllCarsByUserIdAsync(userId);

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
            string userId = GetUserId();
            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(userId);

            if (!isUserDealer)
            {
                this.TempData[ErrorMessage] = "You must be a dealer in order to add car ad!";

                return RedirectToAction("Become", "Dealer");
            }

            try
            {
                ICollection<CategoryViewModel> categories = await this.categoryService.GetAllCategoriesAsync();

                AddCarFormModel model = new AddCarFormModel();
                model.Categories = categories;

                return View(model);
            }
            catch (Exception)
            {
                return GeneralExceptionHandler();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarFormModel formModel)
        {
            string userId = GetUserId();
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

        private RedirectToActionResult GeneralExceptionHandler()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again later.";

            return RedirectToAction("Index", "Home");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
