using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Tours;
using MainTravel.Domain.Entities;
using MediatR;

namespace MainTravel.Application.UseCases.Tours.Commands
{
    public class CreateTourCommand : CreateTourDto, IRequest<bool>
    {

    }

    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IFileService _fileService;

        public CreateTourCommandHandler(IAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<bool> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = new Tour()
            {
                Day = request.Day,
                ImagePath = await _fileService.UplaodImageAsync(request.Image),
                Price = request.Price,
                State = request.State,
                WhereTo = request.WhereTo,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Tours.AddAsync(tour, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}