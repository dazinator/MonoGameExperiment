using Microsoft.Xna.Framework;
using Monogame.Core.DependencyInjection;
using MonoGame.Core.Content;
using MonoGame.Core.Graphics;
using MonoGame.Core.Sprite;

namespace Craftopia.Drawable
{
    [Register]
    public class ScoreBoard : DrawableSprite, IScoreBoard
    {
        private ISpriteFont _font;
        private int score = 0;

        public ScoreBoard()
        {
        }

        public ScoreBoard(IContentManager content)
        {
            _font = content.LoadSpriteFont("Fonts/Score");
        }

        public override void Draw(ISpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(_font, "Score: " + score, new Vector2(100, 100), Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            score++;
        }
    }  
}
