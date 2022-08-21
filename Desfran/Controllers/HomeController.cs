using Desfran.Models.Helpers;
using Desfran.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desfran.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherInterface _weather;
        public HomeController(IWeatherInterface weather)
        {
            _weather = weather;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var weatherNextDays = await _weather.GetNextDays();

            return View(weatherNextDays);
        }
    }
}