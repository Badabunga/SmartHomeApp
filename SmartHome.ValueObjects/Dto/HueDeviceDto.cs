using SmartHome.ValueObjects.Enums;
using System;

namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceDto
    {
        public HueDeviceStateDto State { get; set; }

        public HueDeviceUpdateInfoDto SWUpdate { get; set; }

        public HueDeviceCapabilitiesDto Capabilities { get; set; }

        public HueDeviceConfigDto Config { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string ModelId { get; set; }

        public string ProductId { get; set; }

        public string UniqueId { get; set; }

        public string ManufacturerName { get; set; }

        public string ProductName { get; set; }

        public string SwVersion { get; set; }

        public string SwConfigId { get; set; }

    }
}
