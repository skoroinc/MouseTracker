using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Domain.Interfaces;
using MouseTracker.Infrastructure.Repositories;

namespace MouseTracker.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
