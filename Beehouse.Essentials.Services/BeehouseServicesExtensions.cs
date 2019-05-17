using Beehouse.Essentials.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Beehouse.Essentials.Services
{
    public static class BeehouseServicesExtensions
    {
        public static IServiceCollection AddBeehouseServices(this IServiceCollection services, bool UseDevelopmentMode = false)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            BeehouseSettings.UseDevelopmentMode = UseDevelopmentMode;
            return services;
        }
    }
}
