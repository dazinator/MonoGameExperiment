using Microsoft.Xna.Framework;
using MonoGame.Base.Sprite;
using MonoGame.Extended;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : IMovable, ISprite
    {       
        Color Color { get; set; }
    }


}
