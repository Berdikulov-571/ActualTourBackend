using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.Messages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Messages.Commands
{
    public class DeleteMessageCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly IAppDbContext _context;

        public DeleteMessageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (message == null)
                throw new MessageNotFoundException();

            _context.Messages.Remove(message);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}