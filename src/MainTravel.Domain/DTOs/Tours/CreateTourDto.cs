using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.Tours
{
    public class CreateTourDto
    {
        public IFormFile Image { get; set; } = default!;
        public int Day { get; set; }
        public string State { get; set; } = string.Empty;
        public string WhereTo { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}