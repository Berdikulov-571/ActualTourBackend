using MainTravel.Domain.Abstractions;

namespace MainTravel.Domain.Entities
{
    public class Destination : BaseEntity
    {
        public string ImagePath { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Tours { get; set; }
    }
}