using EMDI.Models;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMDI.Repository
{
    public class ElectricMeterRepository : IElectricMeterRepository
    {
        private readonly EDMIDBContext _context;

        public ElectricMeterRepository(EDMIDBContext context)
        {
            _context = context;
        }

        public async Task<List<ElectricMeter>> GetElectricMeterAsync()
        {
            return await _context.ElectricMeter.ToListAsync();
        }

        public async Task<ElectricMeter> GetElectricMeterAsync(int id)
        {
            return await _context.ElectricMeter.FindAsync(id);
        }

        public async Task<int> AddElectricMeterAsync(ElectricMeter item)
        {
            int rowsAffected = 0;

            _context.ElectricMeter.Add(item);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> UpdateElectricMeterAsync(ElectricMeter dbItem, ElectricMeter item)
        {
            int rowsAffected = 0;

            // detach
            _context.Entry(dbItem).State = EntityState.Detached;

            // set Modified flag in your entry
            _context.Entry(item).State = EntityState.Modified;

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteElectricMeterAsync(int id)
        {
            int rowsAffected = 0;

            var item = await _context.ElectricMeter.FindAsync(id);

            _context.ElectricMeter.Remove(item);

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

    }
}

