using System;
using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;

namespace MonoGame.Base.Sprite
{
    public abstract class Sprite : BaseDrawable, ISprite
    {
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private bool _enabled { get; set; } = true;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                var previous = _enabled;
                _enabled = value;
                if (_enabled != previous)
                {
                    OnEnabledChanged();
                }
            }
        }

        private int _updateOrder { get; set; }
        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                var previous = _updateOrder;
                _updateOrder = value;
                if (_updateOrder != previous)
                {
                    OnUpdateOrderChanged();
                }
            }
        }

        public ISpriteBatch SpriteBatch { get; set; }
  
        private void OnUpdateOrderChanged()
        {
            UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnEnabledChanged()
        {
            EnabledChanged?.Invoke(this, EventArgs.Empty);
        }    

        public abstract void Update(GameTime gameTime);
    }
}
