using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class SunEffect : BasePostProcessingEffect
    {
        Sun sun;

        public Vector3 Position
        {
            get { return sun.Position; }
            set { sun.Position = value; }
        }

        public SunEffect(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, ICamera camera, Vector3 position) : base(graphicsDevice, spriteBatch)
        {
            sun = new Sun(contentManager, graphicsDevice, spriteBatch, camera, position);
            AddPostProcess(sun);
        }
    }
}