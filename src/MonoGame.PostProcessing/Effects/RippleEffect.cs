using Microsoft.Xna.Framework;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class RippleEffect : BasePostProcessingEffect
    {
        public Ripple r;

        public RippleEffect(Game game) : base(game)
        {
            r = new Ripple(game);

            AddPostProcess(r);
        }
    }
}