using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class RadialBlur : BasePostProcess
    {
        public float Scale;

        public RadialBlur(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float scale) : base(graphicsDevice, spriteBatch)
        {
            Scale = scale;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
                effect = Game.Content.Load<Effect>("Shaders/RadialBlur");


            effect.Parameters["radialBlurScaleFactor"].SetValue(Scale);
            effect.Parameters["windowSize"].SetValue(new Vector2(BackBuffer.Height, BackBuffer.Width));

            // Set Params.
            base.Draw(gameTime);
        }
    }
}