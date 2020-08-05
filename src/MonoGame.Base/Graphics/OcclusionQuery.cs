using System;
using MSOcclusionQuery = Microsoft.Xna.Framework.Graphics.OcclusionQuery;

namespace MonoGame.Base.Graphics
{
    public class OcclusionQuery: IDisposable
    {
        public OcclusionQuery(MSOcclusionQuery occlusionQuery)
        {
            Unwrapped = occlusionQuery;
        }

        public MSOcclusionQuery Unwrapped { get; }

        public void Dispose()
        {
            Unwrapped?.Dispose();
        }
    }
}
