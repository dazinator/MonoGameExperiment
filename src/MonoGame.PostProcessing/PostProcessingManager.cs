using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.PostProcessing
{
    public class PostProcessingManager : DrawableGameComponent, IPostProcessingManager
    {

        private List<BasePostProcessingEffect> _Effects;

        public PostProcessingManager(Game game, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch)
            : base(game)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
            _Effects = new List<BasePostProcessingEffect>();

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public ITexture2D OriginalScene { get; set; }
        public ITexture2D OutputScene { get; set; }
        public ITexture2D DepthBuffer { get; set; }
        public Vector2 HalfPixel { get; set; }
        public new IGraphicsDevice GraphicsDevice { get; }
        public ISpriteBatch SpriteBatch { get; }

        #region IPostProcessingManager

        public void AddEffect(BasePostProcessingEffect effect)
        {
            _Effects.Add(effect);
        }

        public T GetEffect<T>() where T : BasePostProcessingEffect
        {
            return (T)(_Effects.Where(e => e is T).Single());
        }

        public IList<T> GetEffects<T>() where T : BasePostProcessingEffect
        {
            return (IList<T>)(_Effects.Where(e => e is T).ToList());
        }

        #endregion

        #region "IDrawableGameComponent"

        public override void Draw(GameTime gameTime)
        {

            //Resolve targets.
            GraphicsDevice.SetRenderTarget(null);

            if (HalfPixel == Vector2.Zero)
                HalfPixel = -new Vector2(.5f / (float)GraphicsDevice.Viewport.Width,
                                     .5f / (float)GraphicsDevice.Viewport.Height);

            int maxEffect = _Effects.Count;

            OutputScene = OriginalScene;

            for (int e = 0; e < maxEffect; e++)
            {
                if (_Effects[e].Visible)
                {
                    if (_Effects[e].HalfPixel == Vector2.Zero)
                    {
                        _Effects[e].HalfPixel = HalfPixel;
                    }                       

                    _Effects[e].OrgScene = OriginalScene;
                    _Effects[e].Scene = OutputScene;
                    _Effects[e].Depth = DepthBuffer;

                    _Effects[e].Draw(gameTime);
                    OutputScene = _Effects[e].LastScene;
                }
            }


            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            SpriteBatch.Draw(OutputScene, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            SpriteBatch.End();
        }

        #endregion
    }
}
