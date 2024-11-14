using MainTravel.Domain.Enums;

namespace MainTravel.Domain.DTOs.Bookings
{
    public class CreateBookingDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int Humans { get; set; }
        public long TourId { get; set; }
        public Status Status { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}