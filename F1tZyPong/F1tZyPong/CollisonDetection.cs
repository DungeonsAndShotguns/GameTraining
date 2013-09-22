using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1tZyPong
{
    public class CollisonDetection
    {
        Random Rand = new Random();

        public static Ball CollisionDetection(Ball ballToCheck, PaddleLeft leftPaddle, PaddleRight rightPaddle)
        {
            Random Rand = new Random();
            

            if (leftPaddle.BoundindBox.Intersects(ballToCheck.BoundindBox))
            {
                ballToCheck.Posistion.X = (leftPaddle.Posistion.X + leftPaddle.BoundindBox.Width);// -rightPaddle.BoundindBox.Width;

                if (ballToCheck.Volcity.X < 10 && ballToCheck.Volcity.X > -10)
                {
                    ballToCheck.Volcity.X -= 0.5f;
                }

                ballToCheck.Volcity.X = (-1 * ballToCheck.Volcity.X);

                if (ballToCheck.Volcity.Y == 0)
                {
                    if (Rand.Next(0, 10) < 5)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }
                    else
                    {
                        ballToCheck.Volcity.Y = 1;
                    }
                }
                else
                {
                    if (Rand.Next(0, 10) < 5)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }
                    else
                    {
                        ballToCheck.Volcity.Y = 1;
                    }
                }
            }

            if (rightPaddle.BoundindBox.Intersects(ballToCheck.BoundindBox))
            {
                ballToCheck.Posistion.X = (rightPaddle.Posistion.X - rightPaddle.BoundindBox.Width) - rightPaddle.BoundindBox.Width;

                if (ballToCheck.Volcity.X < 10 && ballToCheck.Volcity.X > -10)
                {
                    ballToCheck.Volcity.X += 0.5f;
                }
                
                ballToCheck.Volcity.X = (-1 * ballToCheck.Volcity.X);

                

                if (ballToCheck.Volcity.Y == 0)
                {
                    if (Rand.Next(0, 10) < 5)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }
                    else
                    {
                        ballToCheck.Volcity.Y = 1;
                    }
                }
                else
                {
                    if (Rand.Next(0, 10) < 5)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }
                    else
                    {
                        ballToCheck.Volcity.Y = 1;
                    }
                }
            } 

            return ballToCheck;
        }

    }
}
