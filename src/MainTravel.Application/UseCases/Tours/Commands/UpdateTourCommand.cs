using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Tours;
using MainTravel.Domain.Exceptions.Tours;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Tours.Commands
{
    public class UpdateTourCommand : UpdateTourDto, IRequest<bool>
    {

    }

    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public UpdateTourCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _context.Tours.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (tour == null)
                throw new TourNotFoundException();

            if (!string.IsNullOrEmpty(request.WhereTo))
                tour.WhereTo = request.WhereTo;
            if (!string.IsNullOrEmpty(request.State))
                tour.State = request.State;

            if (request.Image != null)
            {
                await _fileService.DeleteImageAsync(tour.ImagePath);
                tour.ImagePath = await _fileService.UplaodImageAsync(request.Image);
            }
            tour.Day = request.Day;
            tour.Price = request.Price;
            tour.UpdatedAt = DateTime.UtcNow;

            _context.Tours.Update(tour);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}