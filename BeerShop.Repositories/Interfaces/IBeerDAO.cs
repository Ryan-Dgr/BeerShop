using BeerShop.Domains.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Repositories.Interfaces
{
    public interface IBeerDAO : IDAO<Beer>
    {
        Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percent);
        Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerID);
    }
}
