using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
