using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.Companies;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Companies.Commands
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly IAppDbContext _context;

        public DeleteCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (company == null)
                throw new CompanyNotFoundException();

            _context.Companies.Remove(company);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}