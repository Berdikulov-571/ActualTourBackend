using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Destinations;
using MainTravel.Domain.Exceptions.Destinations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Destinations.Commands
{
    public class UpdateDestinationCommand : UpdateDestinationDto, IRequest<bool>
    {

    }

    public class UpdateDestinationCommandHandler : IRequestHandler<UpdateDestinationCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public UpdateDestinationCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (destination == null)
                throw new DestinationNotFoundException();

            if (!string.IsNullOrEmpty(request.State))
                destination.State = request.State;
            if (!string.IsNullOrEmpty(request.City))
                destination.City = request.City;
            destination.UpdatedAt = DateTime.UtcNow;
            destination.Tours = request.Tours;
            if (request.Image != null)
            {
                await _fileService.DeleteImageAsync(destination.ImagePath);
                destination.ImagePath = await _fileService.UplaodImageAsync(request.Image);
            }

            _context.Destinations.Update(destination);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}