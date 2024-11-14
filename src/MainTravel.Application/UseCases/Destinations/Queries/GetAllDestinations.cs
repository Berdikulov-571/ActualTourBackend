using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Destinations.Queries
{
    public class GetAllDestinations : IRequest<IEnumerable<Destination>>
    {

    }

    public class GetAllDestinationsHandler : IRequestHandler<GetAllDestinations, IEnumerable<Destination>>
    {
        private readonly IAppDbContext _context;

        public GetAllDestinationsHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> Handle(GetAllDestinations request, CancellationToken cancellationToken)
        {
            var response = await _context.Destinations
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}