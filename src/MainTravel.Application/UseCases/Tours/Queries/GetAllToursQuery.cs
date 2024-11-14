using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Tours.Queries
{
    public class GetAllToursQuery : IRequest<IEnumerable<Tour>>
    {

    }

    public class GetAllToursQueryHandler : IRequestHandler<GetAllToursQuery, IEnumerable<Tour>>
    {
        private readonly IAppDbContext _context;

        public GetAllToursQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Tours
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}