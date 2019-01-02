using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DeviceDevicePins
    {
        public Guid Id { get; set; }
        public Guid IoTdeviceId { get; set; }
        public Guid IoTdevicePinsId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual Device IoTdevice { get; set; }
        public virtual DevicePins IoTdevicePins { get; set; }
    }
}
