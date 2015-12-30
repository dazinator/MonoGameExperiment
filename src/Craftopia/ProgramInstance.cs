using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;

namespace Craftopia
{
    public class ProgramInstance
    {
        public virtual void Run()
        {
            using (var game = GetGame())
            {
                game.Run();
            }
        }

        private Game GetGame()
        {
            IResolverProvider resolverProvider = GetResolverProvider();
            return new CraftopiaGame(resolverProvider);
        }

        public virtual IResolverProvider GetResolverProvider()
        {
            return new AutofacResolverProvider();
        }

    }
}
