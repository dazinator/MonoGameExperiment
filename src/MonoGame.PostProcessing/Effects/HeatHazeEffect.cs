using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class HeatHazeEffect : BasePostProcessingEffect
    {
        public BumpmapDistort BumpmapDistort { get; set; }

        public HeatHazeEffect(IContentManager contentManager, IGraphicsDevice device, ISpriteBatch spriteBatch, string bumpasset, bool high) : base(device, spriteBatch)
        {
            BumpmapDistort = new BumpmapDistort(contentManager, device, spriteBatch, bumpasset, high);
            AddPostProcess(BumpmapDistort);
        }
    }
}