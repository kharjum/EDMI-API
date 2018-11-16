using EMDI.Business.Repository;
using EMDI.Business.Entities;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMDI.Repository
{
    public class GatewaysRepository : RepositoryBase<Gateways>, IGatewaysRepository
    {
        /// <summary>
        /// Database Context
        /// </summary>
        private readonly EDMIDBContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repositoryContext"></param>
        public GatewaysRepository(EDMIDBContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Gateways>> GetGatewaysAsync()
        {
            return await GetAllAsync();
        }

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Gateways> GetGatewaysAsync(int id)
        {
            return await FindAsync(id);
        }

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> AddGatewaysAsync(Gateways item)
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
        public async Task<int> UpdateGatewaysAsync(Gateways dbItem, Gateways item)
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
        public async Task<int> DeleteGatewaysAsync(int id)
        {
            int rowsAffected = 0;

            rowsAffected = await DeleteAsync(id);

            return rowsAffected;
        }
    }
}

