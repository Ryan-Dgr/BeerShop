using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerShop.Domains.EntitiesDB;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;

namespace BeerShop.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerDAO _beerDAO;

        public BeerService(IBeerDAO beerDAO)
        {
            _beerDAO = beerDAO;
        }

        public async Task AddAsync(Beer entity)
        {
            await _beerDAO.AddAsync(entity);
        }

        public async Task DeleteAsync(Beer entity)
        {
            await _beerDAO.DeleteAsync(entity);
        }

        public async Task<Beer?> FindByIdAsync(int Id)
        {
            return await _beerDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        public Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percent)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerID)
        {
            return await _beerDAO.GetBeersByBreweries(brouwerID);
        }

        public async Task UpdateAsync(Beer entity)
        {
           await _beerDAO.UpdateAsync(entity);
        }
    }
}
