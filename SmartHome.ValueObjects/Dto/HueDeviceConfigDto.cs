namespace SmartHome.ValueObjects.Dto
{
    public  class HueDeviceConfigDto
    {
        public string ArcheType { get; set; }

        public string Function { get; set; }

        public string Direction { get; set; }

        public HueDeviceConfigStartUpDto StartUp { get; set; }
    }
}