using Craftopia.Bootstrap;
using Craftopia.MonoGame;
using System;
using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    [Register]
    public class SpaceShip : ISpaceShip
    {

        private ITexture2D _texture;
        private ISpriteBatch _spriteBatch;

        public SpaceShip(IContentManager content, ISpriteBatch spriteBatch) 
        {
            _texture = content.LoadTexture2D("Images/shuttle");  // if you are using your own images.
            _spriteBatch = spriteBatch;
            Position = new Vector2(450, 240);
            Color = Color.White;
        }

        public Color Color { get; set; }

        public int DrawOrder
        {
            get
            {
                return 1;
            }
        }

        public Vector2 Position { get; set; }

        public bool Visible
        {
            get
            {
                return true;
            }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, Position, Color);
        }
    }
}
