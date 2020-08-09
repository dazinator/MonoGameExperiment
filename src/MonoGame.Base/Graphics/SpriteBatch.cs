using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MSGraphicsDevice = Microsoft.Xna.Framework.Graphics.GraphicsDevice;

namespace MonoGame.Base.Graphics
{
    public class SpriteBatch : Microsoft.Xna.Framework.Graphics.SpriteBatch, ISpriteBatch
    {
        public SpriteBatch(MSGraphicsDevice device) : base(device)
        {

        }

        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null)
        {
            Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect?.Unwrapped, transformMatrix);
        }

        public void Draw(ITexture2D texture, Vector2 position, Color color)
        {
            texture.Draw(this, position, color);          
        }

        public void Draw(ITexture2D texture, Rectangle destinationRectangle, Color color)
        {
            texture.Draw(this, destinationRectangle, color);
        }

        public void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            texture.Draw(this, position, sourceRectangle, color);
        }

        public void Draw(ITexture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            texture.Draw(this, destinationRectangle, sourceRectangle, color);
        }

        public void Draw(ITexture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            texture.Draw(this, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        public void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            texture.Draw(this, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }

        public void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            texture.Draw(this, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }       

        //public void Draw(Texture2D texture, Vector2? position = null, Rectangle? destinationRectangle = null, Rectangle? sourceRectangle = null, Vector2? origin = null, float rotation = 0, Vector2? scale = null, Color? color = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
        //{
        //    texture.Draw(this, position, color);
        //    throw new System.NotImplementedException();
        //}

        public void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            spriteFont.DrawString(this, text, position, color);
        }

        public void DrawString(ISpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            spriteFont.DrawString(this, text, position, color);
         //   DrawString(spriteFont.Unwrapped, text, position, color);
        }

        public void DrawString(ISpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteFont.DrawString(this, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteFont.DrawString(this, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteFont.DrawString(this, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        public void DrawString(ISpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteFont.DrawString(this, text, position, color, rotation, origin, scale, effects, layerDepth);
        }
    }
}
