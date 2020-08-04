using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;
using System;

namespace Craftopia
{
    public class ScaledResolutionComponent : DrawableGameComponent
    {
        private readonly IGraphicsDevice _graphicsDevice;

        public ScaledResolutionComponent(Game game,
            IGraphicsDevice graphicsDevice,
            ISpriteBatch spriteBatch,
            IDrawable innerDrawable, 
            IUpdateable innerUpdateable) : base(game)
        {
            _graphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
            InnerDrawable = innerDrawable;
            InnerUpdateable = innerUpdateable;
            RenderScale = 1.0f;
            RenderScreenHeight = 1080;
        }

        public Vector2 GetScaledResolution()
        {
            var scaledHeight = (float)RenderScreenHeight / RenderScale;
            return new Vector2(GetAspectRatio() * scaledHeight, scaledHeight);
        }

        /// <summary>
        /// The width of the game’s back buffer divided by the height of the game’s back buffer.
        /// </summary>
        /// <remarks>
        /// Any time the back buffer size or the _renderScale value changes, you’ll want to recalculate the size of your game’s render target and recreate it so that the settings take effect properly. 
        /// Then you simply write a UI that allows the user to change their GUI scale (which really just changes the _renderScale value) and you’re basically good to go.
        /// </remarks>
        public float GetAspectRatio()
        {
            return (float)_graphicsDevice.PresentationParameters.BackBufferWidth / _graphicsDevice.PresentationParameters.BackBufferHeight;
        }

        /// <summary>  
        /// Ratio for how much of the base vertical resolution you want to render at.
        /// 1.0 means render at renderScreenHeight, 0.5 means render at 2x renderScreenHeight, 2.0 means render at renderScreenHeight/2.
        /// </summary>
        /// <remarks>
        /// Any time the back buffer size or the _renderScale value changes, you’ll want to recalculate the size of your game’s render target and recreate it so that the settings take effect properly. 
        /// Then you simply write a UI that allows the user to change their GUI scale (which really just changes the _renderScale value) and you’re basically good to go.
        /// </remarks>
        public float RenderScale { get; set; }

        /// <summary>
        /// The base vertical resolution you want to render at.
        /// </summary>
        public int RenderScreenHeight { get; set; }

        public Lazy<RenderTarget2D> RenderTarget { get; set; }

        public void ResetRenderTarget()
        {
            RenderTarget = new Lazy<RenderTarget2D>(() =>
            {
                var scaledResolution = GetScaledResolution();
                return _graphicsDevice.CreateRenderTarget((int)scaledResolution.X, (int)scaledResolution.Y);
            });
        }

        public int Width { get; }
        public int Height { get; }
        public ISpriteBatch SpriteBatch { get; }
        public IDrawable InnerDrawable { get; set; }

        public IUpdateable InnerUpdateable { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            ResetRenderTarget();
        }

        public override void Draw(GameTime gameTime)
        {
            //   _scale = 1f / (1080f / Game.GraphicsDevice.Viewport.Height);

            // draw sprites in sprite batch component to render target first.
           
            _graphicsDevice.SetRenderTarget(RenderTarget.Value);
            _graphicsDevice.Clear(Color.CornflowerBlue);

            InnerDrawable.Draw(gameTime);

            _graphicsDevice.SetRenderTarget(null);
           // _graphicsDevice.Clear(Color.Transparent);
            _graphicsDevice.Clear(Color.CornflowerBlue);

            // now draw render target.
            SpriteBatch.Begin();

            SpriteBatch.Draw(RenderTarget.Value, Vector2.Zero, null, Color.White);

            SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            //base.Update(gameTime);
            InnerUpdateable?.Update(gameTime);
        }
    }
}