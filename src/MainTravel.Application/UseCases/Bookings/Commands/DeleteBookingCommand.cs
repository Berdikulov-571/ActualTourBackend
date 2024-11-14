using MainTravel.Application.Abstractions;
using MainTravel.Domain.Exceptions.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.UseCases.Bookings.Commands
{
    public class DeleteBookingCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IAppDbContext _context;

        public DeleteBookingCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if (booking == null)
                throw new BookingNotFoundException();

            _context.Bookings.Remove(booking);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}