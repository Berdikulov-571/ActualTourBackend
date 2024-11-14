using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.TourGuides;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.TourGuides.Commands
{
    public class DeleteTourGuideCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteTourGuideCommandHandler : IRequestHandler<DeleteTourGuideCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public DeleteTourGuideCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(DeleteTourGuideCommand request, CancellationToken cancellationToken)
        {
            var tourGuide = await _context.TourGuides.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (tourGuide == null)
                throw new TourGuideNotFoundException();

            await _fileService.DeleteImageAsync(tourGuide.ImagePath);

            _context.TourGuides.Remove(tourGuide);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}