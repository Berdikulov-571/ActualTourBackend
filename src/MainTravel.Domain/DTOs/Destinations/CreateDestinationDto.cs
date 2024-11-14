using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.Destinations
{
    public class CreateDestinationDto
    {
        public IFormFile Image { get; set; } = default!;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Tours { get; set; }
    }
}