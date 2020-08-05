using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class Bloom : BasePostProcess
    {
        public float BloomIntensity;
        public float BloomSaturation;
        public float BaseIntensity;
        public float BaseSaturation;

        public Bloom(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float intensity, float saturation, float baseIntensity, float baseSatration) : base(graphicsDevice, spriteBatch)
        {
            BloomIntensity = intensity;
            BloomSaturation = saturation;
            BaseIntensity = baseIntensity;
            BaseSaturation = baseSatration;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
            {
                effect = Game.Content.Load<Effect>("Shaders/Bloom");
                effect.CurrentTechnique = effect.Techniques["BloomComposite"];
            }
            effect.Parameters["SceneTex"].SetValue(orgBuffer);

            effect.Parameters["BloomIntensity"].SetValue(BloomIntensity);
            effect.Parameters["BloomSaturation"].SetValue(BloomSaturation);
            effect.Parameters["BaseIntensity"].SetValue(BaseIntensity);
            effect.Parameters["BaseSaturation"].SetValue(BaseSaturation);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}