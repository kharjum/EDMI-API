using EMDI.Models;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMDI.Repository
{
    public class GatewaysRepository : IGatewaysRepository
    {
        private readonly EDMIDBContext _context;

        public GatewaysRepository(EDMIDBContext context)
        {
            _context = context;
        }

        public async Task<List<Gateways>> GetGatewaysAsync()
        {
            return await _context.Gateways.ToListAsync();
        }

        public async Task<Gateways> GetGatewaysAsync(int id)
        {
            return await _context.Gateways.FindAsync(id);
        }

        public async Task<int> AddGatewaysAsync(Gateways item)
        {
            int rowsAffected = 0;

            _context.Gateways.Add(item);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> UpdateGatewaysAsync(Gateways dbItem, Gateways item)
        {
            int rowsAffected = 0;

            // detach
            _context.Entry(dbItem).State = EntityState.Detached;

            // set Modified flag in your entry
            _context.Entry(item).State = EntityState.Modified;

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteGatewaysAsync(int id)
        {
            int rowsAffected = 0;

            var item = await _context.Gateways.FindAsync(id);

            _context.Gateways.Remove(item);

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}

