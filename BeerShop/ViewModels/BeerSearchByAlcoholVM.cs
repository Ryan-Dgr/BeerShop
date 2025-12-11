using System.ComponentModel.DataAnnotations;

namespace BeerShop.ViewModels
{
    public class BeerSearchByAlcoholVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geef een alcoholpercentage in.")]
        [Range(0, 100, ErrorMessage = "Geef een percentage tussen 0 en 100 op.")]
        public int? AlcoholPercentage { get; set; }
        public List<BeerVM>? Beers { get; set; }
    }
}
