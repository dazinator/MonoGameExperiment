using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;
using MonoGame.Core.Sprite;
using System;
using System.Collections.Generic;

namespace MonoGame.Core.Components
{

    /// <summary>
    /// Comparer for comparing two keys, handling equality as beeing greater
    /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result;
        }

        #endregion
    }

    //[Register]
    public class SpriteBatchComponent : DrawableGameComponent, ISpriteBatchComponent
    {

        private readonly ISpriteBatch _spriteBatch;
        private readonly SpriteBatchOptions _options;

        public SpriteBatchComponent(
            Game game,
            ISpriteBatch spriteBatch,
            SpriteBatchOptions options) : base(game)
        {
            _spriteBatch = spriteBatch;
            _options = options;

            Drawables = new SortedList<int, IDrawableSprite>(new DuplicateKeyComparer<int>());
        }

        /// <summary>
        /// Adds the drawable to the batch. If the drawable implements <see cref="ILoadContent"/> then LoadContent() will be called at this point.
        /// </summary>
        /// <param name="sprite"></param>
        public void AddDrawable(IDrawableSprite sprite)
        {
            if (sprite is ILoadContent)
            {
                ((ILoadContent)sprite).LoadContent();
            }
            Drawables.Add(sprite.UpdateOrder, sprite);

        }

        public void RemoveDrawable(IDrawableSprite sprite)
        {
            Drawables.Values.Remove(sprite);
        }

        protected SortedList<int, IDrawableSprite> Drawables { get; set; }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in Drawables)
            {
                item.Value.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(_options.SpriteSortMode, _options.BlendState, _options.SamplerState, _options.DepthStencilState, _options.RasterizerState, _options.Effect, _options.TransformationMatrix);

            foreach (var item in Drawables)
            {
                item.Value.Draw(_spriteBatch, gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
