namespace MainTravel.Domain.Exceptions.Bookings
{
    public class BookingNotFoundException : NotFoundException
    {
        public BookingNotFoundException()
        {
            TitleMessage = "Booking Not Found!";
        }
    }
}