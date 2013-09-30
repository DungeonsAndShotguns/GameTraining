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
                leftPaddle.Hit.Play();

                ballToCheck.Posistion.X = (leftPaddle.Posistion.X + leftPaddle.BoundindBox.Width);// -rightPaddle.BoundindBox.Width;

                if (ballToCheck.Volcity.X < 12 && ballToCheck.Volcity.X > -12)
                {
                    ballToCheck.Volcity.X -= 0.5f;
                }

                ballToCheck.Volcity.X = (-1 * ballToCheck.Volcity.X);


                // setting the Y based on paddle segments
                if (GameState.NewPhys == true)
                {
                    if (ballToCheck.BoundindBox.Intersects(leftPaddle.TopCorner) == true)
                    {
                        ballToCheck.Volcity.Y = -2;
                        return ballToCheck;
                    }

                    if (ballToCheck.BoundindBox.Intersects(leftPaddle.BottomCorner) == true)
                    {
                        ballToCheck.Volcity.Y = 2;
                        return ballToCheck;
                    }

                    if (ballToCheck.BoundindBox.Intersects(leftPaddle.TopCenter) == true)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }

                    if (ballToCheck.BoundindBox.Intersects(leftPaddle.BottemCenter) == true)
                    {
                        ballToCheck.Volcity.Y = 1;
                    }

                    if (ballToCheck.BoundindBox.Intersects(leftPaddle.Middle) == true)
                    {
                        ballToCheck.Volcity.Y = 0;
                        return ballToCheck;
                    }
                }
                else
                {
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
            }

            if (rightPaddle.BoundindBox.Intersects(ballToCheck.BoundindBox))
            {
                rightPaddle.Hit.Play();

                ballToCheck.Posistion.X = (rightPaddle.Posistion.X - rightPaddle.BoundindBox.Width) - rightPaddle.BoundindBox.Width;

                if (ballToCheck.Volcity.X < 12 && ballToCheck.Volcity.X > -12)
                {
                    ballToCheck.Volcity.X += 0.5f;
                }
                
                ballToCheck.Volcity.X = (-1 * ballToCheck.Volcity.X);

                if (GameState.NewPhys == true)
                {
                    if (ballToCheck.BoundindBox.Intersects(rightPaddle.TopCorner) == true)
                    {
                        ballToCheck.Volcity.Y = -2;
                        return ballToCheck;
                    }

                    if (ballToCheck.BoundindBox.Intersects(rightPaddle.BottomCorner) == true)
                    {
                        ballToCheck.Volcity.Y = 2;
                        return ballToCheck;
                    }

                    if (ballToCheck.BoundindBox.Intersects(rightPaddle.TopCenter) == true)
                    {
                        ballToCheck.Volcity.Y = -1;
                    }

                    if (ballToCheck.BoundindBox.Intersects(rightPaddle.BottemCenter) == true)
                    {
                        ballToCheck.Volcity.Y = 1;
                    }

                    if (ballToCheck.BoundindBox.Intersects(rightPaddle.Middle) == true)
                    {
                        ballToCheck.Volcity.Y = 0;
                        return ballToCheck;
                    }
                }
                else
                {

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
            } 

            return ballToCheck;
        }

    }
}
