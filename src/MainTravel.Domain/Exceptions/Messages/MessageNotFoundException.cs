namespace MainTravel.Domain.Exceptions.Messages
{
    public class MessageNotFoundException : NotFoundException
    {
        public MessageNotFoundException()
        {
            TitleMessage = "Message Not Found!";
        }
    }
}