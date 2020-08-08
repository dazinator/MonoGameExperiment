using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Effects;

namespace MonoGame.PostProcessing.Process
{
    public class Fog : BasePostProcess
    {
        public float FogDistance;
        public float FogRange;
        public Color FogColor;

        public Fog(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, ICamera camera, float distance, float range, Color color) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            Camera = camera;
            FogDistance = distance;
            FogRange = range;
            FogColor = color;
        }

        public IContentManager ContentManager { get; }
        public ICamera Camera { get; }

        public override void Draw(GameTime gameTime)
        {
            if (Effect == null)
                Effect = ContentManager.LoadEffect("Shaders/Fog");

            DepthBuffer.SetEffect(Effect.Parameters["depthMap"]);
            Effect.Parameters["camMin"].SetValue(Camera.Viewport.MinDepth);
            Effect.Parameters["camMax"].SetValue(Camera.Viewport.MaxDepth);
            Effect.Parameters["fogDistance"].SetValue(FogDistance);
            Effect.Parameters["fogRange"].SetValue(FogRange);
            Effect.Parameters["fogColor"].SetValue(FogColor.ToVector4());

            // Set Params.
            base.Draw(gameTime);
        }
    }
}