using System;
using Microsoft.Extensions.DependencyInjection;
using Dazinator.Extensions.DependencyInjection;
using MonoGame.Base.Components;

namespace Craftopia.Bootstrap
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IServiceCollection AddSpriteBatchComponents(this IServiceCollection services, Action<NamedServiceRegistry<ISpriteBatchComponent>> configure)
        {
            services.AddNamed<ISpriteBatchComponent>(configure);
            return services;
        }
    }
}


