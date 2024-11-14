namespace MainTravel.Domain.Exceptions.Destinations
{
    public class DestinationNotFoundException : NotFoundException
    {
        public DestinationNotFoundException()
        {
            TitleMessage = "Destination Not Found!";
        }
    }
}