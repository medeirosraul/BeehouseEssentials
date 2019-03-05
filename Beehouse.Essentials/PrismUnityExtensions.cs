using System;
using Beehouse.Essentials.Services;
using Unity;

namespace Beehouse.Essentials
{
    public static class PrismUnityExtensions
    {
        public static IUnityContainer UseBeehouse(this IUnityContainer container)
        {
            container.UseBeehouse(null);
            return container;
        }

        public static IUnityContainer UseBeehouse(this IUnityContainer container, Action<IUnityContainer> options)
        {
            options?.Invoke(container);
            Defaults().Invoke(container);
            return container;
        }

        private static Action<IUnityContainer> Defaults()
        {
            return c =>
            {
                c.RegisterType(typeof(IService<>), typeof(Service<>));
            };
        }
    }
}