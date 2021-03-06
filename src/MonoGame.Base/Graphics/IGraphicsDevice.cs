﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Base.Graphics
{
    public interface IGraphicsDevice
    {
        void SetRenderTarget(RenderTarget2D renderTarget);
        void Clear(Color color);
        void Clear(ClearOptions options, Color color, float depth, int stencil);
        void Clear(ClearOptions options, Vector4 color, float depth, int stencil);
        PresentationParameters PresentationParameters { get;}
        RenderTarget2D CreateRenderTarget(int width, int height);
      
    }
}
