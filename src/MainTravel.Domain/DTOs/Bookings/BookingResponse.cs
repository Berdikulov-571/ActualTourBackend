using MainTravel.Domain.Entities;
using MainTravel.Domain.Enums;

namespace MainTravel.Domain.DTOs.Bookings
{
    public class BookingResponse
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int Humans { get; set; }
        public long TourId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Status Status { get; set; }
        public Tour? Tour{ get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}