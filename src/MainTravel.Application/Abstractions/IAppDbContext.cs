using MainTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MainTravel.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Destination> Destinations { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<TopDeal> TopDeals { get; set; }
        DbSet<Tour> Tours { get; set; }
        DbSet<TourGuides> TourGuides { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}