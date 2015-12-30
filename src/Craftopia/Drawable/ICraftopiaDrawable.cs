using Craftopia.MonoGame;
using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    public interface ICraftopiaDrawable
    {
        void Update(GameTime gameTime);
        void Draw(ISpriteBatch spriteBatch, GameTime gameTime);      
    }
}
