using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
