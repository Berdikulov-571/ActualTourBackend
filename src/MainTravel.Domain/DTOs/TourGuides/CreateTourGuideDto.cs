using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.TourGuides
{
    public class CreateTourGuideDto
    {
        public IFormFile Image { get; set; } = default!;
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
    }
}