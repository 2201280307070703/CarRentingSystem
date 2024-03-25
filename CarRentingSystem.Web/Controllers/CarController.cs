namespace CarRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CarController : Controller
    {

        //[AllowAnonymous]
        //[HttpGet]
        //public Task<IActionResult> IAll()
        //{
        //    return View();
        //}
    }
}
