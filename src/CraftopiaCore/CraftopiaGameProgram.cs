using Craftopia.Bootstrap;
using Monogame.Core.DependencyInjection;

namespace Craftopia
{
    public class CraftopiaGameProgram : GameProgramBase
    {
        protected override IServiceProviderFactory GetServiceProviderFactory()
        {
            return new AutofacServiceProviderFactory();
        }

        protected override IGame GetGame(IServiceProviderFactory factory)
        {
            return new CraftopiaGame(factory);
        }
    }
}
