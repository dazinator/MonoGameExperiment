using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Graphics;
using Effect = MonoGame.Base.Graphics.Effect;

namespace MonoGame.Base.Content
{
    public interface IContentManager
    {
        ITexture2D LoadTexture2D(string assetName);
        ISpriteFont LoadSpriteFont(string assetName);
        Effect LoadEffect(string assetName);
    }
}
