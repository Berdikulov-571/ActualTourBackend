using MainTravel.Application.Abstractions;
using MainTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace MainTravel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseNpgsql(connection);
            });

            services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);

            return services;
        }
    }
}