using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TopDeals.Queries
{
    public class GetAllTopDealsQuery : IRequest<IEnumerable<TopDeal>>
    {

    }

    public class GetAllTopDealsQueryHandler : IRequestHandler<GetAllTopDealsQuery, IEnumerable<TopDeal>>
    {
        private readonly IAppDbContext _context;

        public GetAllTopDealsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TopDeal>> Handle(GetAllTopDealsQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.TopDeals
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}