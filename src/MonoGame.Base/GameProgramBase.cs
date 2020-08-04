using Monogame.Core.DependencyInjection;

namespace Monogame.Base
{
    public abstract class GameProgramBase
    {
        public virtual void Run()
        {
            var factory = GetServiceProviderFactory();
            using (var game = GetGame(factory))
            {                
                game.Run();
            }
        }

        protected abstract IGame GetGame(IServiceProviderFactory factory);

        protected abstract IServiceProviderFactory GetServiceProviderFactory();      

    }
}
