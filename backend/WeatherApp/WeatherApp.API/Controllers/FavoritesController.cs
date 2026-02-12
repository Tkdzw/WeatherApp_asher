using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers
{
    public class FavouritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
