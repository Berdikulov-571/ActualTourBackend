using MainTravel.Domain.Abstractions;

namespace MainTravel.Domain.Entities
{
    public class TourGuides : BaseEntity
    {
        public string ImagePath { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
    }
}