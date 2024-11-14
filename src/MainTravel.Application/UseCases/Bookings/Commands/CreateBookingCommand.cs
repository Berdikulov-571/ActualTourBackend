using MainTravel.Application.Abstractions;
using MainTravel.Domain.DTOs.Bookings;
using MainTravel.Domain.Entities;
using MainTravel.Domain.Enums;
using MediatR;

namespace MainTravel.Application.UseCases.Bookings.Commands
{
    public class CreateBookingCommand : CreateBookingDto, IRequest<bool>
    {

    }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
    {
        private readonly IAppDbContext _context;

        public CreateBookingCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                Humans = request.Humans,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                TourId = request.TourId,
                Status = (Status)1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var entity = await _context.Bookings.AddAsync(booking, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken);

            return response > 0;
        }
    }
}