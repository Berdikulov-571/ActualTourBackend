using MainTravel.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TourGuides.Queries
{
    public class GetAllTourGuidesQuery : IRequest<IEnumerable<Domain.Entities.TourGuides>>
    {

    }

    public class GetAllTourGuidesQueryHandler : IRequestHandler<GetAllTourGuidesQuery, IEnumerable<Domain.Entities.TourGuides>>
    {
        private readonly IAppDbContext _context;

        public GetAllTourGuidesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.TourGuides>> Handle(GetAllTourGuidesQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.TourGuides
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}