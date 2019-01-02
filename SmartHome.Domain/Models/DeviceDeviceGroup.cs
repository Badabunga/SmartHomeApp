using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DeviceDeviceGroup
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid DeviceGroupId { get; set; }

        public virtual Device Device { get; set; }
        public virtual DeviceGroup DeviceGroup { get; set; }
    }
}
