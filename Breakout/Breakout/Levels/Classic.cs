using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Breakout.Levels
{
    public class Classic : Level
    {
        public Classic():
            base(null, null, new Rectangle(25, 25, 750, 425))
        {
            //Add Ball and paddle
            Entities.Paddle TempPaddle = new Entities.Paddle(new Vector2(Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2, Game1.spriteBatch.GraphicsDevice.Viewport.Height - 50),
                new Rectangle(100, 400, 52, 12));
            TempPaddle.LoadImage(Game1.Load.Load<Texture2D>("Images\\paddleRed"));
            TempPaddle.ResizeBoundingBox(TempPaddle.ReturnImage());

            Entities.Ball TempBall = new Entities.Ball(new Vector2(Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2, Game1.spriteBatch.GraphicsDevice.Viewport.Height / 2),
                new Rectangle(), 2, Game1.Load.Load<Texture2D>("Images\\ballGrey"));
            TempBall.ResizeBoundingBox(TempBall.ReturnImage());

            this.AddEntity(TempPaddle);
            this.AddEntity(TempBall);
        }
    }
}
