using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DevicePins
    {
        public DevicePins()
        {
            DeviceDevicePins = new HashSet<DeviceDevicePins>();
        }

        public Guid Id { get; set; }
        public string PinNumber { get; set; }
        public int Iostate { get; set; }
        public Guid PeripherDevice { get; set; }

        public virtual ICollection<DeviceDevicePins> DeviceDevicePins { get; set; }
    }
}
