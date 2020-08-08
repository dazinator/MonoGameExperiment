using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class DepthOfFieldEffect : BasePostProcessingEffect
    {
        public PoissonDiscBlur pdb;
        public DepthOfField dof;

        public DepthOfFieldEffect(
            IContentManager contentManager,
            IGraphicsDevice graphicsDevice,
            ISpriteBatch spriteBatch, 
            ICamera camera,           
            float startFocusDistance,
            float startFocusRange) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            Camera = camera;
            pdb = new PoissonDiscBlur(ContentManager, graphicsDevice, spriteBatch);
            dof = new DepthOfField(ContentManager, graphicsDevice, spriteBatch, camera);
            dof.FocusDistance = startFocusDistance;
            dof.FocusRange = startFocusRange;

            AddPostProcess(pdb);
            AddPostProcess(dof);
            
        }

        public float FocalDistance
        {
            get { return dof.FocusDistance; }
            set { dof.FocusDistance = MathHelper.Clamp(value, Camera.Viewport.MinDepth, Camera.Viewport.MaxDepth); }
        }

        public float FocalRange
        {
            get { return dof.FocusRange; }
            set { dof.FocusRange = MathHelper.Clamp(value, Camera.Viewport.MinDepth, Camera.Viewport.MaxDepth); }
        }

        public IContentManager ContentManager { get; }
        public ICamera Camera { get; }
    }
}