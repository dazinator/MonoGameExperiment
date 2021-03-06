﻿using MonoGame.Base.Graphics;

namespace MonoGame.Base.Content
{
    public interface IContentManager
    {
        ITexture2D LoadTexture2D(string assetName);
        ISpriteFont LoadSpriteFont(string assetName);
    }
}
