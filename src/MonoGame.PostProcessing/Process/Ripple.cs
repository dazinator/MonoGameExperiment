using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class Ripple : BasePostProcess
    {
        float divisor = .5f;
        float distortion = 2.5f;

        public Ripple(IContentManager contentManager,IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
        }

        public IContentManager ContentManager { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
                Effect = ContentManager.LoadEffect("Shaders/Ripple");

            if (divisor > 1.25f)
                divisor = .4f;

            divisor += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;

            Effect.Parameters["wave"].SetValue(MathHelper.Pi / divisor);
            Effect.Parameters["distortion"].SetValue(distortion);
            Effect.Parameters["centerCoord"].SetValue(new Vector2(.5f, .5f));

            // Set Params.
            base.Draw(gameTime);
        }
    }
}