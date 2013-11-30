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

        public Block() : base() { }

        public Block(Vector2 position, Rectangle boundingBox, bool isVisable, int damageValue, Texture2D image) :
            base(position, boundingBox, isVisable)
        {
            DamageValue = damageValue;
            LoadImage(image);
        }

        public void DamageBlock(int amount)
        {
            DamageValue -= amount;
        }
    }
}
