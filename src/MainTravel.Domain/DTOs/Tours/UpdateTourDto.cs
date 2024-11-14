using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.Tours
{
    public class UpdateTourDto
    {
        public long Id { get; set; }
        public int Day { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }
        public string? State { get; set; }
        public string? WhereTo { get; set; }
    }
}