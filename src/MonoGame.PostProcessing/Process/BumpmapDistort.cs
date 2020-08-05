using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class BumpmapDistort : BasePostProcess
    {
        private double elapsedTime = 0;
        public bool High = true;
        public string BumpAsset;

        public BumpmapDistort(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, string bumpAsset, bool high) : base(graphicsDevice, spriteBatch)
        {
            BumpAsset = bumpAsset;
            High = high;
        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
            {
                effect = Game.Content.Load<Effect>("Shaders/BumpMapDistort");
            }

            if (High)
                effect.CurrentTechnique = effect.Techniques["High"];
            else
                effect.CurrentTechnique = effect.Techniques["Low"];

            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= 10.0f)
                elapsedTime = 0.0f;

            effect.Parameters["Offset"].SetValue((float)elapsedTime * .1f);
            effect.Parameters["Bumpmap"].SetValue(Game.Content.Load<Texture2D>(BumpAsset));

            effect.Parameters["halfPixel"].SetValue(HalfPixel);

            // Set Params.
            base.Draw(gameTime);
        }
    }
}