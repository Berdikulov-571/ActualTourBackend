using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Paginations;
using MainTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Messages.Queries
{
    public class SearchMessageQuery : IRequest<IEnumerable<Message>>
    {
        public string Query { get; set; } = string.Empty;
        public PaginationParams Params { get; set; } = default!;
    }

    public class SearchMessageQueryHandler : IRequestHandler<SearchMessageQuery, IEnumerable<Message>>
    {
        private readonly IAppDbContext _context;

        public SearchMessageQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> Handle(SearchMessageQuery request, CancellationToken cancellationToken)
        {
            var query = request.Query.ToLower();

            return _context.Messages
                .Where(x => x.FirstName.ToLower().Contains(query) ||
                x.LastName.ToLower().Contains(query) ||
                x.PhoneNumber.ToLower().Contains(query) ||
                x.CreatedAt.ToString().Contains(query))
                .AsNoTracking();
        }
    }
}