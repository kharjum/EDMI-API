
namespace EMDI.Business.Entities
{
    public partial class Gateways: BasicDevice
    {
        public string Ip { get; set; }

        public int? Port { get; set; }
    }
}
