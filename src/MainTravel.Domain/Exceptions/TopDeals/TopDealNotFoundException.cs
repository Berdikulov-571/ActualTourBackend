namespace MainTravel.Domain.Exceptions.TopDeals
{
    public class TopDealNotFoundException : NotFoundException
    {
        public TopDealNotFoundException()
        {
            TitleMessage = "TopDeal Not Found!";
        }
    }
}