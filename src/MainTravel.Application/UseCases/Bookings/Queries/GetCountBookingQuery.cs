using MainTravel.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Bookings.Queries
{
    public class GetCountBookingQuery : IRequest<long>
    {

    }

    public class GetCountBookingQueryHandler : IRequestHandler<GetCountBookingQuery, long>
    {
        private readonly IAppDbContext _context;

        public GetCountBookingQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(GetCountBookingQuery request, CancellationToken cancellationToken)
        {
            long response = await _context.Bookings.LongCountAsync(cancellationToken);

            return response;
        }
    }
}