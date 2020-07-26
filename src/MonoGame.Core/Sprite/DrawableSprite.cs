using System;
using Microsoft.Xna.Framework;
using MonoGame.Core.Graphics;

namespace MonoGame.Core.Sprite
{
    public abstract class DrawableSprite : IDrawableSprite
    {
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private bool _enabled { get; set; }
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        private int _updateOrder { get; set; }
        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                _updateOrder = value;
                OnUpdateOrderChanged();
            }
        }

        private void OnUpdateOrderChanged()
        {
            UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnEnabledChanged()
        {
            EnabledChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(ISpriteBatch spriteBatch, GameTime gameTime);
      
    }
}
