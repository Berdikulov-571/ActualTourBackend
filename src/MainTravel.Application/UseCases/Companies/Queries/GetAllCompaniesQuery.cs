using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Companies.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>>
    {

    }

    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
    {
        private readonly IAppDbContext _context;

        public GetAllCompaniesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Companies
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}