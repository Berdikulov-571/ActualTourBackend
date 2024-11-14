using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.TopDeals
{
    public class UpdateTopDealDto
    {
        public long Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public decimal Price { get; set; }
        public string? ImageSize { get; set; }
        public int Day { get; set; }
    }
}