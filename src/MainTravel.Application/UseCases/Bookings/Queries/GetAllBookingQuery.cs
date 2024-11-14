using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Paginations;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Bookings.Queries
{
    public class GetAllBookingQuery : IRequest<IEnumerable<Booking>>
    {
        public PaginationParams Params { get; set; } = default!;
    }

    public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, IEnumerable<Booking>>
    {
        private readonly IAppDbContext _context;

        public GetAllBookingQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
        {
            return await _context.Bookings
                .Skip(request.Params.GetSkipCount())
                .Take(request.Params.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}