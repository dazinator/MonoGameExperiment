using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Craftopia.MonoGame
{
    public class Texture2DWrapper : ITexture2D
    {

        private Texture2D _texture2d;

        public Texture2DWrapper(Texture2D texture2d)
        {
            _texture2d = texture2d;
        }      

        public Rectangle Bounds
        {
            get
            {
                return _texture2d.Bounds;
            }
        }

        public int Height
        {
            get
            {
                return _texture2d.Height;
            }
        }

        public int Width
        {
            get
            {
                return _texture2d.Width;
            }
        }       

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(_texture2d, position, color);
        }

        public void GetData<T>(T[] data) where T : struct
        {
            _texture2d.GetData<T>(data);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.GetData<T>(data, startIndex, elementCount);
        }

        public void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.GetData<T>(level, rect, data, startIndex, elementCount);
        }

        public void GetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.GetData<T>(level, arraySlice, rect, data, startIndex, elementCount);
        }

        public void Reload(Stream textureStream)
        {
            _texture2d.Reload(textureStream);
        }

        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            _texture2d.SaveAsJpeg(stream, width, height);
        }

        public void SaveAsPng(Stream stream, int width, int height)
        {
            _texture2d.SaveAsPng(stream, width, height);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            _texture2d.SetData(data);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.SetData(data, startIndex, elementCount);
        }

        public void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.SetData(level, rect, data, startIndex, elementCount);
        }

        public void SetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            _texture2d.SetData(level, arraySlice, rect, data, startIndex, elementCount);
        }

        //public static implicit operator Texture2DWrapper(Texture2D texture2d)  // implicit texture2d to Texture2DWrapper conversion operator
        //{
        //    return new Texture2DWrapper(texture2d);
        //}

        public static explicit operator Texture2DWrapper(Texture2D texture2d)  // explicit texture2d to Texture2DWrapper conversion operator
        {
            return new Texture2DWrapper(texture2d);
        }
    }
}
