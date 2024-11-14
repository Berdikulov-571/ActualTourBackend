using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.TourGuides;
using MediatR;

namespace MainTravel.Application.UseCases.TourGuides.Commands
{
    public class CreateTourGuideCommand : CreateTourGuideDto, IRequest<bool>
    {

    }

    public class CreateTourGuideCommandHandler : IRequestHandler<CreateTourGuideCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public CreateTourGuideCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(CreateTourGuideCommand request, CancellationToken cancellationToken)
        {
            var tourGuide = new Domain.Entities.TourGuides()
            {
                FullName = request.FullName,
                ImagePath = await _fileService.UplaodImageAsync(request.Image),
                Profession = request.Profession,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.TourGuides.AddAsync(tourGuide, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}