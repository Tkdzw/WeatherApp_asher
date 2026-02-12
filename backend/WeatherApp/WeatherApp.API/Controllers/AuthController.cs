using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
