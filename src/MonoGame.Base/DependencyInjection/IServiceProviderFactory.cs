using Microsoft.Xna.Framework;
using System;

namespace Monogame.Core.DependencyInjection
{
    public interface IServiceProviderFactory
    {
        IServiceProvider GetServiceProvider(Game game);
    }
}
