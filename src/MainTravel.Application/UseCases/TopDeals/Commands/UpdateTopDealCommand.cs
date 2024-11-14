using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.TopDeals;
using MainTravel.Domain.Exceptions.TopDeals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TopDeals.Commands
{
    public class UpdateTopDealCommand : UpdateTopDealDto, IRequest<bool>
    {

    }

    public class UpdateTopDealCommandHandler : IRequestHandler<UpdateTopDealCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public UpdateTopDealCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateTopDealCommand request, CancellationToken cancellationToken)
        {
            var topDeal = await _context.TopDeals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (topDeal == null)
                throw new TopDealNotFoundException();

            if (!string.IsNullOrEmpty(request.City))
                topDeal.City = request.City;
            if (!string.IsNullOrEmpty(request.State))
                topDeal.State = request.State;
            if (request.Image != null)
            {
                await _fileService.DeleteImageAsync(topDeal.ImagePath);
                topDeal.ImagePath = await _fileService.UplaodImageAsync(request.Image);
            }
            topDeal.UpdatedAt = DateTime.UtcNow;
            topDeal.Price = request.Price;

            _context.TopDeals.Update(topDeal);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}