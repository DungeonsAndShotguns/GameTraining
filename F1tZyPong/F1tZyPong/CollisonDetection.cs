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
