using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class RippleEffect : BasePostProcessingEffect
    {
        public Ripple Ripple { get; set; }

        public RippleEffect(IContentManager contentManager, IGraphicsDevice device, ISpriteBatch spriteBatch) : base(device, spriteBatch)
        {
            Ripple = new Ripple(contentManager, device, spriteBatch);
            AddPostProcess(Ripple);
        }
    }
}