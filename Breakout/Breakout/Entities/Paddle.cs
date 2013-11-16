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

        public Rectangle LeftHit = new Rectangle();
        public Rectangle LeftInnerHit = new Rectangle();
        public Rectangle MiddleHit = new Rectangle();
        public Rectangle RightInnerHit = new Rectangle();
        public Rectangle RightHit = new Rectangle();

        public Paddle(Vector2 startPosition, Rectangle boundingBox) : 
            base(startPosition, boundingBox, true)
        {
            Speed = 4.5f;
            Stickey = false;
            Slow = false;
            BallControl = false;

            // define inner hit boxes
            //LeftHit = new Rectangle((int)ReturnPosition().X, (int)ReturnPosition().Y, 10, 12);
            //LeftInnerHit = new Rectangle((int)ReturnPosition().X + 10, (int)ReturnPosition().Y, 10, 12);
            //MiddleHit = new Rectangle((int)ReturnPosition().X + 20, (int)ReturnPosition().Y, 10, 12);
            //RightInnerHit = new Rectangle((int)ReturnPosition().X + 30, (int)ReturnPosition().Y, 10, 12);
            //RightHit = new Rectangle((int)ReturnPosition().X + 40, (int)ReturnPosition().Y, 10, 12);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(ReturnImage(), ReturnPosition(), Color.White);

            if (Game1.Debug == true)
            {
                Texture2D BoundingDraw = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                BoundingDraw.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(BoundingDraw, this.ReturnBoundingBox(), Color.Azure);
                Game1.spriteBatch.Draw(BoundingDraw, this.LeftHit, Color.Gray);
                Game1.spriteBatch.Draw(BoundingDraw, this.LeftInnerHit, Color.Brown);
                Game1.spriteBatch.Draw(BoundingDraw, this.MiddleHit , Color.Black);
                Game1.spriteBatch.Draw(BoundingDraw, this.RightInnerHit, Color.Brown);
                Game1.spriteBatch.Draw(BoundingDraw, this.RightHit, Color.Gray);
            }
        }

        public override void Update(GameTime gameTime, Rectangle screen)
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

            if (ReturnPosition().X < screen.Left)
            {
                SetPosition(new Vector2(screen.Left, ReturnPosition().Y));
            }

            if (ReturnPosition().X + ReturnImage().Width > screen.Right)
            {
                SetPosition(new Vector2(screen.Right - ReturnImage().Width, ReturnPosition().Y));
            }

            LeftHit = new Rectangle((int)ReturnPosition().X, (int)ReturnPosition().Y, 10, 12);
            LeftInnerHit = new Rectangle((int)ReturnPosition().X + 10, (int)ReturnPosition().Y, 11, 12);
            MiddleHit = new Rectangle((int)ReturnPosition().X + 21, (int)ReturnPosition().Y, 10, 12);
            RightInnerHit = new Rectangle((int)ReturnPosition().X + 31, (int)ReturnPosition().Y, 11, 12);
            RightHit = new Rectangle((int)ReturnPosition().X + 42, (int)ReturnPosition().Y, 10, 12);

        }

        public override Entity OnCollide(Entity entColliding)
        {
            if (entColliding.GetType() == typeof(Ball))
            {
                
            }

            return entColliding;
        }
        
    }
}
