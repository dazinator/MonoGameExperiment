using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;

namespace MonoGame.Core.Sprite
{
    public interface ISprite : IUpdateable, IDrawable
    {
        ISpriteBatch SpriteBatch { get; set; } 
    }   
}
