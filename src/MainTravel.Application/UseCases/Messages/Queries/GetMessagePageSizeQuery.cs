using MainTravel.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Messages.Queries
{
    public class GetMessagePageSizeQuery : IRequest<int>
    {
        public string Query { get; set; } = string.Empty;
        public int MaxPageSize { get; set; }
    }

    public class GetMessagePageSizeQueryHandler : IRequestHandler<GetMessagePageSizeQuery, int>
    {
        private readonly IAppDbContext _context;

        public GetMessagePageSizeQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetMessagePageSizeQuery request, CancellationToken cancellationToken)
        {
            var query = request.Query.ToLower();

            long dataCount;

            try
            {
                if (query == "none")
                {
                    dataCount = await _context.Messages
                        .LongCountAsync(cancellationToken);
                }
                else
                {
                    dataCount = await _context.Messages
                    .Where(x => x.FirstName.ToLower().Contains(query) ||
                    x.LastName.ToLower().Contains(query) ||
                    x.PhoneNumber.ToLower().Contains(query) ||
                    x.CreatedAt.ToString().Contains(query))
                    .LongCountAsync(cancellationToken);
                }
            }
            catch
            {
                dataCount = 0;
            }

            double data = (double)dataCount / request.MaxPageSize;
            return (int)Math.Ceiling(data);
        }
    }
}