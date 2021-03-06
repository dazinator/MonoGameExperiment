﻿using Microsoft.Xna.Framework;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.Extended.Input.InputListeners;
using System;

namespace Craftopia.Drawable
{

    public class SpaceShip : InputListenerComponent, ISpaceShip, ILoadContent
    {
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        private ITexture2D _texture;
        private readonly IContentManager _content;

        public SpaceShip(Game game, IContentManager content) : base(game)
        {
            Position = new Vector2(450, 240);
            Color = Color.White;

            // var mouseListener = new MouseListener(new MouseListenerSettings());
            var keyboardListener = new KeyboardListener(new KeyboardListenerSettings());
            keyboardListener.KeyPressed += KeyboardListener_KeyPressed;
            var gamePadListener = new GamePadListener(new GamePadListenerSettings());
            gamePadListener.ButtonDown += GamePadListener_ButtonDown;

            //  Listeners.Add(mouseListener);
            Listeners.Add(keyboardListener);
            Listeners.Add(gamePadListener);
            _content = content;
        }

        public void LoadContent()
        {
            _texture = _content.LoadTexture2D("Images/shuttle");  // if you are using your own images.           
        }

        private void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Microsoft.Xna.Framework.Input.Keys.Left:
                    MoveLeft();
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Right:
                    MoveRight();
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Up:
                    MoveUp();
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Down:
                    MoveDown();
                    break;
            }
        }

        private void GamePadListener_ButtonDown(object sender, GamePadEventArgs e)
        {
            switch (e.Button)
            {
                case Microsoft.Xna.Framework.Input.Buttons.DPadLeft:
                    MoveLeft();
                    break;
                case Microsoft.Xna.Framework.Input.Buttons.DPadRight:
                    MoveRight();
                    break;

                case Microsoft.Xna.Framework.Input.Buttons.DPadUp:
                    MoveUp();
                    break;

                case Microsoft.Xna.Framework.Input.Buttons.DPadDown:
                    MoveDown();
                    break;
            }

        }

        private void MoveDown()
        {
            Position = new Vector2(Position.X, Position.Y + 5);
        }

        private void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - 5);
        }

        private void MoveRight()
        {
            Position = new Vector2(Position.X + 5, Position.Y);
        }

        private void MoveLeft()
        {
            Position = new Vector2(Position.X - 5, Position.Y);
        }

        public Color Color { get; set; }

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

        private void OnDrawOrderChanged()
        {
            DrawOrderChanged?.Invoke(this, EventArgs.Empty);
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

        public Vector2 Position { get; set; }
        public ISpriteBatch SpriteBatch { get; set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch?.Draw(_texture, Position, Color);
            // SpriteBatch.Draw(_texture, Position, Color);
        }
    }
}
