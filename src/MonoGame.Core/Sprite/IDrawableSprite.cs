using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;

namespace MonoGame.Core.Sprite
{
    public interface IDrawableSprite : IUpdateable
    {     
        void Draw(ISpriteBatch spriteBatch, GameTime gameTime);      
    }   
}
