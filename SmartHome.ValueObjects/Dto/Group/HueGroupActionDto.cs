using SmartHome.ValueObjects.Enums;
using System;
using System.Collections.Generic;

namespace SmartHome.ValueObjects.Dto.Group
{
    public class HueGroupActionDto
    {
        public bool On { get; set; }

        /// <summary>
        /// Brightness is a scale from 0 (the minimum the light is capable of) to 254 (the maximum).
        /// </summary>
        public byte Bri { get; set; }

        /// <summary>
        /// The hue value is a wrapping value between 0 and 65535.
        /// Both 0 and 65535 are red, 25500 is green and 46920 is blue.e.g. 
        /// “hue”: 50000 will set the light to a specific hue.
        /// </summary>
        public UInt16 Hue { get; set; }

        /// <summary>
        /// Saturation of the light. 254 is the most saturated (colored) and 0 is the least saturated (white)
        /// </summary>
        public byte Sat { get; set; }

        /// <summary>
        /// The x and y coordinates of a color in CIE color space
        /// The first entry is the x coordinate and the second entry is the y coordinate. 
        /// Both x and y must be between 0 and 1.
        /// If the specified coordinates are not in the CIE color space, 
        /// the closest color to the coordinates will be chosen.
        /// </summary>
        public List<float> XY { get; set; }

        /// <summary>
        /// The Mired Color temperature of the light. 2012 connected lights are capable of 153 (6500K) to 500 (2000K).
        /// </summary>
        public UInt16 CT { get; set; }


        public EHueDeviceStateAlert Alert {get;set;}

        /// <summary>
        /// The dynamic effect of the light, currently “none” and “colorloop” are supported. 
        /// Other values will generate an error of type 
        /// 7.Setting the effect to colorloop will cycle through all hues using the current brightness and saturation 
        /// settings.
        /// </summary>
        public string Effect { get; set; }


        /// <summary>
        /// The duration of the transition from the light’s current state to the new state. This is given as a multiple of 100ms and defaults to 4 (400ms).
        /// For example, setting transitiontime:10 will make the transition last 1 second.
        /// </summary>
        public UInt16 TransitionTime { get; set; }

        /// <summary>
        /// The scene identifier if the scene you wish to recall.
        /// </summary>
        public string Scene { get; set; }
    }
}