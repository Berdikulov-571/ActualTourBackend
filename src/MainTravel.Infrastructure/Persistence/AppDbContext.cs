using MainTravel.Application.Abstractions;
using MainTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MainTravel.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Booking> Bookings { get ; set ; }
        public DbSet<Company> Companies { get ; set ; }
        public DbSet<Destination> Destinations { get ; set ; }
        public DbSet<Message> Messages { get ; set ; }
        public DbSet<TopDeal> TopDeals { get ; set ; }
        public DbSet<Tour> Tours { get ; set ; }
        public DbSet<TourGuides> TourGuides { get ; set ; }


        async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}