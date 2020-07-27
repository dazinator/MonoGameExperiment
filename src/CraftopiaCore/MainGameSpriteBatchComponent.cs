using Craftopia.Drawable;
using Microsoft.Xna.Framework;
using MonoGame.Core.Components;
using MonoGame.Core.Graphics;

namespace Craftopia
{
    public class MainGameSpriteBatchComponent : SpriteBatchComponent
    {
        public MainGameSpriteBatchComponent(Game game,
            ISpriteBatch spriteBatch,
            SpriteBatchOptions options,
            IScoreBoard scoreBoard,
            ISpaceShip spaceShip) : base(game, spriteBatch, options)
        {
            AddDrawable(scoreBoard);
            AddDrawable(spaceShip);
        }       
    }
}