using Beehouse.Essentials.Web.Api;
using Beehouse.Essentials.Web.Js;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Extensions
{
    public static class BeehouseWebExtensions
    {
        public static IServiceCollection AddBeehouseWeb(this IServiceCollection services)
        {
            return services.AddBeehouseWeb(o => { });
        }

        public static IServiceCollection AddBeehouseWeb(this IServiceCollection services, Action<BeehouseWebOptions> setupAction)
        {
            services.AddHttpClient<IApiClient, ApiClient>();
            services.AddScoped<IJSInteropManager, JSInteropManager>();

            services.Configure(setupAction);
            return services;
        }
    }
}
