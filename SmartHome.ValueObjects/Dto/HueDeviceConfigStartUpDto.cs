using SmartHome.ValueObjects.Enums;

namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceConfigStartUpDto
    {
        /// <summary>
        /// True if the startup settings are committed to the device, false if not.
        /// If this attribute is not present ( before 1.28)
        /// the bridge does not ensure the settings are committed.
        /// </summary>
        public bool Configured { get; set; }

        public EHueDeviceStartUpMode Mode { get; set; }
    }
}