using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class ExternalDeviceInformation
    {
        public ExternalDeviceInformation()
        {
            Device = new HashSet<Device>();
        }

        public Guid Id { get; set; }
        public string SystemInternalId { get; set; }
        public int StartUpMode { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
