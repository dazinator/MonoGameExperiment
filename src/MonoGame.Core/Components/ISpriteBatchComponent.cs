using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Core.Components
{
    public interface ISpriteBatchComponent : IDrawable, IGameComponent, IUpdateable, IDisposable
    {
        void AddDrawable(IDrawable drawable);
        void RemoveDrawable(IDrawable drawable);        
    }
}
