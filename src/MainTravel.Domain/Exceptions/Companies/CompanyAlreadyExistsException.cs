namespace MainTravel.Domain.Exceptions.Companies
{
    public class CompanyAlreadyExistsException : AlreadyExistsException
    {
        public CompanyAlreadyExistsException()
        {
            TitleMessage = "Company Already Exists Exception!";
        }
    }
}