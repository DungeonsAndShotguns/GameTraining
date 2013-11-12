using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Breakout.Entities
{
    public class Paddle : Entity
    {
        float Speed { get; set; }
        bool Stickey { get; set; }
        bool Slow { get; set; }
        bool BallControl { get; set; }
        bool BallPahse { get; set; }

        public Paddle(Vector2 startPosition, Rectangle boundingBox) : 
            base(startPosition, boundingBox, true)
        {
            Speed = .3f;
            Stickey = false;
            Slow = false;
            BallControl = false;
        }

        public Entity OnCollide(Entity entColliding)
        {
            if (entColliding.GetType() == typeof(Ball))
            {
                
            }

            return entColliding;
        }
        
    }
}
