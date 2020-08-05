using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;
using System.Collections.Generic;

namespace MonoGame.PostProcessing
{
    public interface IPostProcessingManager : IGameComponent, IUpdateable, IDrawable
    {
        void AddEffect(BasePostProcessingEffect effect);

        ITexture2D OriginalScene { get; set; }
        ITexture2D DepthBuffer { get; set; }
        ITexture2D OutputScene { get; set; }

        Vector2 HalfPixel { get; set; }

        T GetEffect<T>() where T : BasePostProcessingEffect;
        IList<T> GetEffects<T>() where T : BasePostProcessingEffect;

    }
}
