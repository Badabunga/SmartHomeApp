using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EHueDeviceUpdateState
    {
        NotDefined,
        /// <summary>
        /// System cannot update this device or determine if it is out-of-date.
        /// </summary>
        NotUpdateable,

        /// <summary>
        /// No update available nor known.
        /// </summary>
        NoUpdates,
        /// <summary>
        /// Bridge knows there is an update is available. 
        /// But not yet downloaded from portal or finished transferring to device.
        /// </summary>
        Transferring,

        /// <summary>
        /// Software is ready to install (ie transferred to device).
        /// </summary>
        ReadyToInstall,

        /// <summary>
        /// Software update is installing. Note that the device might not be usable for 30-60s during installation.
        /// </summary>
        Installing,

        /// <summary>
        /// Battery is too low for update.
        /// </summary>
        BatteryLow,

        /// <summary>
        /// Device rejected installing image.
        /// </summary>
        ImageRejected,

        /// <summary>
        ///  	There is an issue installing the software.
        /// </summary>
        Error
    }
}
