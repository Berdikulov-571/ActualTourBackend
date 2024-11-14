namespace MainTravel.Domain.DTOs.Companies
{
    public class UpdateCompanyDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? OfficeLocation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Telegram { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
    }
}