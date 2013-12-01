using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Entities
{
    public class Block : Entity
    {
        int DamageValue { get; set; }

        Texture2D[] Images { get; set; }

        public Block() : base() { }

        public Block(Vector2 position, Rectangle boundingBox, bool isVisable, int damageValue, Texture2D[] images) :
            base(position, boundingBox, isVisable)
        {
            if (damageValue > 6)
            {
                throw new Exception("Damage values must be 1 - 6");
            }

            DamageValue = damageValue;
            Images = images;
        }

        public Block SetBlockPos(Vector2 pos)
        {
            this.SetPosition(pos);

            return this;
        }

        public void DamageBlock(int amount)
        {
            DamageValue -= amount;
        }

        public int GetDamage()
        {
            return DamageValue;
        }

        public void ResizeBoundingBox()
        {
            this.ResizeBoundingBox(Images[0]);
        }

        public Texture2D ReturnImage()
        {
            if (this.ReturnVisbale() == true)
            {
                return Images[DamageValue - 1];
            }

            return null;
        }

        public override void Update(GameTime gameTime, Rectangle screen)
        {
            if (DamageValue <= 0)
            {
                this.SetVisable(false);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (DamageValue > 0)
            {
                Game1.spriteBatch.Draw(Images[DamageValue - 1], ReturnPosition(), Color.White);
            }
        }
    }
}
