using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsGraphicsDevice = Microsoft.Xna.Framework.Graphics.GraphicsDevice;

namespace MonoGame.Base.Graphics
{
    public class GraphicsDevice : IGraphicsDevice
    {
        private readonly MsGraphicsDevice _graphicsDevice;

        public GraphicsDevice(MsGraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public PresentationParameters PresentationParameters => _graphicsDevice.PresentationParameters;

        internal MsGraphicsDevice Unwrapped => _graphicsDevice;

        public void Clear(Color color)
        {
            _graphicsDevice.Clear(color);
        }

        public void Clear(ClearOptions options, Color color, float depth, int stencil)
        {
            _graphicsDevice.Clear(options, color, depth, stencil);
        }

        public void Clear(ClearOptions options, Vector4 color, float depth, int stencil)
        {
            _graphicsDevice.Clear(options, color, depth, stencil);
        }

        public RenderTarget2D CreateRenderTarget(int width, int height)
        {
            var renderTarget = new Microsoft.Xna.Framework.Graphics.RenderTarget2D(Unwrapped, width, height);
            return new RenderTarget2D(renderTarget);
        }

        public void SetRenderTarget(RenderTarget2D renderTarget)
        {
            _graphicsDevice.SetRenderTarget(renderTarget?.Unwrapped);
        }

    }
}
