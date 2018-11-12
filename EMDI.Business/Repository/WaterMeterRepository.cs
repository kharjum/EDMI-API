using EMDI.Models;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMDI.Repository
{
    public class WaterMeterRepository : IWaterMeterRepository
    {
        private readonly EDMIDBContext _context;

        public WaterMeterRepository(EDMIDBContext context)
        {
            _context = context;
        }

        public async Task<List<WaterMeter>> GetWaterMeterAsync()
        {
            return await _context.WaterMeter.ToListAsync();
        }

        public async Task<WaterMeter> GetWaterMeterAsync(int id)
        {
            return await _context.WaterMeter.FindAsync(id);
        }

        public async Task<int> AddWaterMeterAsync(WaterMeter item)
        {
            int rowsAffected = 0;

            _context.WaterMeter.Add(item);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> UpdateWaterMeterAsync(WaterMeter dbItem, WaterMeter item)
        {
            int rowsAffected = 0;

            // detach
            _context.Entry(dbItem).State = EntityState.Detached;

            // set Modified flag in your entry
            _context.Entry(item).State = EntityState.Modified;

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteWaterMeterAsync(int id)
        {
            int rowsAffected = 0;

            var item = await _context.WaterMeter.FindAsync(id);

            _context.WaterMeter.Remove(item);

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

    }
}

