using MsRenderTarget2D = Microsoft.Xna.Framework.Graphics.RenderTarget2D;

namespace MonoGame.Base.Graphics
{
    public class RenderTarget2D : Texture2D, IRenderTarget2D
    {
        public RenderTarget2D(MsRenderTarget2D renderTarget) : base(renderTarget)
        {
            Unwrapped = renderTarget;
        }

        internal new MsRenderTarget2D Unwrapped { get; set; }
    }
}
