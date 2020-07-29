using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;
using System.Collections.Generic;

namespace MonoGame.Core.Components
{

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

            Drawables = new List<IDrawable>();
        }

        /// <summary>
        /// Adds the drawable to the batch. If the drawable implements <see cref="ILoadContent"/> then LoadContent() will be called at this point.
        /// </summary>
        /// <param name="sprite"></param>
        public void AddDrawable(IDrawable drawable)
        {            
            if (drawable is ILoadContent)
            {
                ((ILoadContent)drawable).LoadContent();
            }

            if (drawable is IUseSpriteBatch)
            {
                ((IUseSpriteBatch)drawable).SpriteBatch = _spriteBatch;
            }

            Drawables.Add(drawable);
        }

        public void RemoveDrawable(IDrawable drawable)
        {
            Drawables.Remove(drawable);
        }

        protected List<IDrawable> Drawables { get; set; }

        //public override void Update(GameTime gameTime)
        //{
        //    foreach (var item in Drawables)
        //    {
        //        item.Update(gameTime);
        //    }

        //    base.Update(gameTime);
        //}

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(_options.SpriteSortMode, _options.BlendState, _options.SamplerState, _options.DepthStencilState, _options.RasterizerState, _options.Effect, _options.TransformationMatrix);

            foreach (var item in Drawables)
            {
                item.Draw(gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
