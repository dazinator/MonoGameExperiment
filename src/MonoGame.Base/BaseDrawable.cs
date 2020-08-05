using System;
using Microsoft.Xna.Framework;
using MonoGame.Base.Graphics;

namespace MonoGame.Base
{
    public abstract class BaseDrawable : IDrawable
    {
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;  

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

        private void OnDrawOrderChanged()
        {
            DrawOrderChanged?.Invoke(this, EventArgs.Empty);
        }    

        public abstract void Draw(GameTime gameTime);

    }
}
