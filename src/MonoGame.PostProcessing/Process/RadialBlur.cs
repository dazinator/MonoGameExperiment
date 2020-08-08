using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class RadialBlur : BasePostProcess
    {
        public float Scale;

        public RadialBlur(IContentManager content, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float scale) : base(graphicsDevice, spriteBatch)
        {
            Content = content;
            Scale = scale;
        }

        public IContentManager Content { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
                Effect = Content.LoadEffect("Shaders/RadialBlur");


            Effect.Parameters["radialBlurScaleFactor"].SetValue(Scale);
            Effect.Parameters["windowSize"].SetValue(new Vector2(BackBuffer.Height, BackBuffer.Width));

            // Set Params.
            base.Draw(gameTime);
        }
    }
}