using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Companies.Queries
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public long Id { get; set; }
    }

    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company>
    {
        private readonly IAppDbContext _context;

        public GetCompanyByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Company> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return response;
        }
    }
}