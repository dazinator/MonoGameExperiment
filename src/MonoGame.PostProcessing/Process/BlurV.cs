using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BlurV : BasePostProcess
    {
        float blurAmount = 1;
        public BlurV(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float amount) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            blurAmount = amount;
        }

        public IContentManager ContentManager { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
            {
                Effect = ContentManager.LoadEffect("Shaders/blur");
                Effect.CurrentTechnique = Effect.Techniques["BlurV"];
            }
            Effect.Parameters["g_BlurAmount"].SetValue(blurAmount);
            // Set Params.
            base.Draw(gameTime);
        }
    }
}