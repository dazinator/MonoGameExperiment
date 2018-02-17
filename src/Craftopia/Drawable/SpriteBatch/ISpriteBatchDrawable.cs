using Craftopia.MonoGame;
using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    public interface ISpriteBatchDrawable : IUpdateable
    {     
        void Draw(ISpriteBatch spriteBatch, GameTime gameTime);      
    }
}
