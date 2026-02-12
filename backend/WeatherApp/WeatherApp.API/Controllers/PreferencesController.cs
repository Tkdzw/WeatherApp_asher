using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class PreferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
