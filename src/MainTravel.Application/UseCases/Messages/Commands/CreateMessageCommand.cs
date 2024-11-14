using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Messages;
using MainTravel.Domain.Entities;
using MediatR;

namespace MainTravel.Application.UseCases.Messages.Commands
{
    public class CreateMessageCommand : CreateMessageDto, IRequest<bool>
    {

    }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, bool>
    {
        private readonly IAppDbContext _context;

        public CreateMessageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserMessage = request.UserMessage,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Messages.AddAsync(message, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}