namespace CarRentingSystem.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.ViewModels.Car;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;

        public CarController(ICarService carService, IDealerService dealerService)
        {
            this.carService = carService;
            this.dealerService = dealerService;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public Task<IActionResult> IAll()
        //{
        //    return View();
        //}

        public async Task<IActionResult> MyOwned()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

        private RedirectToActionResult GeneralExceptionHandler()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again later.";

            return RedirectToAction("Index", "Home");
        }
    }
}
