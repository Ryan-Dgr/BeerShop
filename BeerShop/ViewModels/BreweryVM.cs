using BeerShop.Domains.EntitiesDB;

namespace BeerShop.ViewModels
{
    public class BreweryVM
    {
        public string Naam { get; set; } = null!;

        public string Adres { get; set; } = null!;

        public string Postcode { get; set; } = null!;

        public string Gemeente { get; set; } = null!;

        public decimal? Omzet { get; set; }

        public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
