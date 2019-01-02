using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put.GroupState
{
    public class GroupStateWithOnPut
    {
        public bool On { get; set; }

        /// <summary>
        /// Saturation
        /// </summary>
        public byte? Sat { get; set; }

        /// <summary>
        /// Brightness
        /// </summary>
        public int? Bri { get; set; }


        public int? Hue { get; set; }

        public string Effect { get; set; }


        public int? Ct { get; set; }


        public string Alert { get; set; }

        public List<float> XY { get; set; }
    }
}
