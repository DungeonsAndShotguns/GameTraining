using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    public class WormBit : Entitty
    {
        public WormBit() { }

        public WormBit(Vector2 initPos, Texture2D entImage, Worm worm)
            : base(initPos, entImage)
        {

        }
    }
}
