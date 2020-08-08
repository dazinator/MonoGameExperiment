using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class Bloom : BasePostProcess
    {
        public float BloomIntensity;
        public float BloomSaturation;
        public float BaseIntensity;
        public float BaseSaturation;

        public Bloom(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float intensity, float saturation, float baseIntensity, float baseSatration) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            BloomIntensity = intensity;
            BloomSaturation = saturation;
            BaseIntensity = baseIntensity;
            BaseSaturation = baseSatration;
        }

        public IContentManager ContentManager { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
            {
                Effect = ContentManager.LoadEffect("Shaders/Bloom");
                Effect.CurrentTechnique = Effect.Techniques["BloomComposite"];
            }
            OrgBuffer.SetEffect(Effect.Parameters["SceneTex"]);

            Effect.Parameters["BloomIntensity"].SetValue(BloomIntensity);
            Effect.Parameters["BloomSaturation"].SetValue(BloomSaturation);
            Effect.Parameters["BaseIntensity"].SetValue(BaseIntensity);
            Effect.Parameters["BaseSaturation"].SetValue(BaseSaturation);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}