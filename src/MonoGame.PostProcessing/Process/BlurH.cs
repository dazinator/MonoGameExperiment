using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing;

namespace MonoGame.PostProcessing.Process
{
    public class BlurH : BasePostProcess
    {
        float blurAmount = 1;
        public BlurH(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float amount) : base(graphicsDevice, spriteBatch)
        {
            blurAmount = amount;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
            {
                effect = Game.Content.Load<Effect>("Shaders/blur");
                effect.CurrentTechnique = effect.Techniques["BlurH"];
            }

            effect.Parameters["g_BlurAmount"].SetValue(blurAmount);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}