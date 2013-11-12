using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

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
            Speed = 4.5f;
            Stickey = false;
            Slow = false;
            BallControl = false;
        }

        public void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(ReturnImage(), ReturnPosition(), Color.White);

            if (Game1.Debug == true)
            {
                Texture2D BoundingDraw = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                BoundingDraw.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(BoundingDraw, this.ReturnBoundingBox(), Color.Azure);
            }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState CurrentState = Keyboard.GetState();

            if (CurrentState.IsKeyDown(Keys.Left))
            {
                this.Move(-1 * Speed, 0);
            }

            if (CurrentState.IsKeyDown(Keys.Right))
            {
                this.Move(Speed, 0);
            }
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
