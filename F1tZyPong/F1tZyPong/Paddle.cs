using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace F1tZyPong
{
    public class Paddle : Entity
    {
        KeyboardState KeyState;
        public Paddle() : base() { }

        /// <summary>
        /// Load the image for the paddle
        /// </summary>
        /// <param name="path">the path of the paddle to load</param>
        public override void LoadContent(Texture2D ContentToLoad)
        {
            this.Image = ContentToLoad;
        }

        public override void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameState.CurrentState = States.Exit;
            if (KeyState.IsKeyDown(Keys.Down)) { this.Volcity.Y = 1; }
        }


    }
}
