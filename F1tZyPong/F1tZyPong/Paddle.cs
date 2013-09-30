using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace F1tZyPong
{
    public class PaddleLeft : Entity
    {
        KeyboardState KeyState;
        public SoundEffect Hit;

        public PaddleLeft() : base() { }

        public Rectangle TopCorner = new Rectangle();
        public Rectangle TopOuter = new Rectangle();
        public Rectangle TopCenter = new Rectangle();
        public Rectangle Middle = new Rectangle();
        public Rectangle BottemCenter = new Rectangle();
        public Rectangle BottemOuter = new Rectangle();
        public Rectangle BottomCorner = new Rectangle();


        /// <summary>
        /// Load the image for the paddle
        /// </summary>
        /// <param name="path">the path of the paddle to load</param>
        public override void LoadContent(Texture2D ContentToLoad)
        {
            this.Image = ContentToLoad;
            BoundindBox = Image.Bounds;

            Scale = new Vector2(.5f);
            Rotation = 1.575f;
            Posistion = new Vector2(20, (GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2) - (25));

            //Cretate new rectagle for collison detection
            double newWidth = Image.Height * Math.Sin(Rotation) + Image.Width * Math.Cos(Rotation);
            double newHeight = Image.Height * Math.Cos(Rotation) + Image.Width * Math.Sin(Rotation);
            BoundindBox = new Rectangle((int)(Posistion.X) - 10, (int)(Posistion.Y), (int)(newWidth * Scale.X), (int)(newHeight * Scale.Y)); 

            // Set MultiBox Collisoin detection
            TopCorner = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 5);
            TopCenter = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 18);
            Middle = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 5);
            BottemCenter = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 18);
            BottomCorner = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 5);
        }

        public void LoadAudio(SoundEffect Hit)
        {
            this.Hit = Hit;
        }

        public override void UnloadContent()
        {
            Image.Dispose();
        }

        public void Rest()
        {
            Posistion = new Vector2(20, (GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2) - (25));
        }

        public override void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameState.CurrentState = States.Exit;
            if (KeyState.IsKeyDown(Keys.S)) { this.Volcity.Y = 7; GameState.KMap.S = true;}
            if (KeyState.IsKeyUp(Keys.S) && GameState.KMap.S == true) { this.Volcity.Y += -7; GameState.KMap.S = false;}
            if (KeyState.IsKeyDown(Keys.W)) { this.Volcity.Y = -7; GameState.KMap.W = true; }
            if (KeyState.IsKeyUp(Keys.W) && GameState.KMap.W == true) { this.Volcity.Y += 7; GameState.KMap.W = false; }

           
            Posistion.Y += Volcity.Y;
            
            Posistion.X += Volcity.X;

            this.BoundindBox.X = (int)Posistion.X - 11;
            this.BoundindBox.Y = (int)Posistion.Y;

            this.TopCorner.X = (int)Posistion.X - 11;
            this.TopCorner.Y = (int)Posistion.Y;

            this.TopCenter.X = (int)Posistion.X - 11;
            this.TopCenter.Y = (int)Posistion.Y + 5;

            this.Middle.X = (int)Posistion.X - 11;
            this.Middle.Y = (int)Posistion.Y + 23;

            this.BottemCenter.X = (int)Posistion.X - 11;
            this.BottemCenter.Y = (int)Posistion.Y + 28;

            this.BottomCorner.X = (int)Posistion.X - 11;
            this.BottomCorner.Y = (int)Posistion.Y + 46;


            // screen bounds check and fix
            if (this.Posistion.Y < 0)
            {
                //Volcity.Y = 0;
                Posistion.Y = Posistion.Y + 7;
            }
            else if (this.Posistion.Y > (GameState.spriteBatch.GraphicsDevice.Viewport.Width * Scale.X) + 27)
            {
                Posistion.Y = Posistion.Y - 7;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            //GameState.spriteBatch.Draw(Image, this.Posistion, Color.White);
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 1);

            if (GameState.Debug == true)
            {
                Texture2D FillBoundingBox = new Texture2D(GameState.spriteBatch.GraphicsDevice, 1, 1);
                FillBoundingBox.SetData(new Color[] { Color.White });
                GameState.spriteBatch.Draw(FillBoundingBox, this.BoundindBox, Color.Red);

                GameState.spriteBatch.Draw(FillBoundingBox, this.TopCorner, Color.Yellow);
                GameState.spriteBatch.Draw(FillBoundingBox, this.TopCenter, Color.Blue);
                GameState.spriteBatch.Draw(FillBoundingBox, this.Middle, Color.Yellow);
                GameState.spriteBatch.Draw(FillBoundingBox, this.BottemCenter, Color.Blue);
                GameState.spriteBatch.Draw(FillBoundingBox, this.BottomCorner, Color.Yellow);
            }
        }


    }

    public class PaddleRight : Entity
    {
        KeyboardState KeyState;
        public SoundEffect Hit;

        public Rectangle TopCorner = new Rectangle();
        public Rectangle TopOuter = new Rectangle();
        public Rectangle TopCenter = new Rectangle();
        public Rectangle Middle = new Rectangle();
        public Rectangle BottemCenter = new Rectangle();
        public Rectangle BottemOuter = new Rectangle();
        public Rectangle BottomCorner = new Rectangle();

        public PaddleRight() : base() { }

        /// <summary>
        /// Load the image for the paddle
        /// </summary>
        /// <param name="path">the path of the paddle to load</param>
        public override void LoadContent(Texture2D ContentToLoad)
        {
            this.Image = ContentToLoad;

            Scale = new Vector2(.5f);
            Rotation = 1.575f;
            Posistion = new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width - 10, (GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2) - (25));

            BoundindBox = new Rectangle((int)Posistion.X, (int)Posistion.Y, Image.Width, Image.Height);

            double newWidth = Image.Height * Math.Sin(Rotation) + Image.Width * Math.Cos(Rotation);
            double newHeight = Image.Height * Math.Cos(Rotation) + Image.Width * Math.Sin(Rotation);
            BoundindBox = new Rectangle((int)(Posistion.X), (int)(Posistion.Y), (int)(newWidth * Scale.X), (int)(newHeight * Scale.Y));

            // Set MultiBox Collisoin detection
            TopCorner = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 11, 5);
            TopCenter = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 12, 18);
            Middle = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 12, 5);
            BottemCenter = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 12, 18);
            BottomCorner = new Rectangle(BoundindBox.X, BoundindBox.Center.Y + 10, 12, 5);
        }

        public void LoadAudio(SoundEffect Hit)
        {
            this.Hit = Hit;
        }

        public override void UnloadContent()
        {
            Image.Dispose();
        }

        public void Reset()
        {
            Posistion = new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width - 10, (GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2) - (25));
        }

        public override void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameState.CurrentState = States.Exit;
            if (KeyState.IsKeyDown(Keys.Down)) { this.Volcity.Y = 7; GameState.KMap.ArrowDown = true; }
            if (KeyState.IsKeyUp(Keys.Down) && GameState.KMap.ArrowDown == true) { this.Volcity.Y += -7; GameState.KMap.ArrowDown = false; }
            if (KeyState.IsKeyDown(Keys.Up)) { this.Volcity.Y = -7; GameState.KMap.ArrowUp = true; }
            if (KeyState.IsKeyUp(Keys.Up) && GameState.KMap.ArrowUp == true) { this.Volcity.Y += 7; GameState.KMap.ArrowUp = false; }

            Posistion.X += Volcity.X;
            Posistion.Y += Volcity.Y;

            this.BoundindBox.X = (int)Posistion.X - 12;
            this.BoundindBox.Y = (int)Posistion.Y;

            this.TopCorner.X = (int)Posistion.X - 12;
            this.TopCorner.Y = (int)Posistion.Y;

            this.TopCenter.X = (int)Posistion.X - 12;
            this.TopCenter.Y = (int)Posistion.Y + 5;

            this.Middle.X = (int)Posistion.X - 12;
            this.Middle.Y = (int)Posistion.Y + 23;

            this.BottemCenter.X = (int)Posistion.X - 12;
            this.BottemCenter.Y = (int)Posistion.Y + 28;

            this.BottomCorner.X = (int)Posistion.X - 12;
            this.BottomCorner.Y = (int)Posistion.Y + 46;


            // screen bounds check and fix
            if (this.Posistion.Y < 0)
            {
                //Volcity.Y = 0;
                Posistion.Y = Posistion.Y + 7;
            }
            else if (this.Posistion.Y > (GameState.spriteBatch.GraphicsDevice.Viewport.Width * Scale.X) + 27)
            {
                Posistion.Y = Posistion.Y - 7;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            //GameState.spriteBatch.Draw(Image, this.Posistion, Color.White);
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 1);

            if (GameState.Debug == true)
            {
                Texture2D FillBoundingBox = new Texture2D(GameState.spriteBatch.GraphicsDevice, 1, 1);
                FillBoundingBox.SetData(new Color[] { Color.White });
                GameState.spriteBatch.Draw(FillBoundingBox, this.BoundindBox, Color.Red);

                GameState.spriteBatch.Draw(FillBoundingBox, this.TopCorner, Color.Yellow);
                GameState.spriteBatch.Draw(FillBoundingBox, this.TopCenter, Color.Blue);
                GameState.spriteBatch.Draw(FillBoundingBox, this.Middle, Color.Yellow);
                GameState.spriteBatch.Draw(FillBoundingBox, this.BottemCenter, Color.Blue);
                GameState.spriteBatch.Draw(FillBoundingBox, this.BottomCorner, Color.Yellow);
            }
        }


    }
}
