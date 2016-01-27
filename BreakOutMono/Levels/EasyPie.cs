using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Breakout.Levels
{
    public class EasyPie : Level
    {
        public EasyPie(bool drawUI)
            : base(Game1.Load.Load<Texture2D>("images\\background\\Desert"),
                Game1.Load.Load<SpriteFont>("UI"), Game1.Load.Load<SpriteFont>("UISmall"), new Rectangle(25, 25, 750, 425), drawUI)
        {
            SetName("Easy as Pie");
            SetTagLine("\".......\"");
            this.SetBallAmount(3);
            //Add Ball and paddle
            PaddleAdd();
            BallAdd();

            // Add Blocks
            AddBlocks();
        }

        private void PaddleAdd()
        {
            Entities.Paddle TempPaddle = new Entities.Paddle(new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - 40, Game1.spriteBatch.GraphicsDevice.Viewport.Height - 50),
                new Rectangle(100, 400, 52, 12), Game1.Load.Load<SoundEffect>("SoundEffects\\lefthit"));
            TempPaddle.LoadImage(Game1.Load.Load<Texture2D>("images\\paddleRed"));
            TempPaddle.ResizeBoundingBox(TempPaddle.ReturnImage());
            this.AddEntity(TempPaddle);
        }

        private void BallAdd()
        {
            Entities.Ball TempBall = new Entities.Ball(new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - 10, Game1.spriteBatch.GraphicsDevice.Viewport.Height / 2),
                new Rectangle(), 2, Game1.Load.Load<Texture2D>("images\\ballGrey"));
            TempBall.ResizeBoundingBox(TempBall.ReturnImage());
            this.AddEntity(TempBall);
        }

        private void AddBlocks()
        {
            Texture2D[] TempImages = { Game1.Load.Load<Texture2D>("images\\blocks\\GreyBlock"), 
                                         Game1.Load.Load<Texture2D>("images\\blocks\\PurpleBlock"),
                                         Game1.Load.Load<Texture2D>("images\\blocks\\BlueBlock"),
                                         Game1.Load.Load<Texture2D>("images\\blocks\\GreenBlock"),
                                         Game1.Load.Load<Texture2D>("images\\blocks\\YellowBlock"),
                                         Game1.Load.Load<Texture2D>("images\\blocks\\RedBlock")
                                     };
            SoundEffect BreakTemp = Game1.Load.Load<SoundEffect>("SoundEffects\\Break");
            SoundEffect HitTemp = Game1.Load.Load<SoundEffect>("SoundEffects\\Hit");

            int currentX = 31;
            int stepX = 37;

            Entities.Block TempBlock = new Entities.Block();

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 160f), new Rectangle(), true, 1, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }
        }
    }
}
