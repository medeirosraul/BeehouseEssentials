using Beehouse.Essentials.Identity;
using Beehouse.Essentials.Identity.Subscriptions.Services;
using Beehouse.Essentials.Services;
using Beehouse.Essentials.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Beehouse.Essentials
{
    public static class BeehouseExtensions
    {
        public static IServiceCollection AddBeehouse(this IServiceCollection services, bool UseDevelopmentMode = false)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IUserService<>), typeof(UserService<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            BeehouseSettings.UseDevelopmentMode = UseDevelopmentMode;
            return services;
        }

        public static void AddBeehouseIdentity(this IServiceCollection services)
        {
          
        }

        
    }
}