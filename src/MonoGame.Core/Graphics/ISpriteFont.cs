using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MsSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;

namespace MonoGame.Core.Graphics
{
    public interface ISpriteFont
    {

        //
        // Summary:
        //     Gets a collection of the characters in the font.
        ReadOnlyCollection<char> Characters { get; }
        //
        // Summary:
        //     Gets or sets the character that will be substituted when a given character is
        //     not included in the font.
        char? DefaultCharacter { get; set; }


        //
        // Summary:
        //     Gets or sets the line spacing (the distance from baseline to baseline) of the
        //     font.
        int LineSpacing { get; set; }
        //
        // Summary:
        //     Gets or sets the spacing (tracking) between characters in the font.
        float Spacing { get; set; }
        //
        // Summary:
        //     Gets the texture that this SpriteFont draws from.
        //
        // Remarks:
        //     Can be used to implement custom rendering of a SpriteFont
        ITexture2D Texture { get; }

        //
        // Summary:
        //     Returns a copy of the dictionary containing the glyphs in this SpriteFont.
        //
        // Returns:
        //     A new Dictionary containing all of the glyphs inthis SpriteFont
        //
        // Remarks:
        //     Can be used to calculate character bounds when implementing custom SpriteFont
        //     rendering.
        Dictionary<char, MsSpriteFont.Glyph> GetGlyphs();
        //
        // Summary:
        //     Returns the size of a string when rendered in this font.
        //
        // Parameters:
        //   text:
        //     The text to measure.
        //
        // Returns:
        //     The size, in pixels, of 'text' when rendered in this font.
        Vector2 MeasureString(string text);
        //
        // Summary:
        //     Returns the size of the contents of a StringBuilder when rendered in this font.
        //
        // Parameters:
        //   text:
        //     The text to measure.
        //
        // Returns:
        //     The size, in pixels, of 'text' when rendered in this font.
        Vector2 MeasureString(StringBuilder text);


     //   SpriteFont Unwrapped { get; }

        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color);
        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder stringBuilder, Vector2 position, Color color);
        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void DrawString(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
    }
}
