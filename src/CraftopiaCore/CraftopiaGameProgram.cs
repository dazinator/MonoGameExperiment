using Craftopia.Bootstrap;
using Monogame.Base;
using Monogame.Core.DependencyInjection;

namespace Craftopia
{
    public class CraftopiaGameProgram : GameProgramBase
    {
        protected override IServiceProviderFactory GetServiceProviderFactory()
        {
            return new MicrosoftServiceProviderFactory();
        }

        protected override IGame GetGame(IServiceProviderFactory factory)
        {
            return new CraftopiaGame(factory);
        }
    }
}
