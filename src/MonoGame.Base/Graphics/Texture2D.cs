using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace MonoGame.Base.Graphics
{
    public class Texture2D : ITexture2D
    {
        private MsTexture2D _texture2d;

        public Texture2D(MsTexture2D texture2d)
        {
            Texture2d = texture2d;
        }

        public Rectangle Bounds
        {
            get
            {
                return Texture2d.Bounds;
            }
        }

        public int Height
        {
            get
            {
                return Texture2d.Height;
            }
        }

        public int Width
        {
            get
            {
                return Texture2d.Width;
            }
        }

        public void GetData<T>(T[] data) where T : struct
        {
            Texture2d.GetData<T>(data);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.GetData<T>(data, startIndex, elementCount);
        }

        public void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.GetData<T>(level, rect, data, startIndex, elementCount);
        }

        public void GetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.GetData<T>(level, arraySlice, rect, data, startIndex, elementCount);
        }

        public void Reload(Stream textureStream)
        {
            Texture2d.Reload(textureStream);
        }

        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            Texture2d.SaveAsJpeg(stream, width, height);
        }

        public void SaveAsPng(Stream stream, int width, int height)
        {
            Texture2d.SaveAsPng(stream, width, height);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            Texture2d.SetData(data);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.SetData(data, startIndex, elementCount);
        }

        public void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.SetData(level, rect, data, startIndex, elementCount);
        }

        public void SetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Texture2d.SetData(level, arraySlice, rect, data, startIndex, elementCount);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Unwrapped, position, color);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteBatch.Draw(Unwrapped, destinationRectangle, color);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            spriteBatch.Draw(Unwrapped, position, sourceRectangle, color);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            spriteBatch.Draw(Unwrapped, destinationRectangle, sourceRectangle, color);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(Unwrapped, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(Unwrapped, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(Unwrapped, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }

        protected virtual MsTexture2D Unwrapped { get { return Texture2d; } }

        internal MsTexture2D Texture2d { get => _texture2d; set => _texture2d = value; }


        //public static implicit operator Texture2DWrapper(Texture2D texture2d)  // implicit texture2d to Texture2DWrapper conversion operator
        //{
        //    return new Texture2DWrapper(texture2d);
        //}

        public static explicit operator Texture2D(MsTexture2D texture2d)  // explicit texture2d to Texture2DWrapper conversion operator
        {
            return new Texture2D(texture2d);
        }
    }
}
