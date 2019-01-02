using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class Device
    {
        public Device()
        {
            DeviceDeviceGroup = new HashSet<DeviceDeviceGroup>();
            DeviceDevicePins = new HashSet<DeviceDevicePins>();
            DeviceMqttTopics = new HashSet<DeviceMqttTopics>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MacAddress { get; set; }
        public int LocationId { get; set; }
        public int DeviceTypeId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public Guid? InformationId { get; set; }

        public virtual DeviceType DeviceType { get; set; }
        public virtual ExternalDeviceInformation Information { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<DeviceDeviceGroup> DeviceDeviceGroup { get; set; }
        public virtual ICollection<DeviceDevicePins> DeviceDevicePins { get; set; }
        public virtual ICollection<DeviceMqttTopics> DeviceMqttTopics { get; set; }
    }
}
