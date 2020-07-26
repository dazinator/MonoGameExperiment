using Microsoft.Xna.Framework;
using MonoGame.Core.Sprite;
using MonoGame.Extended;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : IDrawableSprite, IMovable
    {       
        Color Color { get; set; }
    }


}
