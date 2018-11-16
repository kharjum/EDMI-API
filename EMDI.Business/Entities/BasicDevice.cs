using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMDI.Business.Entities
{
    public partial class BasicDevice : BaseEntity<int>
    {
        
        public string SerialNumber { get; set; }

        public string FirmwareVersion { get; set; }

        public string State { get; set; }
    }
}

