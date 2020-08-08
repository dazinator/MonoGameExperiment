using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Effects;
using BasicEffect = MonoGame.Base.Graphics.BasicEffect;
using OcclusionQuery = MonoGame.Base.Graphics.OcclusionQuery;

namespace MonoGame.PostProcessing.Process
{
    public class Sun : BasePostProcess
    {
        public Vector3 Position;
        public Color Color = Color.White;
        public float Intensity = 2f;
        public float Size = 1600;

        BasicEffect basicEffect;
        VertexPositionColor[] queryVertices;


        // How big a rectangle should we examine when issuing our occlusion queries?
        // Increasing this makes the flares fade out more gradually when the sun goes
        // behind scenery, while smaller query areas cause sudden on/off transitions.
        const float querySize = 100;

        // An occlusion query is used to detect when the sun is hidden behind scenery.
        OcclusionQuery occlusionQuery;
        bool occlusionQueryActive;
        float occlusionAlpha;
        bool lightBehindCamera;
        Vector2 lightPosition;

        // Custom blend state so the occlusion query polygons do not show up on screen.
        static readonly BlendState ColorWriteDisable = new BlendState
        {
            ColorWriteChannels = ColorWriteChannels.None

        };

        public IContentManager ContentManager { get; }
        public ICamera Camera { get; }

        public Sun(IContentManager contentManager, IGraphicsDevice graphicsDevice, ISpriteBatch spriteBatch, ICamera camera, Vector3 position) : base(graphicsDevice, spriteBatch)
        {
            ContentManager = contentManager;
            Camera = camera;
            Position = position;

            // Effect for drawing occlusion query polygons.
            basicEffect = GraphicsDevice.CreateBasicEffect();

            basicEffect.View = Matrix.Identity;
            basicEffect.VertexColorEnabled = true;

            // Create vertex data for the occlusion query polygons.
            queryVertices = new VertexPositionColor[4];

            queryVertices[0].Position = new Vector3(-querySize / 2, -querySize / 2, -1);
            queryVertices[1].Position = new Vector3(querySize / 2, -querySize / 2, -1);
            queryVertices[2].Position = new Vector3(-querySize / 2, querySize / 2, -1);
            queryVertices[3].Position = new Vector3(querySize / 2, querySize / 2, -1);

            // Create the occlusion query object.
            occlusionQuery = GraphicsDevice.CreateOcclusionQuery();

        }

        public ITexture2D FlareTexture { get; set; } = null;

        public override void Draw(GameTime gameTime)
        {
            // TODO: Move these to load content..
            if (Effect == null)
            {
                Effect = ContentManager.LoadEffect("Shaders/Sun");
            }              

            if(FlareTexture == null)
            {
                FlareTexture = ContentManager.LoadTexture2D("Textures/flare");
            }

            UpdateOcclusion();

            Color.A = Convert.ToByte(MathHelper.Clamp(occlusionAlpha, 0, 255));

            if (this.lightBehindCamera) return;
            DepthBuffer.SetEffect(Effect.Parameters["depthMap"]);
            
            Effect.Parameters["cameraPosition"].SetValue(Camera.Position);
            Effect.Parameters["lightPosition"].SetValue(Position);
            // System.Diagnostics.Debug.WriteLine("Position: " + Position.ToString());
            Effect.Parameters["Color"].SetValue(Color.ToVector3());
            //System.Diagnostics.Debug.WriteLine("Color: " + Color.ToVector3().ToString());
            Effect.Parameters["lightIntensity"].SetValue(Intensity);
            // System.Diagnostics.Debug.WriteLine("Intensity: " + Intensity);
            Effect.Parameters["SunSize"].SetValue(Size);
            // System.Diagnostics.Debug.WriteLine("Sun Size: " + Size);
            // effect.Parameters["lightPosition"].SetValue(Position);

            Effect.Parameters["VP"].SetValue(Camera.View * Camera.Projection);

            FlareTexture.SetEffect(Effect.Parameters["flare"]);           

            // Set Params.
            base.Draw(gameTime);
        }


