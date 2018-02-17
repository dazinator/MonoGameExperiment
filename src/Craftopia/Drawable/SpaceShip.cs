using Craftopia.Bootstrap;
using Craftopia.MonoGame;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace Craftopia.Drawable
{

    [Register]
    public class SpaceShip : InputListenerComponent, ISpaceShip, ISpriteBatchDrawable
    {

        private ITexture2D _texture;

        public SpaceShip(Game game, IContentManager content) : base(game)
        {
            _texture = content.LoadTexture2D("Images/shuttle");  // if you are using your own images.           
            Position = new Vector2(450, 240);
            Color = Color.White;

            // var mouseListener = new MouseListener(new MouseListenerSettings());
            //  var keyboardListener = new KeyboardListener(new KeyboardListenerSettings());
            var gamePadListener = new GamePadListener(new GamePadListenerSettings());
            gamePadListener.ButtonDown += GamePadListener_ButtonDown;
            //  Listeners.Add(mouseListener);
            //  Listeners.Add(keyboardListener);
            Listeners.Add(gamePadListener);
        }

        private void GamePadListener_ButtonDown(object sender, GamePadEventArgs e)
        {
            switch (e.Button)
            {
                case Microsoft.Xna.Framework.Input.Buttons.DPadLeft:
                    Position = new Vector2(Position.X - 5, Position.Y);
                    break;
                case Microsoft.Xna.Framework.Input.Buttons.DPadRight:
                    Position = new Vector2(Position.X + 5, Position.Y);
                    break;

                case Microsoft.Xna.Framework.Input.Buttons.DPadUp:
                    Position = new Vector2(Position.X, Position.Y - 5);
                    break;

                case Microsoft.Xna.Framework.Input.Buttons.DPadDown:
                    Position = new Vector2(Position.X - 5, Position.Y + 5);
                    break;
            }
          
        }


        public Color Color { get; set; }

        public Vector2 Position { get; set; }

        public void Draw(ISpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, Position, Color);
        }

    }
}
