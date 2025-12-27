using System.ComponentModel.DataAnnotations;

namespace BeerShop.ViewModels
{
    public class BeerEditVM: BeerBaseCRUD
    {
        [Required]
        public int Biernr { get; set; }
    }
}
