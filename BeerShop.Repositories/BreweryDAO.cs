using BeerShop.Domains.DataDB;
using BeerShop.Domains.EntitiesDB;
using BeerShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Repositories
{
    public class BreweryDAO : IDAO<Brewery>
    {
        private readonly BeerDbContext _context;

        public BreweryDAO(BeerDbContext context)
        {
            _context = context;
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
            return await _context.Breweries.AsNoTracking().ToListAsync();
        }


        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}
