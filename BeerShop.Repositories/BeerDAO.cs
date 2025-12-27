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
    public class BeerDAO : IBeerDAO
    {
        private readonly BeerDbContext _context;

        public BeerDAO(BeerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Beer entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Beer entity)
        {

            _context.Beers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Beer?> FindByIdAsync(int Id)
        {
            return await _context.Beers
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .FirstOrDefaultAsync(b => b.Biernr == Id);
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _context.Beers.AsNoTracking().Include(a => a.BrouwernrNavigation).Include(b => b.SoortnrNavigation).ToListAsync();
        }

   
        public async Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percent)
        {
            try
            {
                return await _context.Beers
                    .Where(b => b.Alcohol == percent)
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerID)
        {
            try
            {
                return await _context.Beers
                    .Where(b => b.Brouwernr == brouwerID)
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Beer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
