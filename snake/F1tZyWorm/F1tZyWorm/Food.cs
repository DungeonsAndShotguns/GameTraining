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
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Image.Width, this.Image.Height);
        }

        public override void Draw(GameTime gmaeTime)
        {
            Renderers.spriteBatch.Draw(this.Image, Position, Color.White);

            if (States.Debug == true)
            {
                Texture2D FillBoundingBox = new Texture2D(Renderers.spriteBatch.GraphicsDevice, 1, 1);
                FillBoundingBox.SetData(new Color[] { Color.White });
                Renderers.spriteBatch.Draw(FillBoundingBox, this.BoundingBox, Color.Blue);
            }
        }
    }
}
