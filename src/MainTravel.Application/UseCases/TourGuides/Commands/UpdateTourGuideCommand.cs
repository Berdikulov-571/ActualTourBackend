using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.TourGuides;
using MainTravel.Domain.Exceptions.TourGuides;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TourGuides.Commands
{
    public class UpdateTourGuideCommand : UpdateTourGuideDto, IRequest<bool>
    {

    }

    public class UpdateTourGuideCommandHandler : IRequestHandler<UpdateTourGuideCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public UpdateTourGuideCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateTourGuideCommand request, CancellationToken cancellationToken)
        {
            var tourGuide = await _context.TourGuides.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (tourGuide == null)
                throw new TourGuideNotFoundException();

            if (!string.IsNullOrEmpty(request.FullName))
                tourGuide.FullName = request.FullName;
            if (!string.IsNullOrEmpty(request.Profession))
                tourGuide.Profession = request.Profession;

            if (request.Image != null)
            {
                await _fileService.DeleteImageAsync(tourGuide.ImagePath);
                tourGuide.ImagePath = await _fileService.UplaodImageAsync(request.Image);
            }
            tourGuide.UpdatedAt = DateTime.UtcNow;

            _context.TourGuides.Update(tourGuide);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}