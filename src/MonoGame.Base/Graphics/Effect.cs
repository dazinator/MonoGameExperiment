using Microsoft.Xna.Framework.Graphics;
using System;
using MSEffect = Microsoft.Xna.Framework.Graphics.Effect;

namespace MonoGame.Base.Graphics
{
    public class Effect : IDisposable
    {
        public Effect(MSEffect effect)
        {
            Unwrapped = effect;
        }

        internal MSEffect Unwrapped { get; }

        public EffectParameterCollection Parameters { get { return Unwrapped.Parameters; } }
        public EffectTechniqueCollection Techniques { get { return Unwrapped.Techniques; } }
        public EffectTechnique CurrentTechnique
        {
            get { return Unwrapped.CurrentTechnique; }
            set { Unwrapped.CurrentTechnique = value; }
        }

        public void Dispose()
        {
            Unwrapped?.Dispose();
        }
    }
}
