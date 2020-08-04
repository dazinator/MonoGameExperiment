using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;
using System;

namespace MonoGame.Base.Components
{
    public interface ISpriteBatchComponent : IDrawable, IGameComponent, IUpdateable, IDisposable
    {
        ISpriteBatch SpriteBatch { get; }
        void Register(IDrawable drawable);
        void Unregister(IDrawable drawable);        
    }
}
