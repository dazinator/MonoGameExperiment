using System;
using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Craftopia.MonoGame
{
    [Register()]
    public class CraftopiaSpriteBatch : SpriteBatch, ISpriteBatch
    {
        public CraftopiaSpriteBatch(GraphicsDevice device) : base(device)
        {

        }     

        public void Draw(ITexture2D texture, Vector2 position, Color color)
        {
            texture.Draw(this, position, color);         
        }
    }
}
