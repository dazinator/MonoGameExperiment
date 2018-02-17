using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    public interface ISpaceShip : ISpriteBatchDrawable
    {
        Vector2 Position { get; set; }
        Color Color { get; set; }
    }


}
