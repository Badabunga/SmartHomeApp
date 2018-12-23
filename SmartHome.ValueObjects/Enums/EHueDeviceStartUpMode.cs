using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EHueDeviceStartUpMode
    {
        /// <summary>
        /// lights go back to Philips “bright light” safety setting (100% brightness @ 2700K)
        /// </summary>
        Safety,
        /// <summary>
        /// light keeps the setting when power failed. If light was off it stays off
        /// </summary>
        PowerFail,
        /// <summary>
        /// light keeps the setting when power failed. If light was off it returns to the last on state
        /// </summary>
        LastOnState,

        /// <summary>
        /// custom settings defined in custom settings. 
        /// Will be automatically set when providing “customsettings”.
        /// Not available for “On/Off Light
        /// </summary>
        Custom,
        /// <summary>
        /// custom setting is not supported
        /// </summary>
        Unkown
    }
}
