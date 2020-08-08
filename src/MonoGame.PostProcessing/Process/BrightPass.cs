using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BrightPass : BasePostProcess
    {
        public float BloomThreshold;
        public BrightPass(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float threshold) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            BloomThreshold = threshold;
        }

        public IContentManager ContentManager { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
            {
                Effect = ContentManager.LoadEffect("Shaders/BrightPass");
            }

            Effect.Parameters["BloomThreshold"].SetValue(BloomThreshold);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}