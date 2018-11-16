using System.ComponentModel.DataAnnotations;

namespace EMDI.API.Models
{
    public partial class BasicDeviceModel : BaseModel<int>
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Maximum length for this field is {1}")]
        public string SerialNumber { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum length for this field is {1}")]
        public string FirmwareVersion { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum length for this field is {1}")]
        public string State { get; set; }
    }
}

