using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Paginations;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Messages.Queries
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public PaginationParams Params { get; set; } = default!;
    }

    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<Message>>
    {
        private readonly IAppDbContext _context;

        public GetAllMessagesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Messages
                .Skip(request.Params.GetSkipCount())
                .Take(request.Params.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}