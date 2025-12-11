using BeerShop.Domains.EntitiesDB;

namespace BeerShop.ViewModels
{
    public class BeerVM
    {
        public int Biernr { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Brouwernaam { get; set; } = string.Empty;
        public string Soortnaam { get; set; } = string.Empty;
        public decimal? Alcohol { get; set; }
        public string? Image { get; set; }
    }
}
