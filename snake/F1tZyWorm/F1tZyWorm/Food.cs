using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    public class Food : Entitty
    {
        public Food() { }

        public Food(Vector2 initPos, Texture2D entImage)
            : base(initPos, entImage)
        {

        }

        public override void Draw(GameTime gmaeTime)
        {
            Renderers.spriteBatch.Draw(this.Image, Position, Color.White);
        }
    }
}
