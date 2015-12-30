using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Craftopia.MonoGame;
using Craftopia.Drawable;

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
        private ISpaceShip _spaceShip;
        private IScoreBoard _scoreBoard;

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
            _spriteBatch = Resolve<ISpriteBatch>();
            _spaceShip = Resolve<ISpaceShip>();
            _scoreBoard = Resolve<IScoreBoard>();         

        }

        protected virtual T Resolve<T>()
        {
            return _resolver.Resolve<T>();
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

            _spaceShip.Update(gameTime);
            _scoreBoard.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            //spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            _spaceShip.Draw(_spriteBatch, gameTime);
            _scoreBoard.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
