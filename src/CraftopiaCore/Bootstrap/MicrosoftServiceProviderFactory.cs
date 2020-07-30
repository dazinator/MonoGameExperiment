using Microsoft.Xna.Framework;
using System;
using Monogame.Core.DependencyInjection;
using MonoGame.Core.Components;
using Craftopia.Drawable;
using Microsoft.Extensions.DependencyInjection;
using Dazinator.Extensions.DependencyInjection;
using MonoGame.Core.Content;
using MonoGame.Core.Graphics;
using MonoGame.Extended.Collections;

namespace Craftopia.Bootstrap
{
    public class MicrosoftServiceProviderFactory : IServiceProviderFactory
    {
        public virtual IServiceProvider GetServiceProvider(Game game)
        {
            var builder = new ServiceCollection();
            game.Content.RootDirectory = "Content";

            builder.AddSingleton<Game>(game);
            builder.AddSingleton(game.Content);
            builder.AddSingleton(game.GraphicsDevice);

            builder.AddNamed<IContentManager>((a) =>
            {
                a.AddSingleton(new ContentManager(game.Content));
            });

            builder.AddNamed<ISpriteBatch>(a =>
            {
                a.AddSingleton<SpriteBatch>();
            });

            builder.AddNamed<SpriteBatchComponentOptions>(a =>
            {
                a.AddTransient<SpriteBatchComponentOptions>();
            });
            // new SpaceShip(game, )
            builder.AddSingleton<ISpaceShip>(sp => new SpaceShip(game, () => sp.GetRequiredService<IContentManager>()));
            //builder.AddSingleton<ISpaceShip, SpaceShip>();
            builder.AddSingleton<IScoreBoard, ScoreBoard>();

            builder.AddNamed<ISpriteBatchComponent>((a) =>
            {
                a.AddSingleton<MainGameSpriteBatchComponent>();
                //var spriteBatch = a.ServiceProvider.GetRequiredService<ISpriteBatch>();
                //var spriteBatchComponent = new SpriteBatchComponent(game, spriteBatch, options);
                //var spaceShip = a.ServiceProvider.GetRequiredService<ISpaceShip>();
                //var scoreBoard = a.ServiceProvider.GetRequiredService<ISpaceShip>();
                //spriteBatchComponent.AddDrawable(new SpaceShip());
            });

            builder.AddSingleton<IFileStreamProvider, TitleContainerFileStreamProvider>();

            //var assy = this.GetType().Assembly;

            //builder.RegisterAssemblyTypes(assy, typeof(RegisterAttribute).Assembly)
            //    .Where(t => IsPerLifetimeService(t))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
            //// .PropertiesAutowired();        



            //var container = builder.Build();
            return builder.BuildServiceProvider();
        }

    }
}


