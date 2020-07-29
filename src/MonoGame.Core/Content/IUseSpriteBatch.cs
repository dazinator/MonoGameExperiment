using MonoGame.Core.Graphics;

namespace MonoGame.Core.Components
{
    public interface IUseSpriteBatch
    {
        ISpriteBatch SpriteBatch { get; set; }
    }
}
