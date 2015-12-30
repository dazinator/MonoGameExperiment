using Autofac;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craftopia.Bootstrap
{
    public interface IResolverProvider
    {
        IResolver GetResolver(Game game);
    }
}
