using SmartHome.ValueObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceStateDto
    {
        public bool Reachable { get; set; }

        public bool On { get; set; }

        public UInt16 TransistionTime { get; set; }

        public string Alert { get; set; }

        public EHueDeviceStateModus Mode {get;set;}
    }
}
