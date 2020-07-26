using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;

namespace MonoGame.Core.Graphics
{
    public class SpriteFont : ISpriteFont
    {
        private MsSpriteFont _font;

        public SpriteFont(MsSpriteFont font)
        {
            _font = font;
            _lazyTexture = new Lazy<ITexture2D>(() => new Texture2D(_font.Texture));
        }

        public ReadOnlyCollection<char> Characters
        {
            get
            {
                return _font.Characters;
            }
        }

        public char? DefaultCharacter
        {
            get
            {
                return _font.DefaultCharacter;
            }

            set
            {
                _font.DefaultCharacter = value;
            }
        }

        public int LineSpacing
        {
            get
            {
                return _font.LineSpacing;
            }

            set
            {
                _font.LineSpacing = value;
            }
        }

        public float Spacing
        {
            get
            {
                return _font.Spacing;
            }

            set
            {
                _font.Spacing = value;
            }
        }

        private Lazy<ITexture2D> _lazyTexture;
        public ITexture2D Texture
        {
            get
            {
                return _lazyTexture.Value;
            }
        }

        private MsSpriteFont Unwrapped
        {
            get
            {
                return _font;
            }
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color);
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder stringBuilder, Vector2 position, Color color)
        {
            spriteBatch.DrawString(Unwrapped, stringBuilder, position, color);
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public Dictionary<char, MsSpriteFont.Glyph> GetGlyphs()
        {
            return _font.GetGlyphs();
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            return _font.MeasureString(text);
        }

        public Vector2 MeasureString(string text)
        {
            return _font.MeasureString(text);
        }
    }
}
