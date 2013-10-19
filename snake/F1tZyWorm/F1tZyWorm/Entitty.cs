using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    public class Entitty
    {
        public Vector2 Position { get; set; }
        public Vector2 Volicity { get; set; }
        public Texture2D Image { get; set; }
        public Rectangle BoundingBox = new Rectangle();

        public Entitty() { }

        public Entitty(Vector2 initPos, Texture2D entImage)
        {
            Position = initPos;
            Image = entImage;

            Volicity = Vector2.Zero;
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(GameTime gmaeTime) { }
    }
}
