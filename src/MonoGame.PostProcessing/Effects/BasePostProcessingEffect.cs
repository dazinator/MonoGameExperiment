using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;
using System.Collections.Generic;

namespace MonoGame.PostProcessing.Effects
{
    public class BasePostProcessingEffect : BaseDrawable
    {      
        public BasePostProcessingEffect(IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch)
        {
            // Game = game;
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
        }
        public Vector2 HalfPixel { get; set; }
        public ITexture2D LastScene { get; set; }
        public ITexture2D OrgScene { get; set; }

        protected List<BasePostProcess> postProcesses = new List<BasePostProcess>();

        public IGraphicsDevice GraphicsDevice { get; set; }

        public ISpriteBatch SpriteBatch
        {
            get;
        }

        public void AddPostProcess(BasePostProcess postProcess)
        {
            postProcesses.Add(postProcess);
        }

        public ITexture2D Scene { get; set; }
        public ITexture2D Depth { get; set; }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible)
                return;

            OrgScene = Scene;

            int maxProcess = postProcesses.Count;
            LastScene = null;

            for (int p = 0; p < maxProcess; p++)
            {
                if (postProcesses[p].Visible)
                {
                    // Set Half Pixel value.
                    if (postProcesses[p].HalfPixel == Vector2.Zero)
                        postProcesses[p].HalfPixel = HalfPixel;

                    // Set original scene
                    postProcesses[p].OrgBuffer = OrgScene;

                    // Ready render target if needed.
                    if (postProcesses[p].NewScene == null)
                        postProcesses[p].NewScene = GraphicsDevice.CreateRenderTarget(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, false, SurfaceFormat.Color, DepthFormat.None);

                    GraphicsDevice.SetRenderTarget(postProcesses[p].NewScene);

                    // Has the scene been rendered yet (first effect may be disabled)
                    if (LastScene != null)
                        postProcesses[p].BackBuffer = LastScene;
                    else // No, so use the the scene texure passed in.
                        postProcesses[p].BackBuffer = Scene;

                    postProcesses[p].DepthBuffer = Depth;
                    postProcesses[p].Draw(gameTime);

                    GraphicsDevice.SetRenderTarget(null);

                    LastScene = postProcesses[p].NewScene;
                }
            }
        }
    }
}
