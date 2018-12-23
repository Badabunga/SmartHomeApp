namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceCapabilitiesDto
    {
        public HueDeviceCapabilitiesStreamingDto Streaming { get; set;}

        public HueDeviceCapabilitiesControlDto Control { get; set; }


        /// <summary>
        /// Is Hue Certified
        /// </summary>
        public bool Certified { get; set; }

      
    }
}