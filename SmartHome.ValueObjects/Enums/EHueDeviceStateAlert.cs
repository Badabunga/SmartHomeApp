using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EHueDeviceStateAlert
    {
        /// <summary>
        /// Doc:  The lamp shall stop performing all alert effects.
        /// </summary>
        None,
        /// <summary>
        /// Doc:  	The lamp shall perform one breathe cycle.
        /// </summary>
        Select,

        /// <summary>
        /// Doc: The lamp shall perform breathe cycles for 15 seconds or until the “alert”:”none” command is received.
        /// </summary>
        lSelect
    }
}
