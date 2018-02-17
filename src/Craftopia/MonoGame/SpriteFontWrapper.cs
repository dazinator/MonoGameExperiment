using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Craftopia.MonoGame
{
    public class SpriteFontWrapper : ISpriteFont
    {
        private SpriteFont _font;

        public SpriteFontWrapper(SpriteFont font)
        {
            _font = font;
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

        public ITexture2D Texture
        {
            get
            {
                return new Texture2DWrapper(_font.Texture);
            }
        }

        private SpriteFont Unwrapped
        {
            get
            {
                return _font;
            }
        }

        public void DrawString(SpriteBatch spriteBatch, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(Unwrapped, text, position, color);
        }

        public void DrawString(SpriteBatch spriteBatch, StringBuilder stringBuilder, Vector2 position, Color color)
        {
            spriteBatch.DrawString(Unwrapped, stringBuilder, position, color);
        }

        public Dictionary<char, SpriteFont.Glyph> GetGlyphs()
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
