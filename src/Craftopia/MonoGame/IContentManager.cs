﻿using Microsoft.Xna.Framework.Graphics;

namespace Craftopia.MonoGame
{
    public interface IContentManager
    {
        ITexture2D LoadTexture2D(string assetName);
        ISpriteFont LoadSpriteFont(string assetName);
    }
}
