using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;
using Craftopia.MonoGame;
using Craftopia.Drawable;
using System.Collections.Generic;
using System.Linq;

namespace Craftopia
{
    [Register]
    public class SpriteBatchManager : DrawableGameComponent, ISpriteBatchManager
    {

        private readonly List<ISpriteBatchDrawable> _drawables;
        private readonly ISpriteBatch _spriteBatch;

        public SpriteBatchManager(Game game, ISpriteBatch spriteBatch, IEnumerable<ISpriteBatchDrawable> drawables) : base(game)
        {
            _spriteBatch = spriteBatch;
            _drawables = drawables.OrderBy(a => a.UpdateOrder).ToList();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in _drawables)
            {
                item.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            foreach (var item in _drawables)
            {
                item.Draw(_spriteBatch, gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
