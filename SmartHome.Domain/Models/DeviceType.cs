using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Device = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProtocolId { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
