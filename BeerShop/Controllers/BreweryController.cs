using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class BreweryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
