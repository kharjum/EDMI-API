
namespace EMDI.API.Models
{ 
    public partial class GatewaysModel: BasicDeviceModel
    {
        public string Ip { get; set; }

        public int? Port { get; set; }
    }
}
