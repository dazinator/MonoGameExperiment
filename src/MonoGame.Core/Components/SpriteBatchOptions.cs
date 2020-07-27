using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Core.Components
{

    public class SpriteBatchOptions
    {
        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;
        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        public DepthStencilState DepthStencilState { get; set; } = null;

        public RasterizerState RasterizerState { get; set; } = null;

        public Effect Effect { get; set; } = null;

        public Matrix? TransformationMatrix { get; set; } = null;

    }
}
