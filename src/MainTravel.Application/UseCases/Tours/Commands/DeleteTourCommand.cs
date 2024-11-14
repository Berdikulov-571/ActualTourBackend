using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.Tours;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Tours.Commands
{
    public class DeleteTourCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public DeleteTourCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _context.Tours.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (tour == null)
                throw new TourNotFoundException();

            await _fileService.DeleteImageAsync(tour.ImagePath);

            _context.Tours.Remove(tour);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}