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
        }

        public void LoadAudio(SoundEffect Hit)
        {
            this.Hit = Hit;
        }

        public override void UnloadContent()
        {
            Image.Dispose();
        }

        public override void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameState.CurrentState = States.Exit;
            if (KeyState.IsKeyDown(Keys.S)) { this.Volcity.Y = 3; GameState.KMap.S = true;}
            if (KeyState.IsKeyUp(Keys.S) && GameState.KMap.S == true) { this.Volcity.Y += -3; GameState.KMap.S = false;}
            if (KeyState.IsKeyDown(Keys.W)) { this.Volcity.Y = -3; GameState.KMap.W = true; }
            if (KeyState.IsKeyUp(Keys.W) && GameState.KMap.W == true) { this.Volcity.Y += 3; GameState.KMap.W = false; }

           
            Posistion.Y += Volcity.Y;
            
            Posistion.X += Volcity.X;

            this.BoundindBox.X = (int)Posistion.X - 11;
            this.BoundindBox.Y = (int)Posistion.Y;

            // screen bounds check and fix
            if (this.Posistion.Y < 0)
            {
                //Volcity.Y = 0;
                Posistion.Y = Posistion.Y + 3;
            }
            else if (this.Posistion.Y > (GameState.spriteBatch.GraphicsDevice.Viewport.Width * Scale.X) + 27)
            {
                Posistion.Y = Posistion.Y - 3;
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
            }
        }


    }

    public class PaddleRight : Entity
    {
        KeyboardState KeyState;
        public SoundEffect Hit;

        public PaddleRight() : base() { }

        /// <summary>
        /// Load the image for the paddle
        /// </summary>
        /// <param name="path">the path of the paddle to load</param>
        public override void LoadContent(Texture2D ContentToLoad)
        {
            this.Image = ContentToLoad;

            Scale = new Vector2(.52f);
            Rotation = 1.575f;
            Posistion = new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width - 10, (GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2) - (25));

            BoundindBox = new Rectangle((int)Posistion.X, (int)Posistion.Y, Image.Width, Image.Height);

            double newWidth = Image.Height * Math.Sin(Rotation) + Image.Width * Math.Cos(Rotation);
            double newHeight = Image.Height * Math.Cos(Rotation) + Image.Width * Math.Sin(Rotation);
            BoundindBox = new Rectangle((int)(Posistion.X), (int)(Posistion.Y), (int)(newWidth * Scale.X), (int)(newHeight * Scale.Y)); 
        }

        public void LoadAudio(SoundEffect Hit)
        {
            this.Hit = Hit;
        }

        public override void UnloadContent()
        {
            Image.Dispose();
        }

        public override void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameState.CurrentState = States.Exit;
            if (KeyState.IsKeyDown(Keys.Down)) { this.Volcity.Y = 3; GameState.KMap.ArrowDown = true; }
            if (KeyState.IsKeyUp(Keys.Down) && GameState.KMap.ArrowDown == true) { this.Volcity.Y += -3; GameState.KMap.ArrowDown = false; }
            if (KeyState.IsKeyDown(Keys.Up)) { this.Volcity.Y = -3; GameState.KMap.ArrowUp = true; }
            if (KeyState.IsKeyUp(Keys.Up) && GameState.KMap.ArrowUp == true) { this.Volcity.Y += 3; GameState.KMap.ArrowUp = false; }

            Posistion.X += Volcity.X;
            Posistion.Y += Volcity.Y;

            this.BoundindBox.X = (int)Posistion.X - 12;
            this.BoundindBox.Y = (int)Posistion.Y;

            // screen bounds check and fix
            if (this.Posistion.Y < 0)
            {
                //Volcity.Y = 0;
                Posistion.Y = Posistion.Y + 3;
            }
            else if (this.Posistion.Y > (GameState.spriteBatch.GraphicsDevice.Viewport.Width * Scale.X) + 11)
            {
                Posistion.Y = Posistion.Y - 3;
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
            }
        }


    }
}
