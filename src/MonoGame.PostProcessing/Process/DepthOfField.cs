using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;

namespace MonoGame.PostProcessing.Process
{
    public class DepthOfField : BasePostProcess
    {
        public float FocusDistance = 50;
        public float FocusRange = 5;

        public DepthOfField(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch) : base(graphicsDevice, spriteBatch)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            if (effect == null)
                effect = Game.Content.Load<Effect>("Shaders/DepthOfField");

            effect.Parameters["SceneTex"].SetValue(orgBuffer);
            effect.Parameters["SceneDepthTex"].SetValue(DepthBuffer);
            effect.Parameters["DoFParams"].SetValue(new Vector4(FocusDistance, FocusRange, camera.Viewport.MinDepth, camera.Viewport.MaxDepth / (camera.Viewport.MaxDepth - camera.Viewport.MinDepth)));

            // Set Params.
            base.Draw(gameTime);
        }
    }
}