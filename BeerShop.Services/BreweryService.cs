using BeerShop.Domains.EntitiesDB;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Services
{
    public class BreweryService : IService<Brewery>
    {
        private readonly IDAO<Brewery> _breweryDAO;
        public BreweryService(IDAO<Brewery> breweryDAO)
        {
            _breweryDAO = breweryDAO;
        }
        public Task AddAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task<Brewery?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            return await _breweryDAO.GetAllAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}
