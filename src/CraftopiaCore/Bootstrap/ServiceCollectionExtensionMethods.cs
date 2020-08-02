using System;
using MonoGame.Core.Components;
using Microsoft.Extensions.DependencyInjection;
using Dazinator.Extensions.DependencyInjection;

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


