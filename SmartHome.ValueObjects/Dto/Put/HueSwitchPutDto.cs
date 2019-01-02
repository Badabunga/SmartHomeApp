using SmartHome.ValueObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Dto.Put
{
    public class HueSwitchPutDto
    {
        public int Id { get; set; }

        public bool On { get; set; }

        public EHueLogicType LogicType { get; set; }
    }
}
