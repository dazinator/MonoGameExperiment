using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BlurV : BasePostProcess
    {
        float blurAmount = 1;
        public BlurV(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float amount) : base(graphicsDevice, spriteBatch)
        {
            blurAmount = amount;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
            {
                effect = Game.Content.Load<Effect>("Shaders/blur");
                effect.CurrentTechnique = effect.Techniques["BlurV"];
            }
            effect.Parameters["g_BlurAmount"].SetValue(blurAmount);
            // Set Params.
            base.Draw(gameTime);
        }
    }
}