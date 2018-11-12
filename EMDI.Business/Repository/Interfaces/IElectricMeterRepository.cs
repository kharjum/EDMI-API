using EMDI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IElectricMeterRepository
    {
        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        Task<List<ElectricMeter>> GetElectricMeterAsync();

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ElectricMeter> GetElectricMeterAsync(int id);

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> AddElectricMeterAsync(ElectricMeter item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> UpdateElectricMeterAsync(ElectricMeter dbItem, ElectricMeter item);

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteElectricMeterAsync(int id);

    }
}
