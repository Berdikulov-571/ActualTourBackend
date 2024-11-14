using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Destinations.Queries
{
    public class GetDestinationByIdQuery : IRequest<Destination>
    {
        public long Id { get; set; }
    }

    public class GetDestinationByIdQueryHandler : IRequestHandler<GetDestinationByIdQuery, Destination>
    {
        private readonly IAppDbContext _context;

        public GetDestinationByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Destination> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            var destination = await _context.Destinations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return destination;
        }
    }
}