using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BrightPass : BasePostProcess
    {
        public float BloomThreshold;
        public BrightPass(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float threshold) : base(graphicsDevice, spriteBatch)
        {
            BloomThreshold = threshold;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
            {
                effect = Game.Content.Load<Effect>("Shaders/BrightPass");
            }

            effect.Parameters["BloomThreshold"].SetValue(BloomThreshold);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}