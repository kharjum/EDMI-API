using EMDI.Business.Models;


namespace EMDI.Models
{
    public partial class Gateways: BasicDevice
    {
        public int? Ip { get; set; }

        public int? Port { get; set; }
    }
}
