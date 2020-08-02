using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace MonoGame.Base.Graphics
{
    public interface ITexture2D
    {
        Rectangle Bounds { get; }
        int Height { get; }
        int Width { get; }
        void GetData<T>(T[] data) where T : struct;
        void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct;
        void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;        
        void GetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;
        void Reload(Stream textureStream);
        void SaveAsJpeg(Stream stream, int width, int height);
        void SaveAsPng(Stream stream, int width, int height);
        void SetData<T>(T[] data) where T : struct;
        void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct;
        void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;
        void SetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;

        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Color color);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);

        // Texture2D Unwrapped { get; }
    }
}