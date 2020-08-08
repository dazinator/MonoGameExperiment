using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class FogEffect : BasePostProcessingEffect
    {
        public Fog Fog { get; set; }


        public readonly Viewport Viewport;

        public float FogDistance
        {
            get { return Fog.FogDistance; }
            set { Fog.FogDistance = MathHelper.Clamp(value, MinDistance, MaxDistance); }
            // set { fog.FogDistance = MathHelper.Clamp(value, camera.Viewport.MinDepth, camera.Viewport.MaxDepth); }
        }

        public float FogRange
        {
            get { return Fog.FogRange; }
            set { Fog.FogRange = MathHelper.Clamp(value, MinRange, MaxRange); }

        }

        public ICamera Camera { get; }
        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }


        public float MinRange { get; set; }
        public float MaxRange { get; set; }


        public FogEffect(IContentManager contentManager,
            IGraphicsDevice device,
            ISpriteBatch spriteBatch,
            ICamera camera,          
            float distance,
            float range,
            Color color) : base(device, spriteBatch)
        {
            Camera = camera;
            MinDistance = Camera.Viewport.MinDepth;
            MaxDistance = Camera.Viewport.MaxDepth;
            MinRange = Camera.Viewport.MinDepth;
            MaxRange = Camera.Viewport.MaxDepth;

            FogDistance = distance;
            FogRange = range;
            Fog = new Fog(contentManager, device, spriteBatch, Camera, distance, range, color);
            AddPostProcess(Fog);
        }       
    }
}