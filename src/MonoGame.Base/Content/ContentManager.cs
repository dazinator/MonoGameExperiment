using MonoGame.Base.Graphics;

namespace MonoGame.Base.Content
{

    public class ContentManager : IContentManager
    {
        private readonly Microsoft.Xna.Framework.Content.ContentManager _contentManager;

        public ContentManager(Microsoft.Xna.Framework.Content.ContentManager contentManager) : base()
        {
            _contentManager = contentManager;
        }

        public ISpriteFont LoadSpriteFont(string assetName)
        {
            try
            {
                var font = _contentManager.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>(assetName);
                return new SpriteFont(font);
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
                var texture = _contentManager.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(assetName);
                return new Texture2D(texture);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
