using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.Base.Sprite;
using System.Collections.Generic;

namespace MonoGame.Base.Components
{


    public class SpriteBatchComponent : DrawableGameComponent, ISpriteBatchComponent
    {

        private readonly ISpriteBatch _spriteBatch;

        public SpriteBatchComponent(Game game, ISpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
            Drawables = new List<IDrawable>();
            Updateables = new List<IUpdateable>();
            Options = new SpriteBatchComponentOptions();
        }

        public SpriteBatchComponentOptions Options { get; set; }

        /// <summary>
        /// Adds the drawable to the batch. If the drawable implements <see cref="ILoadContent"/> then LoadContent() will be called at this point.
        /// </summary>
        /// <param name="sprite"></param>
        public void Register(IDrawable drawable)
        {
            var loadContent = drawable as ILoadContent;
            if (loadContent != null)
            {
                loadContent.LoadContent();
            }

            var sprite = drawable as ISprite;
            if (sprite != null)
            {
                sprite.SpriteBatch = _spriteBatch;
            }

            Drawables.Add(drawable);

            var updateable = drawable as IUpdateable;
            if (updateable != null)
            {
                Updateables.Add(updateable);
            }

        }

        public void Unregister(IDrawable drawable)
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
            foreach (var item in Updateables)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(Options.SpriteSortMode, Options.BlendState, Options.SamplerState, Options.DepthStencilState, Options.RasterizerState, Options.Effect, Options.TransformationMatrix);

            foreach (var item in Drawables)
            {
                if (item.Visible)
                {
                    item.Draw(gameTime);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
