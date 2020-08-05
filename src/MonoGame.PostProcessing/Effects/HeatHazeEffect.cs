using Microsoft.Xna.Framework;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class HeatHazeEffect : BasePostProcessingEffect
    {
        public BumpmapDistort distort;

        public HeatHazeEffect(Game game, string bumpasset, bool high) : base(game)
        {
            distort = new BumpmapDistort(game, bumpasset, high);

            AddPostProcess(distort);
        }
    }
}