using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class Location
    {
        public Location()
        {
            Device = new HashSet<Device>();
            DeviceGroup = new HashSet<DeviceGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<DeviceGroup> DeviceGroup { get; set; }
    }
}
