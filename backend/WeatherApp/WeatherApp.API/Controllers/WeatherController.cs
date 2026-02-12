using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
