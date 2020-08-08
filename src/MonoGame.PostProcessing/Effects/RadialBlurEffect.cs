using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class RadialBlurEffect : BasePostProcessingEffect
    {
        public RadialBlur RadialBlur { get; set; }

        public RadialBlurEffect(IContentManager contentManager, IGraphicsDevice device, ISpriteBatch spriteBatch, float scale) : base(device, spriteBatch)
        {
            RadialBlur = new RadialBlur(contentManager, device, spriteBatch, scale);
            AddPostProcess(RadialBlur);
        }
    }
}