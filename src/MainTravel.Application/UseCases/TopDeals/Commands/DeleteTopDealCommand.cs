using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.TopDeals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TopDeals.Commands
{
    public class DeleteTopDealCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteTopDealCommandHandler : IRequestHandler<DeleteTopDealCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public DeleteTopDealCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(DeleteTopDealCommand request, CancellationToken cancellationToken)
        {
            var topDeal = await _context.TopDeals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (topDeal == null)
                throw new TopDealNotFoundException();

            _context.TopDeals.Remove(topDeal);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}