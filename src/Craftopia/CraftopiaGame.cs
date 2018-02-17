using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Craftopia.MonoGame;
using System.Collections.Generic;

namespace Craftopia
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CraftopiaGame : Game, ICraftopiaGame
    {
        GraphicsDeviceManager _graphics;

        private ISpriteBatch _spriteBatch;
        private IResolverProvider _resolverProvider;
        private IResolver _resolver;       

        public CraftopiaGame(IResolverProvider resolverProvider)
        {
            _resolverProvider = resolverProvider;
            _graphics = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _resolver = _resolverProvider.GetResolver(this);           

            var components = ResolveComponents();
            foreach (var component in components)
            {
                Components.Add(component);
            }

        }

        //protected virtual T Resolve<T>()
        //{
        //    return _resolver.Resolve<T>();
        //}

        protected virtual IEnumerable<IGameComponent> ResolveComponents()
        {
            return _resolver.ResolveAll<IGameComponent>();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();         

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
