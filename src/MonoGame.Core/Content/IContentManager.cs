using MonoGame.Core.Graphics;

namespace MonoGame.Core.Content
{
    public interface IContentManager
    {
        ITexture2D LoadTexture2D(string assetName);
        ISpriteFont LoadSpriteFont(string assetName);
    }
}
