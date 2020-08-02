using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;

namespace MonoGame.Base.Sprite
{
    public interface ISprite : IUpdateable, IDrawable
    {
        ISpriteBatch SpriteBatch { get; set; } 
    }   
}
