using AutoMapper;
using BeerShop.Domains.EntitiesDB;
using BeerShop.Services;
using BeerShop.Services.Interfaces;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class BeerSortingController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IService<Brewery> _breweryService;
        private readonly IMapper _mapper;
        public BeerSortingController(IBeerService beerService, IService<Brewery> breweryService, IMapper mapper)
        {
            _mapper = mapper;
            _beerService = beerService;
            _breweryService = breweryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var beers = await _beerService.GetAllAsync();
                List<BeerVM>? beerVMs = null;

                if (beers != null)
                {
                    beerVMs = _mapper.Map<List<BeerVM>>(beers);
                }
                return View(beerVMs);
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bedrijven: " + ex.Message);
            }
            return View();
        }
        public async Task<IActionResult> Breweries()
        {
            try
            {
                var context = await _breweryService.GetAllAsync();
                List<BreweryVM>? BreweryVMs = null;

                if (context != null)
                {
                    BreweryVMs = _mapper.Map<List<BreweryVM>>(context);
                }
                return View(BreweryVMs);
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bedrijven: " + ex.Message);
            }
            return View();
        }
    }
}
