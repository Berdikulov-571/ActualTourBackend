namespace MainTravel.Domain.Exceptions.Tours
{
    public class TourNotFoundException : NotFoundException
    {
        public TourNotFoundException()
        {
            TitleMessage = "Tour Not Found!";
        }
    }
}