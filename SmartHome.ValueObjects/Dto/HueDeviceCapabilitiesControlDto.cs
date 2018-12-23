using System;
using System.Collections.Generic;
using System.Collections;

namespace SmartHome.ValueObjects.Dto
{
    public class HueDeviceCapabilitiesControlDto
    {
        public int MinDimLevel { get; set; }

        public int MaxLumen { get; set; }

        public string ColorgAmutType { get; set; }

        public List<List<float>> Colorgamut { get; set; }

        public HueDeviceCapabilitiesControlCtDto Ct { get; set; }
    }
}