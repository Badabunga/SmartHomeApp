using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Domain.Enum
{
    public enum EDeviceType
    {
        Undefined = 0,
        /// <summary>
        /// Hue LED Streifen
        /// </summary>
        Hue_ExtendedColorLight,
        ESP8266,
        /// <summary>
        /// Hue Deckenlampe
        /// </summary>
        Hue_TemperatureLight
    }
}
