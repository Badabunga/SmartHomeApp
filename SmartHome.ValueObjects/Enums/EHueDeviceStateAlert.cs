using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EHueDeviceStateAlert
    {
        /// <summary>
        /// Doc:  The lamp shall stop performing all alert effects.
        /// </summary>
        [Display(Name="none")]
        None,
        /// <summary>
        /// Doc:  	The lamp shall perform one breathe cycle.
        /// </summary>
        [Display(Name ="select")]
        Select,

        /// <summary>
        /// Doc: The lamp shall perform breathe cycles for 15 seconds or until the “alert”:”none” command is received.
        /// </summary>
       [Display(Name ="lselect")]
        lSelect
    }
}
