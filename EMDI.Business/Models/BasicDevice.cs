using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMDI.Business.Models
{
    public partial class BasicDevice
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Maximum length for this field is {1}")]
        public string SerialNumber { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum length for this field is {1}")]
        public string FirmwareVersion { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum length for this field is {1}")]
        public string State { get; set; }
    }
}

