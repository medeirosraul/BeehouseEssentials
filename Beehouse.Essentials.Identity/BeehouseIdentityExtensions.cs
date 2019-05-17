using Beehouse.Essentials.Identity.Services;
using Beehouse.Essentials.Identity.Subscriptions.Services;
using Beehouse.Essentials.Services;
using Beehouse.Essentials.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Beehouse.Essentials.Identity
{
    public static class BeehouseIdentityExtensions
    {
        public static IServiceCollection AddBeehouseIdentity(this IServiceCollection services, bool UseDevelopmentMode = false)
        {
            services.AddBeehouseServices(UseDevelopmentMode);
            services.AddScoped(typeof(IIndividualService<>), typeof(IndividualService<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<UserManager<IdentityUserExtended>, UserManager<IdentityUserExtended>>();
            services.AddScoped<SignInManager<IdentityUserExtended>, SignInManager<IdentityUserExtended>>();

            BeehouseSettings.UseDevelopmentMode = UseDevelopmentMode;
            return services;
        }
    }
}
