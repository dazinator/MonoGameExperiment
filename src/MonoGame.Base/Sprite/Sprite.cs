using System;
using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;

namespace MonoGame.Base.Sprite
{
    public abstract class Sprite : ISprite
    {
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

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

        private int _drawOrder { get; set; }
        public int DrawOrder
        {
            get { return _drawOrder; }
            set
            {
                var previous = _drawOrder;
                _drawOrder = value;
                if (_drawOrder != previous)
                {
                    OnDrawOrderChanged();
                }

            }
        }

        private bool _visible { get; set; } = true;
        public bool Visible
        {
            get { return _visible; }
            set
            {
                var previous = _visible;
                _visible = value;
                if (_visible != previous)
                {
                    OnVisibleChanged();
                }

            }
        }

        private void OnVisibleChanged()
        {
            VisibleChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnUpdateOrderChanged()
        {
            UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnEnabledChanged()
        {
            EnabledChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnDrawOrderChanged()
        {
            DrawOrderChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

    }
}
