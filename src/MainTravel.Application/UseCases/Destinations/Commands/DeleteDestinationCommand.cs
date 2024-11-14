using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.Destinations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Destinations.Commands
{
    public class DeleteDestinationCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteDestinationCommandHandler : IRequestHandler<DeleteDestinationCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public DeleteDestinationCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(DeleteDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if (destination == null)
                throw new DestinationNotFoundException();

            await _fileService.DeleteImageAsync(destination.ImagePath);
            _context.Destinations.Remove(destination);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}