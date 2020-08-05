using Microsoft.Xna.Framework;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class RadialBlurEffect : BasePostProcessingEffect
    {
        public RadialBlur rb;

        public RadialBlurEffect(Game game, float scale) : base(game)
        {
            rb = new RadialBlur(game, scale);

            AddPostProcess(rb);
        }
    }
}