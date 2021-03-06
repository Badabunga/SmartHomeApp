﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put
{
    public class HueLightStatePutDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool On { get; set; }

        /// <summary>
        /// Saturation
        /// </summary>
        [Required]
        public byte Sat { get; set; }

        /// <summary>
        /// Brightness
        /// </summary>
        [Required]
        public int Bri{ get; set; }

        [Required]
        public int Hue { get; set; }
    }
}
