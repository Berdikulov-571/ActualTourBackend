using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.TopDeals;
using MainTravel.Domain.Entities;
using MediatR;

namespace MainTravel.Application.UseCases.TopDeals.Commands
{
    public class CreateTopDealCommand : CreateTopDealDto, IRequest<bool>
    {

    }

    public class CreateTopDealCommandHandler : IRequestHandler<CreateTopDealCommand, bool>
    {
        private readonly IFileService _fileService;
        private readonly IAppDbContext _context;

        public CreateTopDealCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(CreateTopDealCommand request, CancellationToken cancellationToken)
        {
            var topDeal = new TopDeal()
            {
                ImagePath = await _fileService.UplaodImageAsync(request.Image),
                City = request.City,
                State = request.State,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.TopDeals.AddAsync(topDeal, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}