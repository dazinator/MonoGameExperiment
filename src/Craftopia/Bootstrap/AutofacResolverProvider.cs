using System.Linq;
using Autofac;
using Microsoft.Xna.Framework;
using System;

namespace Craftopia.Bootstrap
{
    public class AutofacResolverProvider : IResolverProvider
    {
        public virtual IResolver GetResolver(Game game)
        {
            var builder = new ContainerBuilder();
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(game).As<Game>();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();

            var assy = typeof(AutofacResolverProvider).Assembly;

            builder.RegisterAssemblyTypes(assy)
                .Where(t => IsPerLifetimeService(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
               // .PropertiesAutowired();

            var container = builder.Build();
            return new AutofacResolver(container);
        }

        public bool IsPerLifetimeService(object type)
        {
            Type t = (Type)type;
            var atts = t.GetCustomAttributes(typeof(RegisterAttribute), false);
            if (atts.Any())
            {
                foreach (RegisterAttribute att in atts)
                {
                    if (att.LifeTime == RegistrationLifeTimes.InstancePerLifetimeScope)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

}


