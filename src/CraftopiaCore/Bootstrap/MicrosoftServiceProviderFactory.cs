using Microsoft.Xna.Framework;
using System;
using Monogame.Core.DependencyInjection;
using Craftopia.Drawable;
using Microsoft.Extensions.DependencyInjection;
using Dazinator.Extensions.DependencyInjection;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using Monogame.Base;
using MonoGame.Base.Components;

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
            builder.AddSingleton<IGraphicsDevice>((a) =>
            {
                return new GraphicsDevice(game.GraphicsDevice);
            });

            builder.AddNamed<IContentManager>((a) =>
            {
                a.AddSingleton(new ContentManager(game.Content));
            });

            builder.AddNamed<ISpriteBatch>(a =>
            {
                a.AddSingleton<SpriteBatch>();
            });

            builder.AddSingleton<IFileStreamProvider, TitleContainerFileStreamProvider>();


            builder.AddSingleton<ScaledResolutionComponent>((sp) =>
            {
                // This component draws an inner IDrawable to a render target. It then draws that render target seperately, 
                // scaled to the screen, in a way that preserves current aspect ration, and uses a scale factor.
                var innerDrawable = sp.GetRequiredService<ISpriteBatchComponent>(); // the inner component we want to render. This a group of sprites for our scene.
                var instance = ActivatorUtilities.CreateInstance<ScaledResolutionComponent>(sp, (IDrawable)innerDrawable, (IUpdateable)innerDrawable);
                return instance;
            });           

            builder.AddSingleton<ISpaceShip, SpaceShip>();
            builder.AddSingleton<IScoreBoard, ScoreBoard>();

            builder.AddSpriteBatchComponents((o) =>
            {
                o.AddSingleton<MainGameSpriteBatchComponent>();
            });

            return builder.BuildServiceProvider();
        }
    }
}


