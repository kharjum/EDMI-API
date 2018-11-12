using EMDI.Business.Models;


namespace EMDI.Models
{
    public partial class Gateways: BasicDevice
    {
        public string Ip { get; set; }

        public int? Port { get; set; }
    }
}
