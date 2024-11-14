using MainTravel.Domain.Abstractions;

namespace MainTravel.Domain.Entities
{
    public class Tour : BaseEntity
    {
        public string ImagePath { get; set; } = string.Empty;
        public int Day { get; set; }
        public string State { get; set; } = string.Empty;
        public string WhereTo { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}