using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    /// <summary>
    /// A worm bit is a pieice of the worm that gets added when the worm eats a
    /// food bit.
    /// </summary>
    public class WormBit : Entitty
    {
        public WormBit() { }

        public WormBit(Vector2 initPos, Texture2D entImage, Worm worm)
            : base(initPos, entImage)
        {

        }
    }
}
