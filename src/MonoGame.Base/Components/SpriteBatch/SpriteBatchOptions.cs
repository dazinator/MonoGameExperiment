using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Base.Components
{

    public class SpriteBatchComponentOptions
    {
        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;
        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        public DepthStencilState DepthStencilState { get; set; } = null;

        public RasterizerState RasterizerState { get; set; } = null;

        public MonoGame.Base.Graphics.Effect Effect { get; set; } = null;

        public Matrix? TransformationMatrix { get; set; } = null;

    }
}
