using SmartHome.ValueObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Group
{
    public class HueGroupDto
    {

        public HueGroupStateDto State { get; set; }

        public HueGroupActionDto Action { get; set; }

        public string Name { get; set; }

        public List<int> Lights { get; set; }

        public List<int> Sensors { get; set; }

        public EHueGroupType Type { get; set; }     

        public bool Recycle { get; set; }
    }
}
