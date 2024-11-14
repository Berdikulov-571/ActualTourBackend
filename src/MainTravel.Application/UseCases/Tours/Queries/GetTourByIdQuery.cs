using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Tours.Queries
{
    public class GetTourByIdQuery : IRequest<Tour>
    {
        public long Id { get; set; }
    }

    public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, Tour>
    {
        private readonly IAppDbContext _context;

        public GetTourByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Tour> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Tours
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return response;
        }
    }
}