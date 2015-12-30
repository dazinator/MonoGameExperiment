using Craftopia.Bootstrap;
using Microsoft.Xna.Framework;
using Craftopia.MonoGame;

namespace Craftopia.Drawable
{
    [Register]
    public class ScoreBoard : BaseDrawable, IScoreBoard
    {
        private ISpriteFont _font;
        private int score = 0;

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
