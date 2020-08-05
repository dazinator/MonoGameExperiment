using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class Fog : BasePostProcess
    {
        public float FogDistance;
        public float FogRange;
        public Color FogColor;

        public Fog(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float distance, float range, Color color) : base(graphicsDevice, spriteBatch)
        {
            FogDistance = distance;
            FogRange = range;
            FogColor = color;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
                effect = Game.Content.Load<Effect>("Shaders/Fog");

            effect.Parameters["depthMap"].SetValue(DepthBuffer);
            effect.Parameters["camMin"].SetValue(camera.Viewport.MinDepth);
            effect.Parameters["camMax"].SetValue(camera.Viewport.MaxDepth);
            effect.Parameters["fogDistance"].SetValue(FogDistance);
            effect.Parameters["fogRange"].SetValue(FogRange);
            effect.Parameters["fogColor"].SetValue(FogColor.ToVector4());

            // Set Params.
            base.Draw(gameTime);
        }
    }
}