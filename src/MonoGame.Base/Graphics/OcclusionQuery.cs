using System;
using MSOcclusionQuery = Microsoft.Xna.Framework.Graphics.OcclusionQuery;

namespace MonoGame.Base.Graphics
{
    public class OcclusionQuery : IDisposable
    {
        public OcclusionQuery(MSOcclusionQuery occlusionQuery)
        {
            Unwrapped = occlusionQuery;
        }

        public MSOcclusionQuery Unwrapped { get; }
        public bool IsComplete { get { return Unwrapped.IsComplete; } }

        public int PixelCount { get { return Unwrapped.PixelCount; } }

        public void Dispose()
        {
            Unwrapped?.Dispose();
        }

        public void Begin()
        {
            Unwrapped.Begin();
        }

        public void End()
        {
            Unwrapped.End();
        }
    }
}
