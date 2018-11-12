using EMDI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IElectricMeterRepository
    {
        Task<List<ElectricMeter>> GetElectricMeterAsync();

        Task<ElectricMeter> GetElectricMeterAsync(int id);

        Task<int> AddElectricMeterAsync(ElectricMeter item);

        Task<int> UpdateElectricMeterAsync(ElectricMeter dbItem, ElectricMeter item);

        Task<int> DeleteElectricMeterAsync(int id);

    }
}
