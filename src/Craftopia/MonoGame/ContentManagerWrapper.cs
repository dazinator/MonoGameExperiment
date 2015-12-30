using System;
using Craftopia.Bootstrap;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Craftopia.MonoGame
{
    [Register]
    public class ContentManagerWrapper : IContentManager
    {
        private readonly ContentManager _contentManager;

        public ContentManagerWrapper(ContentManager contentManager) : base()
        {
            _contentManager = contentManager;
        }

        public ISpriteFont LoadSpriteFont(string assetName)
        {
            try
            {
                var font = _contentManager.Load<SpriteFont>(assetName);
                return new SpriteFontWrapper(font);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ITexture2D LoadTexture2D(string assetName)
        {
            try
            {
                var texture = _contentManager.Load<Texture2D>(assetName);
                return new Texture2DWrapper(texture);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