        /// <summary>
        /// Mesures how much of the sun is visible, by drawing a small rectangle,
        /// centered on the sun, but with the depth set to as far away as possible,
        /// and using an occlusion query to measure how many of these very-far-away
        /// pixels are not hidden behind the terrain.
        /// 
        /// The problem with occlusion queries is that the graphics card runs in
        /// parallel with the CPU. When you issue drawing commands, they are just
        /// stored in a buffer, and the graphics card can be as much as a frame delayed
        /// in getting around to processing the commands from that buffer. This means
        /// that even after we issue our occlusion query, the occlusion results will
        /// not be available until later, after the graphics card finishes processing
        /// these commands.
        /// 
        /// It would slow our game down too much if we waited for the graphics card,
        /// so instead we delay our occlusion processing by one frame. Each time
        /// around the game loop, we read back the occlusion results from the previous
        /// frame, then issue a new occlusion query ready for the next frame to read
        /// its result. This keeps the data flowing smoothly between the CPU and GPU,
        /// but also causes our data to be a frame out of date: we are deciding
        /// whether or not to draw our lensflare effect based on whether it was
        /// visible in the previous frame, as opposed to the current one! Fortunately,
        /// the camera tends to move slowly, and the lensflare fades in and out
        /// smoothly as it goes behind the scenery, so this out-by-one-frame error
        /// is not too noticeable in practice.
        /// </summary>
        public void UpdateOcclusion()
        {
            // The sun is infinitely distant, so it should not be affected by the
            // position of the camera. Floating point math doesn't support infinitely
            // distant vectors, but we can get the same result by making a copy of our
            // view matrix, then resetting the view translation to zero. Pretending the
            // camera has not moved position gives the same result as if the camera
            // was moving, but the light was infinitely far away. If our flares came
            // from a local object rather than the sun, we would use the original view
            // matrix here.
            //Matrix infiniteView = this.camera.View;
            //infiniteView.Translation = Vector3.Zero;

            //// Project the light position into 2D screen space.
            Viewport viewport = GraphicsDevice.Viewport;

            //Vector3 projectedPosition = viewport.Project(-LightDirection, Projection,
            //                                             infiniteView, Matrix.Identity);

            // Don't draw any flares if the light is behind the camera.
            if ((this.Position.Z < 0) || (this.Position.Z > 1))
            {
                lightBehindCamera = true;
                return;
            }

            lightPosition = new Vector2(this.Position.X, this.Position.Y);
            lightBehindCamera = false;

            if (occlusionQueryActive)
            {
                // If the previous query has not yet completed, wait until it does.
                if (!occlusionQuery.IsComplete)
                    return;

                // Use the occlusion query pixel count to work
                // out what percentage of the sun is visible.
                const float queryArea = querySize * querySize;

                occlusionAlpha = Math.Min(occlusionQuery.PixelCount / queryArea, 1);
            }

            // Set renderstates for drawing the occlusion query geometry. We want depth
            // tests enabled, but depth writes disabled, and we disable color writes
            // to prevent this query polygon actually showing up on the screen.
            GraphicsDevice.BlendState = ColorWriteDisable;
            GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;

            // Set up our BasicEffect to center on the current 2D light position.
            basicEffect.World = Matrix.CreateTranslation(lightPosition.X,
                lightPosition.Y, 0);

            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0,
                viewport.Width,
                viewport.Height,
                0, 0, 1);

            basicEffect.CurrentTechnique.Passes[0].Apply();

            // Issue the occlusion query.
            occlusionQuery.Begin();

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, queryVertices, 0, 2);

            occlusionQuery.End();

            occlusionQueryActive = true;
        }


        /// <summary>
        /// Sets renderstates back to their default values after we finish drawing
        /// the lensflare, to avoid messing up the 3D terrain rendering.
        /// </summary>
        void RestoreRenderStates()
        {
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }


    }
}