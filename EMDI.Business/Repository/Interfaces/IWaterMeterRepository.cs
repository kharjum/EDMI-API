using EMDI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IWaterMeterRepository
    {
        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        Task<List<WaterMeter>> GetWaterMeterAsync();

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WaterMeter> GetWaterMeterAsync(int id);

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> AddWaterMeterAsync(WaterMeter item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> UpdateWaterMeterAsync(WaterMeter dbItem, WaterMeter item);

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteWaterMeterAsync(int id);

    }
}
