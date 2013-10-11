using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace F1tZyWorm
{
    public class Worm : Entitty
    {
        public List<WormBit> WormBody { get; set; } // the body of the worm minus the head

        public Worm() { }

        public Worm(Vector2 initPOS, Texture2D entImage) : base (initPOS, entImage)
        {
            // Set the initial Volicity
            this.Volicity = new Vector2(States.WormSpeed, 0);

            this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
        }

        public override void Update(GameTime gameTime)
        {
            // o the grate and wonderful control scheme
            // We check to see if the key is being hit and was not hit previously
            // this allows us to hold down a key and not interfere with the next input
            if (Keyboard.GetState().IsKeyDown(Keys.Down) == true && States.PreviousKeyState.IsKeyDown(Keys.Down) == false)
            {
                this.Volicity = new Vector2(0, States.WormSpeed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) == true && States.PreviousKeyState.IsKeyDown(Keys.Up) == false)
            {
                this.Volicity = new Vector2(0, (-1 * States.WormSpeed));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) == true && States.PreviousKeyState.IsKeyDown(Keys.Right) == false)
            {
                this.Volicity = new Vector2(States.WormSpeed, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) == true && States.PreviousKeyState.IsKeyDown(Keys.Left) == false)
            {
                this.Volicity = new Vector2((-1 * States.WormSpeed), 0);
            }

            // recoard the previous key state to use for comparision next tick
            States.PreviousKeyState = Keyboard.GetState();

            // update the worms position (heads position actully)
            this.Position += Volicity;
        }

        public override void Draw(GameTime gmaeTime)
        {
            Renderers.spriteBatch.Draw(this.Image, Position, Color.White);
        }
    }
}
