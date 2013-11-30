using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Entities
{
    public class Ball : Entity
    {
        float Speed { get; set; }
        Vector2 Direction { get; set; }
        bool InMovment { get; set; }

        public Ball(Vector2 startPosition, Rectangle boundingBox, float BaseSpeed, Texture2D image)
            : base(startPosition, boundingBox, true)
        {
            Speed = BaseSpeed;
            this.LoadImage(image);
            InMovment = false;
            Direction = new Vector2();
        }

        public void ToggleMovment()
        {
            if (InMovment == true)
            {
                InMovment = false;
            }
            else
            {
                InMovment = true;
            }
        }

        public void SetDirection(float x, float y)
        {
            Direction = new Vector2(x, y);
        }

        public override Entity OnCollide(Entity entColliding)
        {
            #region Paddle
            if (entColliding.GetType() == typeof(Entities.Paddle))
            {
                if (this.ReturnBoundingBox().Intersects(((Paddle)entColliding).RightInnerHit) == true)
                {
                    Direction = new Vector2(0.5f, -1 * Direction.Y);
                    return this;
                }

                if (this.ReturnBoundingBox().Intersects(((Paddle)entColliding).LeftInnerHit) == true)
                {
                    Direction = new Vector2(-0.5f, -1 * Direction.Y);
                    return this;
                }

                if (this.ReturnBoundingBox().Intersects(((Paddle)entColliding).RightHit) == true)
                {
                    Direction = new Vector2(1, -1 * Direction.Y);
                    return this;
                }

                if (this.ReturnBoundingBox().Intersects(((Paddle)entColliding).LeftHit) == true)
                {
                    Direction = new Vector2(-1, -1 * Direction.Y);
                    return this;
                }

                if (this.ReturnBoundingBox().Intersects(((Paddle)entColliding).MiddleHit) == true)
                {
                    Direction = new Vector2(Direction.X, -1 * Direction.Y);
                    return this;
                }
            }
            #endregion

            #region Block
            if (entColliding.GetType() == typeof(Entities.Block))
            {
                ((Block)entColliding).DamageBlock(1);

                Direction = new Vector2(Direction.X, -1 * Direction.Y);
            }
            #endregion

            return base.OnCollide(entColliding);
        }

        public override void Update(GameTime gameTime, Rectangle screen)
        {
            if (InMovment == true)
            {
                SetPosition(new Vector2(ReturnPosition().X + (Speed * Direction.X), ReturnPosition().Y + (Speed * Direction.Y)));
            }

            if (ReturnPosition().Y > screen.Bottom)
            {
                //TODO: remove this in favor of a ball death
                SetPosition(new Vector2(ReturnPosition().X, screen.Bottom - ReturnImage().Height));
                Direction = new Vector2(Direction.X, -1 * Direction.Y);
            }

            if (ReturnPosition().Y < screen.Top)
            {
                SetPosition(new Vector2(ReturnPosition().X, screen.Top));
                Direction = new Vector2(Direction.X, -1 * Direction.Y);
            }

            if (ReturnPosition().X < screen.Left)
            {
                SetPosition(new Vector2(screen.Left, ReturnPosition().Y));
                Direction = new Vector2(-1 *Direction.X, Direction.Y);
            }

            if (ReturnPosition().X > screen.Right)
            {
                SetPosition(new Vector2(screen.Right, ReturnPosition().Y));
                Direction = new Vector2(-1 * Direction.X, Direction.Y);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(ReturnImage(), ReturnPosition(), Color.White);

            if (Game1.Debug == true)
            {
                Texture2D BoundingDraw = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                BoundingDraw.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(BoundingDraw, this.ReturnBoundingBox(), Color.DarkRed);
            }
        }

    }
}
