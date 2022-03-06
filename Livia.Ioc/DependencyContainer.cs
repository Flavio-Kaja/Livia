using Microsoft.Extensions.DependencyInjection;

namespace Livia.Ioc
{
    /// <summary>
    /// register services and interfaces
    /// </summary>
    public static class DependencyContainer
    {
        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            return services;
        }
    }
}