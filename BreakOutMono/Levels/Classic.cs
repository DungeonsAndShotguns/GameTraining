using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Breakout.Levels
{
    public class Classic : Level
    {
        public Classic(bool drawUI):
            base(Game1.Load.Load<Texture2D>("images\\background\\StarField"), 
            Game1.Load.Load<SpriteFont>("UI"), Game1.Load.Load<SpriteFont>("UISmall"),new Rectangle(25, 25, 750, 425), drawUI)
        {
            SetName("Classic");
            SetTagLine("\"I've seen this before\"");
            this.SetBallAmount(1);
            //Add Ball and paddle
            PaddleAdd();
            BallAdd();
            
            // Add Blocks
            AddBlocks();
        }

        private void PaddleAdd()
        {
            Entities.Paddle TempPaddle = new Entities.Paddle(new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - 40 , Game1.spriteBatch.GraphicsDevice.Viewport.Height - 50),
                new Rectangle(100, 400, 52, 12), Game1.Load.Load<SoundEffect>("SoundEffects\\lefthit"));
            TempPaddle.LoadImage(Game1.Load.Load<Texture2D>("images\\paddleRed"));
            TempPaddle.ResizeBoundingBox(TempPaddle.ReturnImage());
            this.AddEntity(TempPaddle);
        }

        private void BallAdd()
        {
            Entities.Ball TempBall = new Entities.Ball(new Vector2(Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2 - 10, Game1.spriteBatch.GraphicsDevice.Viewport.Height / 2),
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

            currentX = 31;
            stepX = 37;

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 140f), new Rectangle(), true, 2, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }

            currentX = 31;
            stepX = 37;

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 120f), new Rectangle(), true, 3, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }

            currentX = 31;
            stepX = 37;

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 100f), new Rectangle(), true, 4, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }

            currentX = 31;
            stepX = 37;

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 80f), new Rectangle(), true, 5, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }

            currentX = 31;
            stepX = 37;

            while (currentX < 750)
            {


                TempBlock = new Entities.Block(new Vector2(currentX, 60f), new Rectangle(), true, 6, TempImages, BreakTemp, HitTemp);
                TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
                this.AddEntity(TempBlock);

                currentX = currentX + stepX;
            }

            //Entities.Block TempBlock = new Entities.Block(new Vector2(26f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(64f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(102f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(140f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(178f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(216f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(254f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(292f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(330f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(368f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(406f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(444f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(482f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(520f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(558f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(596f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(634f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(672f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            //TempBlock = new Entities.Block(new Vector2(710f, 100f), new Rectangle(), true, 1, TempImages);
            //TempBlock.ResizeBoundingBox(TempBlock.ReturnImage());
            //this.AddEntity(TempBlock);

            

            //this.AddEntity(TempBlock.SetBlockPos(new Vector2(48f, 100f)));
        }
    }
}
