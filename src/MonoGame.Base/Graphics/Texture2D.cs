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
            Unwrapped = texture2d;
        }

        public Rectangle Bounds
        {
            get
            {
                return Unwrapped.Bounds;
            }
        }

        public int Height
        {
            get
            {
                return Unwrapped.Height;
            }
        }

        public int Width
        {
            get
            {
                return Unwrapped.Width;
            }
        }

        public void GetData<T>(T[] data) where T : struct
        {
            Unwrapped.GetData<T>(data);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.GetData<T>(data, startIndex, elementCount);
        }

        public void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.GetData<T>(level, rect, data, startIndex, elementCount);
        }

        public void GetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.GetData<T>(level, arraySlice, rect, data, startIndex, elementCount);
        }

        public void Reload(Stream textureStream)
        {
            Unwrapped.Reload(textureStream);
        }

        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            Unwrapped.SaveAsJpeg(stream, width, height);
        }

        public void SaveAsPng(Stream stream, int width, int height)
        {
            Unwrapped.SaveAsPng(stream, width, height);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            Unwrapped.SetData(data);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.SetData(data, startIndex, elementCount);
        }

        public void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.SetData(level, rect, data, startIndex, elementCount);
        }

        public void SetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            Unwrapped.SetData(level, arraySlice, rect, data, startIndex, elementCount);
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

        public void SetEffect(EffectParameter parameter)
        {
            parameter.SetValue(this.Unwrapped);
        }

        // protected virtual MsTexture2D Unwrapped { get { return Unwrapped; } }

        internal MsTexture2D Unwrapped { get => _texture2d; set => _texture2d = value; }


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
