using Microsoft.Xna.Framework;
using MSBasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;

namespace MonoGame.Base.Graphics
{
    public class BasicEffect : Effect
    {
        public BasicEffect(MSBasicEffect effect) : base(effect)
        {

        }

        public Matrix View
        {
            get { return Unwrapped.View; }
            set { Unwrapped.View = value; }
        }

        public bool VertexColorEnabled
        {
            get { return Unwrapped.VertexColorEnabled; }
            set { Unwrapped.VertexColorEnabled = value; }
        }

        public Matrix World
        {
            get { return Unwrapped.World; }
            set { Unwrapped.World = value; }
        }

        public Matrix Projection
        {
            get { return Unwrapped.Projection; }
            set { Unwrapped.Projection = value; }
        }
        internal new MSBasicEffect Unwrapped { get; }
    }
}
