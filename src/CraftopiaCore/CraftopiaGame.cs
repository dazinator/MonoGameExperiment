using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Core.DependencyInjection;
using MonoGame.Base.Components;
using System;

namespace Craftopia
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CraftopiaGame : Game, ICraftopiaGame
    {
        private readonly GraphicsDeviceManager _graphics;

        private IServiceProviderFactory _serviceProviderFactory;
        private IServiceProvider _serviceProvider;

        public CraftopiaGame(IServiceProviderFactory serviceProviderFactory)
        {
            _serviceProviderFactory = serviceProviderFactory;
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

            _serviceProvider = _serviceProviderFactory.GetServiceProvider(this);

            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;

            var resolutionRenderingComponent = GetService<ScaledResolutionComponent>();
            resolutionRenderingComponent.RenderScale = 1.0f;
            resolutionRenderingComponent.RenderScreenHeight = 1080;

            LoadComponent(resolutionRenderingComponent);
           
            base.Initialize();

            //_graphics.PreferredBackBufferWidth = 1280;
            //_graphics.PreferredBackBufferHeight = 720;
            //_graphics.ApplyChanges();          
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {         

            var spriteBatchComponent = GetService<ISpriteBatchComponent>();
            var screenManager = new MonoGame.Extended.Screens.ScreenManager();
            spriteBatchComponent.Register(screenManager);
        }

        private T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }      

        private void LoadComponent(IGameComponent component)
        {
            //if (component is ILoadContent)
            //{
            //    var contentComponent = (ILoadContent)component;
            //    contentComponent.LoadContent();
            //}

            Components.Add(component);
        }      

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            this.Content.Unload();
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
            base.Draw(gameTime);
        }
    }
}