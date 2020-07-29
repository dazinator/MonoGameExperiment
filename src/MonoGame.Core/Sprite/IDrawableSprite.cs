using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;

namespace MonoGame.Core.Sprite
{
    public interface ISpriteBatchDrawable : IUpdateable, IDrawable
    {
        ISpriteBatch SpriteBatch { get; set; } 
    }   
}
