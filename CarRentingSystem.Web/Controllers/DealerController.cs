namespace CarRentingSystem.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.ViewModels.Dealer;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class DealerController : Controller
    {
        private readonly IDealerService dealerService;

        public DealerController(IDealerService dealerService)
        {
            this.dealerService = dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool dealerExists = await dealerService.DealerExistsByUserIdAsync(userId);

            if(dealerExists)
            {
                TempData[ErrorMessage] = "You are already dealer!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerFormModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool dealerExists = await dealerService.DealerExistsByUserIdAsync(userId);

            if (dealerExists)
            {
                TempData[ErrorMessage] = "You are already dealer!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.dealerService.DealerExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "This phone number is already taken!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.dealerService.Create(userId, model);

                return RedirectToAction("Mine", "Car");
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
