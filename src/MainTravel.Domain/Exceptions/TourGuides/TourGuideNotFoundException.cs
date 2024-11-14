namespace MainTravel.Domain.Exceptions.TourGuides
{
    public class TourGuideNotFoundException : NotFoundException
    {
        public TourGuideNotFoundException()
        {
            TitleMessage = "Tour Guide Not Found!";
        }
    }
}