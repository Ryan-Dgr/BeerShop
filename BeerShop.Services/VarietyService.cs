using BeerShop.Domains.EntitiesDB;
using BeerShop.Repositories;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Services
{
    public class VarietyService : IService<Variety>
    {
        private readonly IDAO<Variety> _varietyDAO;
        public VarietyService(IDAO<Variety> varietyDAO)
        {
            _varietyDAO = varietyDAO;
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
            return await _varietyDAO.GetAllAsync();
        }

        public Task UpdateAsync(Variety entity)
        {
            throw new NotImplementedException();
        }
    }
}
