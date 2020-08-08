using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Base.Graphics
{
    public interface IGraphicsDevice
    {
        void SetRenderTarget(RenderTarget2D renderTarget);
        void Clear(Color color);
        void Clear(ClearOptions options, Color color, float depth, int stencil);
        void Clear(ClearOptions options, Vector4 color, float depth, int stencil);
        PresentationParameters PresentationParameters { get; }
        RenderTarget2D CreateRenderTarget(int width, int height);
        RenderTarget2D CreateRenderTarget(int width, int height, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat);
        Viewport Viewport { get; set; }
        BlendState BlendState { get; set; }
        DepthStencilState DepthStencilState { get; set; }
        SamplerStateCollection SamplerStates { get; }

        BasicEffect CreateBasicEffect();
        OcclusionQuery CreateOcclusionQuery();
        void DrawUserPrimitives(PrimitiveType triangleStrip, VertexPositionColor[] queryVertices, int v1, int v2);
    }
}
