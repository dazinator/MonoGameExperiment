using Microsoft.Xna.Framework;
using MonoGame.Core.Components;
using MonoGame.Core.Content;
using MonoGame.Core.Graphics;
using MonoGame.Core.Sprite;

namespace Craftopia.Drawable
{
    public class ScoreBoard : Sprite, IScoreBoard, ILoadContent
    {
        private readonly IContentManager _content;
        private ISpriteFont _font;
        private int score = 0;

        public ScoreBoard(IContentManager content)
        {
            _content = content;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch?.DrawString(_font, "Score: " + score, new Vector2(100, 100), Color.Black);
        }

        public void LoadContent()
        {
            _font = _content.LoadSpriteFont("Fonts/Score");
        }     

        public override void Update(GameTime gameTime)
        {
            score++;
        }
    }
}
