using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class DepthOfFieldEffect : BasePostProcessingEffect
    {
        public PoissonDiscBlur pdb;
        public DepthOfField dof;

        public DepthOfFieldEffect(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, float startFocusDistance, float startFocusRange) : base(graphicsDevice, spriteBatch)
        {
            pdb = new PoissonDiscBlur(game);
            dof = new DepthOfField(game);
            dof.FocusDistance = startFocusDistance;
            dof.FocusRange = startFocusRange;

            AddPostProcess(pdb);
            AddPostProcess(dof);
        }

        public float FocalDistance
        {
            get { return dof.FocusDistance; }
            set { dof.FocusDistance = MathHelper.Clamp(value, camera.Viewport.MinDepth, camera.Viewport.MaxDepth); }
        }

        public float FocalRange
        {
            get { return dof.FocusRange; }
            set { dof.FocusRange = MathHelper.Clamp(value, camera.Viewport.MinDepth, camera.Viewport.MaxDepth); }
        }
    }
}