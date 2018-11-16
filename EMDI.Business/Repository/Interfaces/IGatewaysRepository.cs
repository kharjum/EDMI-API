using EMDI.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IGatewaysRepository
    {
        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        Task<List<Gateways>> GetGatewaysAsync();

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Gateways> GetGatewaysAsync(int id);

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> AddGatewaysAsync(Gateways item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> UpdateGatewaysAsync(Gateways dbItem, Gateways item);

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteGatewaysAsync(int id);

    }
}
