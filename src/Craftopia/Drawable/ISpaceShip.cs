using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : ICraftopiaDrawable
    {
        Vector2 Position { get; set; }
        Color Color { get; set; }
    }


}
