namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceCapabilitiesStreamingDto
    {
        /// <summary>
        /// Can be used for enterainment streaming as renderer
        /// </summary>
        public bool Renderer { get; set; }


        /// <summary>
        /// Can be used for streaming as proxy node
        /// </summary>
        public bool Proxy { get; set; }
    }
}