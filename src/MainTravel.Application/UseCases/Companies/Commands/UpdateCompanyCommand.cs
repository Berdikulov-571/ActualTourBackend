using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Companies;
using MainTravel.Domain.Exceptions.Companies;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Companies.Commands
{
    public class UpdateCompanyCommand : UpdateCompanyDto, IRequest<bool>
    {

    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly IAppDbContext _context;

        public UpdateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (company == null)
                throw new CompanyNotFoundException();

            if (!string.IsNullOrEmpty(request.Name))
                company.Name = request.Name;
            if (!string.IsNullOrEmpty(request.PhoneNumber))
                company.PhoneNumber = request.PhoneNumber;
            if (!string.IsNullOrEmpty(request.Email))
                company.Email = request.Email;
            if (!string.IsNullOrEmpty(request.OfficeLocation))
                company.OfficeLocation = request.OfficeLocation;
            if (!string.IsNullOrEmpty(request.Telegram))
                company.Telegram = request.Telegram;
            if (!string.IsNullOrEmpty(request.Facebook))
                company.Facebook = request.Facebook;
            if (!string.IsNullOrEmpty(request.Instagram))
                company.Instagram = request.Instagram;

            company.UpdatedAt = DateTime.UtcNow;

            _context.Companies.Update(company);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}