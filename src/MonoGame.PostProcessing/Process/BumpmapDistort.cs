using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BumpmapDistort : BasePostProcess
    {
        private double elapsedTime = 0;
        public bool High = true;
        public string BumpAsset;

        public IContentManager ContentManager { get; }

        public ITexture2D BumpmapTexture { get; set; }

        public BumpmapDistort(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, string bumpAsset, bool high) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            BumpAsset = bumpAsset;
            High = high;
        }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
            {
                Effect = ContentManager.LoadEffect("Shaders/BumpMapDistort");
            }
            if(BumpmapTexture == null)
            {
                BumpmapTexture = ContentManager.LoadTexture2D(BumpAsset);
            }

            if (High)
            {
                Effect.CurrentTechnique = Effect.Techniques["High"];
            }               
            else
            {
                Effect.CurrentTechnique = Effect.Techniques["Low"];
            }               

            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= 10.0f)
                elapsedTime = 0.0f;

            Effect.Parameters["Offset"].SetValue((float)elapsedTime * .1f);
            BumpmapTexture.SetEffect(Effect.Parameters["Bumpmap"]);

            Effect.Parameters["halfPixel"].SetValue(HalfPixel);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}