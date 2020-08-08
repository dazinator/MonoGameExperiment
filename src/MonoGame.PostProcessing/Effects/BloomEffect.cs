using MonoGame.Base.Content;
using MonoGame.Base.Graphics;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class BloomEffect : BasePostProcessingEffect
    {
        BrightPass bp;
        GaussBlurV gbv;
        GaussBlurH gbh;
        Bloom b;

        public float BloomIntensity
        {
            get { return b.BloomIntensity; }
            set { b.BloomIntensity = value; }
        }

        public float BlurAmount
        {
            get
            {
                return gbv.BlurAmount;
            }
            set
            {
                gbv.BlurAmount = value;
                gbh.BlurAmount = value;
            }
        }

        public IContentManager ContentManager { get; }

        public BloomEffect(IContentManager contentManager, IGraphicsDevice device, ISpriteBatch spriteBatch, float intensity, float saturation, float baseIntensity, float baseSatration, float threshold, float blurAmount) : base(device, spriteBatch)
        {
            ContentManager = contentManager;
            bp = new BrightPass(ContentManager, device, spriteBatch, threshold);
            gbv = new GaussBlurV(ContentManager, device, spriteBatch, blurAmount);
            gbh = new GaussBlurH(ContentManager, device, spriteBatch, blurAmount);
            b = new Bloom(ContentManager, device, spriteBatch, intensity, saturation, baseIntensity, baseSatration);

            AddPostProcess(bp);
            AddPostProcess(gbv);
            AddPostProcess(gbh);
            AddPostProcess(b);
        
        }
    }
}
