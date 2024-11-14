using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Destinations;
using MainTravel.Domain.Entities;
using MediatR;

namespace MainTravel.Application.UseCases.Destinations.Commands
{
    public class CreateDestinationCommand : CreateDestinationDto, IRequest<bool>
    {

    }

    public class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public CreateDestinationCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = new Destination()
            {
                City = request.City,
                State = request.State,
                Tours = request.Tours,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ImagePath = await _fileService.UplaodImageAsync(request.Image)
            };

            await _context.Destinations.AddAsync(destination);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}