using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Base.Components
{
    public interface ISpriteBatchComponent : IDrawable, IGameComponent, IUpdateable, IDisposable
    {
        void Register(IDrawable drawable);
        void Unregister(IDrawable drawable);        
    }
}
