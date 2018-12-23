using SmartHome.ValueObjects.Enums;
using System;

namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceUpdateInfoDto
    {
        public EHueDeviceUpdateState State { get; set; }

        public DateTime LastInstall { get; set; }
    }
}