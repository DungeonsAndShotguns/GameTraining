using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace F1tZyPong
{
    public class PaddleLeft : Entity
    {
        KeyboardState KeyState;
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
            Posistion = new Vector2(20, 10);
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

            
        }

        public override void Draw(GameTime gameTime)
        {
            //GameState.spriteBatch.Draw(Image, this.Posistion, Color.White);
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 1);
        }


    }

    public class PaddleRight : Entity
    {
        KeyboardState KeyState;
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
            Posistion = new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width - 10, 10);
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
        }

        public override void Draw(GameTime gameTime)
        {
            //GameState.spriteBatch.Draw(Image, this.Posistion, Color.White);
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 1);
        }


    }
}
