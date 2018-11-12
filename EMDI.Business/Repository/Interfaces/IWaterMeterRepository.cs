using EMDI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IWaterMeterRepository
    {
        Task<List<WaterMeter>> GetWaterMeterAsync();

        Task<WaterMeter> GetWaterMeterAsync(int id);

        Task<int> AddWaterMeterAsync(WaterMeter item);

        Task<int> UpdateWaterMeterAsync(WaterMeter dbItem, WaterMeter item);

        Task<int> DeleteWaterMeterAsync(int id);

    }
}
