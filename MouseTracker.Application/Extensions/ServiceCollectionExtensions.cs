using MouseTracker.Application.Interfaces;
using MouseTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MouseTracker.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<IMouseService, MouseService>();
            return services;
        }
    }
}
