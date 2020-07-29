using System.Linq;
using Autofac;
using Microsoft.Xna.Framework;
using System;
using Autofac.Extensions.DependencyInjection;
using Monogame.Core.DependencyInjection;
using MonoGame.Core.Components;
using MonoGame.Core.Sprite;
using Craftopia.Drawable;

namespace Craftopia.Bootstrap
{
    public class AutofacServiceProviderFactory : IServiceProviderFactory
    {
        public virtual IServiceProvider GetServiceProvider(Game game)
        {
            var builder = new ContainerBuilder();
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(game).As<Game>();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();

            builder.RegisterType<MainGameSpriteBatchComponent>().As<ISpriteBatchComponent>().InstancePerLifetimeScope();
            builder.RegisterType<SpriteBatchOptions>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<SpaceShip>().As<ISpaceShip>().InstancePerLifetimeScope();
            builder.RegisterType<ScoreBoard>().As<IScoreBoard>().InstancePerLifetimeScope();
            builder.RegisterType<TitleContainerFileStreamProvider>().As<IFileStreamProvider>().InstancePerLifetimeScope();

            var assy = this.GetType().Assembly;

            builder.RegisterAssemblyTypes(assy, typeof(RegisterAttribute).Assembly)
                .Where(t => IsPerLifetimeService(t))               
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            // .PropertiesAutowired();        



            var container = builder.Build();
            return new AutofacServiceProvider(container);           
        }

        public bool IsPerLifetimeService(object type)
        {
            Type t = (Type)type;
            var atts = t.GetCustomAttributes(typeof(RegisterAttribute), false);
            if (atts.Any())
            {
                foreach (RegisterAttribute att in atts)
                {
                    if (att.LifeTime == RegistrationLifeTimes.Scoped)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

}


