using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Effects;

namespace MonoGame.PostProcessing.Process
{
    public class DepthOfField : BasePostProcess
    {
        public float FocusDistance = 50;
        public float FocusRange = 5;

        public DepthOfField(IContentManager contentManager, 
            IGraphicsDevice graphicsDevice,
            ISpriteBatch spriteBatch,
            ICamera camera) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            Camera = camera;
        }

        public IContentManager ContentManager { get; }
        public ICamera Camera { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
                Effect = ContentManager.LoadEffect("Shaders/DepthOfField");

            OrgBuffer.SetEffect(Effect.Parameters["SceneTex"]);
            DepthBuffer.SetEffect(Effect.Parameters["SceneDepthTex"]);
          
            Effect.Parameters["DoFParams"].SetValue(new Vector4(FocusDistance, FocusRange,
                Camera.Viewport.MinDepth, Camera.Viewport.MaxDepth / (Camera.Viewport.MaxDepth - Camera.Viewport.MinDepth)));

            // Set Params.
            base.Draw(gameTime);
        }
    }
}