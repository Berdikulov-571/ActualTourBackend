using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TopDeals.Queries
{
    public class GetTopDealByIdQuery : IRequest<TopDeal>
    {
        public long Id { get; set; }
    }

    public class GetTopDealByIdQueryHandler : IRequestHandler<GetTopDealByIdQuery, TopDeal>
    {
        private readonly IAppDbContext _context;

        public GetTopDealByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TopDeal> Handle(GetTopDealByIdQuery request, CancellationToken cancellationToken)
        {
            var topDeal = await _context.TopDeals
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return topDeal;
        }
    }
}