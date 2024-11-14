using MainTravel.Domain.Abstractions;

namespace MainTravel.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string OfficeLocation { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telegram { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
    }
}