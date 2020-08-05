using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base;
using MonoGame.Base.Graphics;
using Effect = MonoGame.Base.Graphics.Effect;

namespace MonoGame.PostProcessing.Process
{
    public class BasePostProcess : BaseDrawable
    {

        public BasePostProcess(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
        }

        public Vector2 HalfPixel
        {
            get; set;
        }

        //public Camera camera
        //{
        //    get { return (Camera)Game.Services.GetService(typeof(Camera)); }
        //}

        public ISpriteBatch SpriteBatch
        {
            get;
        }
        public IGraphicsDevice GraphicsDevice { get; }
        public ITexture2D DepthBuffer
        {
            get; set;
        }
        public ITexture2D BackBuffer
        {
            get; set;
        }
        public ITexture2D OrgBuffer
        {
            get; set;
        }

        public SpriteSortMode SortMode { get; set; } = SpriteSortMode.Immediate;
        public BlendState Blend { get; set; } = BlendState.Opaque;
        public SamplerState Sampler { get; set; } = SamplerState.AnisotropicClamp;
        protected Effect Effect { get; set; }
        public Base.Graphics.RenderTarget2D NewScene { get; set; }

        public override void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                SpriteBatch.Begin(SortMode, Blend, Sampler, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                Effect.CurrentTechnique.Passes[0].Apply();
                SpriteBatch.Draw(BackBuffer, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                SpriteBatch.End();
            }
        }
    }
}
