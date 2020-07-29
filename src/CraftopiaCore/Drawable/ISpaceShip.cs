using Microsoft.Xna.Framework;
using MonoGame.Core.Sprite;
using MonoGame.Extended;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : IMovable, IDrawable
    {       
        Color Color { get; set; }
    }


}
