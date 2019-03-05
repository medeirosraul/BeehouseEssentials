using Beehouse.Essentials.Blazor.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Beehouse.Essentials.Blazor.Extensions
{
    public static class BeehouseBlazorExtensions
    {

        public static IServiceCollection AddBeehouseBlazor(this IServiceCollection services)
        {
            return services.AddBeehouseBlazor(o => { });
        }

        public static IServiceCollection AddBeehouseBlazor(this IServiceCollection services, Action<BeehouseBlazorOptions> setupAction)
        {
            services.AddTransient<IApiClientService, ApiClientService>();

            services.Configure(setupAction);
            return services;
        }
    }
}
