﻿using Microsoft.Xna.Framework;
using MonoGame.PostProcessing.Process;

namespace MonoGame.PostProcessing.Effects
{
    public class SunEffect : BasePostProcessingEffect
    {
        Sun sun;

        public Vector3 Position
        {
            get { return sun.Position; }
            set { sun.Position = value; }
        }

        public SunEffect(Game game, Vector3 position) : base(game)
        {
            sun = new Sun(game, position);

            AddPostProcess(sun);
        }
    }
}