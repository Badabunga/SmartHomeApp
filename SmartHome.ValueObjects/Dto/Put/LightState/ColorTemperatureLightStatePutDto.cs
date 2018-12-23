using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put.LightState
{
    public class ColorTemperatureLightPutStateDto
    {
        public bool On { get; set; }

        /// <summary>
        /// Brightness
        /// </summary>
        public int Bri { get; set; }

    }
}
