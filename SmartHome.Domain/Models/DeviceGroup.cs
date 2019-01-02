using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DeviceGroup
    {
        public DeviceGroup()
        {
            DeviceDeviceGroup = new HashSet<DeviceDeviceGroup>();
        }

        public Guid Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string SystemInteralId { get; set; }
        public int ProtocolId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<DeviceDeviceGroup> DeviceDeviceGroup { get; set; }
    }
}
