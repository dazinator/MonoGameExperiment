using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Text;

namespace Craftopia.MonoGame
{
    public interface ISpriteBatch : IDisposable
    {
        //
        // Summary:
        //     Begins a new sprite and text batch with the specified render state.
        //
        // Parameters:
        //   sortMode:
        //     The drawing order for sprite and text drawing. Microsoft.Xna.Framework.Graphics.SpriteSortMode.Deferred
        //     by default.
        //
        //   blendState:
        //     State of the blending. Uses Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend
        //     if null.
        //
        //   samplerState:
        //     State of the sampler. Uses Microsoft.Xna.Framework.Graphics.SamplerState.LinearClamp
        //     if null.
        //
        //   depthStencilState:
        //     State of the depth-stencil buffer. Uses Microsoft.Xna.Framework.Graphics.DepthStencilState.None
        //     if null.
        //
        //   rasterizerState:
        //     State of the rasterization. Uses Microsoft.Xna.Framework.Graphics.RasterizerState.CullCounterClockwise
        //     if null.
        //
        //   effect:
        //     A custom Microsoft.Xna.Framework.Graphics.Effect to override the default sprite
        //     effect. Uses default sprite effect if null.
        //
        //   transformMatrix:
        //     An optional matrix used to transform the sprite geometry. Uses Microsoft.Xna.Framework.Matrix.Identity
        //     if null.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown if Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode,Microsoft.Xna.Framework.Graphics.BlendState,Microsoft.Xna.Framework.Graphics.SamplerState,Microsoft.Xna.Framework.Graphics.DepthStencilState,Microsoft.Xna.Framework.Graphics.RasterizerState,Microsoft.Xna.Framework.Graphics.Effect,System.Nullable{Microsoft.Xna.Framework.Matrix})
        //     is called next time without previous Microsoft.Xna.Framework.Graphics.SpriteBatch.End.
        //
        // Remarks:
        //     This method uses optional parameters.
        void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default(Matrix?));

        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   destinationRectangle:
        //     The drawing bounds on screen.
        //
        //   color:
        //     A color mask.
        void Draw(Texture2D texture, Rectangle destinationRectangle, Color color);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        void Draw(ITexture2D texture, Vector2 position, Color color);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   color:
        //     A color mask.
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   destinationRectangle:
        //     The drawing bounds on screen.
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   color:
        //     A color mask.
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   destinationRectangle:
        //     The drawing bounds on screen.
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this sprite.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this sprite.
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this sprite.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this sprite.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this sprite.
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this sprite.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this sprite.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this sprite.
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a sprite for drawing in the current batch.
        //
        // Parameters:
        //   texture:
        //     A texture.
        //
        //   position:
        //     The drawing location on screen or null if destinationRectangle
        //
        //   destinationRectangle:
        //     The drawing bounds on screen or null if position
        //
        //   sourceRectangle:
        //     An optional region on the texture which will be rendered. If null - draws full
        //     texture.
        //
        //   origin:
        //     An optional center of rotation. Uses Microsoft.Xna.Framework.Vector2.Zero if
        //     null.
        //
        //   rotation:
        //     An optional rotation of this sprite. 0 by default.
        //
        //   scale:
        //     An optional scale vector. Uses Microsoft.Xna.Framework.Vector2.One if null.
        //
        //   color:
        //     An optional color mask. Uses Microsoft.Xna.Framework.Color.White if null.
        //
        //   effects:
        //     The optional drawing modificators. Microsoft.Xna.Framework.Graphics.SpriteEffects.None
        //     by default.
        //
        //   layerDepth:
        //     An optional depth of the layer of this sprite. 0 by default.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Throwns if both position and destinationRectangle been used.
        //
        // Remarks:
        //     This overload uses optional parameters. This overload requires only one of position
        //     and destinationRectangle been used.
        void Draw(Texture2D texture, Vector2? position = default(Vector2?), Rectangle? destinationRectangle = default(Rectangle?), Rectangle? sourceRectangle = default(Rectangle?), Vector2? origin = default(Vector2?), float rotation = 0, Vector2? scale = default(Vector2?), Color? color = default(Color?), SpriteEffects effects = SpriteEffects.None, float layerDepth = 0);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this string.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this string.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this string.
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this string.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this string.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this string.
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this string.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this string.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this string.
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        //
        // Summary:
        //     Submit a text string of sprites for drawing in the current batch.
        //
        // Parameters:
        //   spriteFont:
        //     A font.
        //
        //   text:
        //     The text which will be drawn.
        //
        //   position:
        //     The drawing location on screen.
        //
        //   color:
        //     A color mask.
        //
        //   rotation:
        //     A rotation of this string.
        //
        //   origin:
        //     Center of the rotation. 0,0 by default.
        //
        //   scale:
        //     A scaling of this string.
        //
        //   effects:
        //     Modificators for drawing. Can be combined.
        //
        //   layerDepth:
        //     A depth of the layer of this string.
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);

        void End();
    }
}
