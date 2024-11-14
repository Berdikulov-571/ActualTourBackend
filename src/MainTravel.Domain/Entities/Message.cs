using MainTravel.Domain.Abstractions;

namespace MainTravel.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserMessage { get; set; } = string.Empty;
    }
}