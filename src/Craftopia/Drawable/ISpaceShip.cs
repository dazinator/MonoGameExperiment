using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : ISpriteBatchDrawable, IMovable
    {       
        Color Color { get; set; }
    }


}
