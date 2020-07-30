using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;
using System.Collections.Generic;

namespace MonoGame.Core.Components
{

    public class SpriteBatchComponent : DrawableGameComponent, ISpriteBatchComponent
    {

        private readonly ISpriteBatch _spriteBatch;

        public SpriteBatchComponent(Game game, ISpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
            Drawables = new List<IDrawable>();
            Options = new SpriteBatchComponentOptions();
        }

        public SpriteBatchComponentOptions Options { get; set; }

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

        /// <summary>
        /// Adds the drawable to the batch. If the drawable implements <see cref="ILoadContent"/> then LoadContent() will be called at this point.
        /// </summary>
        /// <param name="sprite"></param>
        public void AddUpdateable(IUpdateable updateable)
        {
            Updateables.Add(updateable);
        }

        protected List<IDrawable> Drawables { get; set; }

        protected List<IUpdateable> Updateables { get; set; }

        //public override void Update(GameTime gameTime)
        //{
        //    foreach (var item in Drawables)
        //    {
        //        item.Update(gameTime);
        //    }

        //    base.Update(gameTime);
        //}

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(Options.SpriteSortMode, Options.BlendState, Options.SamplerState, Options.DepthStencilState, Options.RasterizerState, Options.Effect, Options.TransformationMatrix);

            foreach (var item in Drawables)
            {
                item.Draw(gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
