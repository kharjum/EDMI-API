using EMDI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IGatewaysRepository
    {
        Task<List<Gateways>> GetGatewaysAsync();

        Task<Gateways> GetGatewaysAsync(int id);

        Task<int> AddGatewaysAsync(Gateways item);

        Task<int> UpdateGatewaysAsync(Gateways dbItem, Gateways item);

        Task<int> DeleteGatewaysAsync(int id);

    }
}
