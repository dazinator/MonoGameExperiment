﻿using System.Text;
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
            Draw(texture.Unwrapped, position, color);          
        }

        public void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color color)
        {           
            DrawString(spriteFont.Unwrapped, text, position, color);
        }

        public void DrawString(ISpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            DrawString(spriteFont.Unwrapped, text, position, color);
        }
    }
}