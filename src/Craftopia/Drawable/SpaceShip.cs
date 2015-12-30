using Craftopia.Bootstrap;
using Craftopia.MonoGame;
using System;
using Microsoft.Xna.Framework;

namespace Craftopia.Drawable
{
    [Register]
    public class SpaceShip : BaseDrawable, ISpaceShip
    {

        private ITexture2D _texture;       

        public SpaceShip(IContentManager content) 
        {
            _texture = content.LoadTexture2D("Images/shuttle");  // if you are using your own images.           
            Position = new Vector2(450, 240);
            Color = Color.White;
        }

        public Color Color { get; set; }

        public Vector2 Position { get; set; }

        public override void Draw(ISpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, Position, Color);
        }
      
    }
}
