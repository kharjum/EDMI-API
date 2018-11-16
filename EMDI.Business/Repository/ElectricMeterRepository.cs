using EMDI.Business.Repository;
using EMDI.Business.Entities;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMDI.Repository
{
    public class ElectricMeterRepository : RepositoryBase<ElectricMeter>, IElectricMeterRepository
    {
        /// <summary>
        /// Database Context
        /// </summary>
        private readonly EDMIDBContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repositoryContext"></param>
        public ElectricMeterRepository(EDMIDBContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        public async Task<List<ElectricMeter>> GetElectricMeterAsync()
        {
            return await GetAllAsync();
        }

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ElectricMeter> GetElectricMeterAsync(int id)
        {
            return await FindAsync(id);
        }

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> AddElectricMeterAsync(ElectricMeter item)
        {
            int rowsAffected = 0;
            
            rowsAffected = await AddAsync(item);

            return rowsAffected;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> UpdateElectricMeterAsync(ElectricMeter dbItem, ElectricMeter item)
        {
            int rowsAffected = 0;

            rowsAffected = await UpdateAsync(dbItem, item);

            return rowsAffected;
        }

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteElectricMeterAsync(int id)
        {
            int rowsAffected = 0;
            
            rowsAffected = await DeleteAsync(id);

            return rowsAffected;
        }

    }
}

