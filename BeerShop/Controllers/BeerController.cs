using AutoMapper;
using BeerShop.Domains.EntitiesDB;
using BeerShop.Services;
using BeerShop.Services.Interfaces;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerShop.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;
        private IService<Brewery> _breweryService;
        private IService<Variety> _varietyService;

        public BeerController(IBeerService beerService, IMapper mapper, IService<Brewery> breweryService, IService<Variety> varietyService)
        {
            _mapper = mapper;
            _beerService = beerService;
            _breweryService = breweryService;
            _varietyService = varietyService;
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

        public IActionResult GetBeerByAlcohol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByAlcohol(BeerSearchByAlcoholVM model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var beers = await _beerService.GetBeersByAlcohol(model.AlcoholPercentage!.Value);
                model.Beers = _mapper.Map<List<BeerVM>>(beers);
                return View(model);
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bieren: " + ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> GetBeersByBreweries()
        {
            try
            {
                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                    );
                return View();
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                //ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de brouwerijen: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweries(int? brouwerID)
        {
            if (brouwerID == null)
            {
                return NotFound();
            }
            try
            {
                var bierlijst = await _beerService.GetBeersByBreweries(Convert.ToInt16(brouwerID));

                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam",
                    brouwerID
                    );

                List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(bierlijst);
                return View(listVM);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> GetBeersByBreweriesVM()
        {
            try
            {
                BreweryBeersVM breweryBeersVM = new BreweryBeersVM();


                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                    );
                return View(breweryBeersVM);
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                //ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de brouwerijen: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweriesVM(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }
            try
            {
                var bierlijst = await _beerService.GetBeersByBreweries(Convert.ToInt16(entity.BreweryNumber));

                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam",
                    entity.BreweryNumber
                    );
                entity.Beers = _mapper.Map<List<BeerVM>>(bierlijst);
                entity.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam",
                    entity.BreweryNumber
                    );
                return View(entity);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> GetBeersByBreweriesAjax()
        {
            try
            {
                BreweryBeersVM breweryBeersVM = new BreweryBeersVM();


                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                    );
                return View(breweryBeersVM);
            }
            catch (Exception ex)
            {
                // Log the error (consider a logging framework)
                //ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de brouwerijen: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweriesAjax(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }
            try
            {
                var beerLst = await _beerService.GetBeersByBreweries
               (Convert.ToInt16(entity.BreweryNumber));
                List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(beerLst);

                // er moet geen lijst met brouwers worden meegegeven

                return PartialView("_SearchBierenPartial", listVM);

            }
            catch
            {

            }
            return View(entity);

        }

        public async Task<IActionResult> Create()
        {

            try
            {
                var beerCreate = new BeerBaseCRUD()
                {
                    Breweries = new SelectList(await _breweryService.GetAllAsync(),
                    "Brouwernr", "Naam"),
                    Varieties = new SelectList(await _varietyService.GetAllAsync(),
                    "Soortnr", "Soortnaam")
                };
                return View(beerCreate);
            }
            catch (Exception ex)
            {
                //iets
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerBaseCRUD model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var beerEntity = _mapper.Map<Beer>(model);
                    await _beerService.AddAsync(beerEntity);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //iets
                throw;
            }
            return View(model);
        }
    }
}
