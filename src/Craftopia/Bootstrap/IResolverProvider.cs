using Microsoft.Xna.Framework;

namespace Craftopia.Bootstrap
{
    public interface IResolverProvider
    {
        IResolver GetResolver(Game game);
    }
}
