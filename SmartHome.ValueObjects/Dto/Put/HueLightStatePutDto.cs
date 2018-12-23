using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put
{
    public class HueLightStatePutDto
    {

        public bool On { get; set; }

        /// <summary>
        /// Saturation
        /// </summary>
        public byte Sat { get; set; }

        /// <summary>
        /// Brightness
        /// </summary>
        public int Bri{ get; set; }

        public int Hue { get; set; }
    }
}
