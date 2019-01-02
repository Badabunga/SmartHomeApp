using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put
{
    public class HueGroupStatePutDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
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
