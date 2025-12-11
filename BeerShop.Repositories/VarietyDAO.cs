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
    public class VarietyDAO : IDAO<Variety>
    {
        private readonly BeerDbContext _context;
        public VarietyDAO(BeerDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task<Variety?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Variety>?> GetAllAsync()
        {
            return await _context.Varieties.AsNoTracking().ToListAsync();
        }

        public Task UpdateAsync(Variety entity)
        {
            throw new NotImplementedException();
        }
    }
}
