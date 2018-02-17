using System;
using Craftopia.MonoGame;
using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    public class BaseSpriteBatchDrawable : ISpriteBatchDrawable
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

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(ISpriteBatch spriteBatch, GameTime gameTime)
        {

        }
    }
}
