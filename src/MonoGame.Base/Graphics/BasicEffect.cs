using MSBasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;

namespace MonoGame.Base.Graphics
{
    public class BasicEffect : Effect
    {
        public BasicEffect(MSBasicEffect effect) : base(effect)
        {

        }

        internal new MSBasicEffect Unwrapped { get; }
    }
}
