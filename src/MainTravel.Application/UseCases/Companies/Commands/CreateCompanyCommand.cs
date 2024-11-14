using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Companies;
using MainTravel.Domain.Entities;
using MainTravel.Domain.Exceptions.Companies;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Companies.Commands
{
    public class CreateCompanyCommand : CreateCompanyDto, IRequest<bool>
    {

    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private readonly IAppDbContext _context;

        public CreateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyExists = await _context.Companies.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);

            if (companyExists != null)
                throw new CompanyAlreadyExistsException();

            var company = new Company()
            {
                Name = request.Name,
                Email = request.Email,
                OfficeLocation = request.OfficeLocation,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Facebook = request.Facebook,
                Instagram = request.Instagram,
                Telegram = request.Telegram,
            };

            var res = await _context.Companies.AddAsync(company, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}