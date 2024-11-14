using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.Destinations
{
    public class UpdateDestinationDto
    {
        public long Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int Tours { get; set; }
    }
}