namespace MainTravel.Domain.DTOs.Messages
{
    public class CreateMessageDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserMessage { get; set; } = string.Empty;
    }
}