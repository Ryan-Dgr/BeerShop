using BeerShop.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class GenericController : Controller
    {
        public IActionResult Index()
        {
            //DataStore countries = new DataStore();

            //countries.AddOrUpdate(0, "Belgium");
            //countries.AddOrUpdate(1, "US");
            //countries.AddOrUpdate(2, "France");

            DataStore<string> cities = new DataStore<string>();

            cities.AddOrUpdate(0, "Numbai");
            cities.AddOrUpdate(1, "Chicago");
            cities.AddOrUpdate(2, "London");

            DataStore<int> empIds = new DataStore<int>();
            empIds.AddOrUpdate(0, 50);
            empIds.AddOrUpdate(1, 65);
            empIds.AddOrUpdate(2, 89);

            return View();
        }
    }
}
