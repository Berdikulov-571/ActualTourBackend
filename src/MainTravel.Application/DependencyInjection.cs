using MainTravel.Application.Abstractions;
using MainTravel.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MainTravel.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IFileService, FileService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}