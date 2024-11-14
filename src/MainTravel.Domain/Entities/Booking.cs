using MainTravel.Domain.Abstractions;
using MainTravel.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainTravel.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int Humans { get; set; }
        [ForeignKey(nameof(Tour))]
        public long TourId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Status Status { get; set; }

        public Tour? Tour { get; set; }
    }
}