using MainTravel.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TourGuides.Queries
{
    public class GetTourGuideByIdQuery : IRequest<Domain.Entities.TourGuides>
    {
        public long Id { get; set; }
    }

    public class GetTourGuideByIdQueryHandler : IRequestHandler<GetTourGuideByIdQuery, Domain.Entities.TourGuides>
    {
        private readonly IAppDbContext _context;

        public GetTourGuideByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.TourGuides> Handle(GetTourGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.TourGuides
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return response;
        }
    }
}