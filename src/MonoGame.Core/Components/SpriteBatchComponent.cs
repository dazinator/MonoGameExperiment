using Microsoft.Xna.Framework;
using Monogame.Core.DependencyInjection;
using MonoGame.Core.Graphics;
using MonoGame.Core.Sprite;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Core.Components
{
    [Register]
    public class SpriteBatchComponent : DrawableGameComponent, ISpriteBatchComponent
    {

        private readonly List<IDrawableSprite> _drawables;
        private readonly ISpriteBatch _spriteBatch;

        public SpriteBatchComponent(Game game, ISpriteBatch spriteBatch, IEnumerable<IDrawableSprite> drawables) : base(game)
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
