using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.TourGuides
{
    public class UpdateTourGuideDto
    {
        public long Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? FullName { get; set; }
        public string? Profession { get; set; }
    }
}