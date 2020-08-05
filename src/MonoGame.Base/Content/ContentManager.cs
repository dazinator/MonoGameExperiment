using MonoGame.Base.Graphics;
using MSEffect = Microsoft.Xna.Framework.Graphics.Effect;

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
            var font = _contentManager.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>(assetName);
            return new Graphics.SpriteFont(font);
        }

        public ITexture2D LoadTexture2D(string assetName)
        {
            var texture = _contentManager.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(assetName);
            return new Texture2D(texture);
        }

        public Effect LoadEffect(string assetName)
        {
            var effect = _contentManager.Load<MSEffect>(assetName);
            return new Effect(effect);
        }
    }
}
