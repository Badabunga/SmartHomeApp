using SmartHome.ValueObjects.Enums;

namespace SmartHome.ValueObjects.Dto.Response
{
    public class ApiErrorResponseDto
    {
        public EErrorResponseCode Type { get; set; }

        public string Address { get; set;}

        public string Description { get; set; }
    }
}