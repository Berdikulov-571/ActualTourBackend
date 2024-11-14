using Microsoft.AspNetCore.Http;

namespace MainTravel.Domain.DTOs.TopDeals
{
    public class CreateTopDealDto
    {
        public IFormFile Image { get; set; } = default!;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Day { get; set; }
        public string ImageSize { get; set; } = string.Empty;
    }
}