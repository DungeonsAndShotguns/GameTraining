using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    public class Worm : Entitty
    {
        public List<WormBit> WormBody { get; set; } // the body of the worm minus the head

        public Worm() { }

        public Worm(Vector2 initPOS, Texture2D entImage) : base (initPOS, entImage)
        {
            // Set the initial Volicity
            this.Volicity = new Vector2(3, 0);
        }
    }
}
