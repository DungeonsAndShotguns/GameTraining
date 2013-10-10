using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace F1tZyPong
{
    public enum IntroSatate
    {
        Start, Rack, End, Blank
    }

    public class DSIntro
    {
        //private SpriteBatch spriteBatch;
        private ContentManager Content;
        //private TimeSpan IntroStart;

        private Texture2D StartImage;
        private Texture2D RackImage;
        private Texture2D EndImage;

        private SoundEffect IntroSound;

        private bool SoundPalyed = false;
        private IntroSatate State = IntroSatate.Blank;

        public DSIntro(ContentManager Content) 
        {
            //spriteBatch = BatchToUse;
            this.Content = Content;
            LoadContent();
            //IntroStart = CurrentTime.TotalGameTime;
            

            //GameState.CurrentState = States.Intro;
            
        }

        public void LoadContent()
        {
            StartImage = Content.Load<Texture2D>("Intro\\startG");
            RackImage = Content.Load<Texture2D>("Intro\\cockG");
            EndImage = Content.Load<Texture2D>("Intro\\EndG");
            IntroSound = Content.Load<SoundEffect>("Intro\\DSLogoAudio");
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                GameState.CurrentState = States.F1tZIntro;

                GameState.graphics.PreferredBackBufferHeight = 480;
                GameState.graphics.PreferredBackBufferWidth = 800;
                GameState.graphics.ApplyChanges();
            }

            if (SoundPalyed == false)
            {
                IntroSound.Play();
                SoundPalyed = true;
                State = IntroSatate.Start;

                GameState.graphics.PreferredBackBufferHeight = 480;
                GameState.graphics.PreferredBackBufferWidth = 640;
                GameState.graphics.ApplyChanges();
            }

            if (gameTime.TotalGameTime.Ticks > 1 && State == IntroSatate.Start)
            {
                State = IntroSatate.Rack;
            }

            if (gameTime.TotalGameTime.TotalMilliseconds > 860 && State == IntroSatate.Rack)
            {
                State = IntroSatate.End;
            }

            if (gameTime.TotalGameTime.TotalSeconds > 6 && State == IntroSatate.End)
            {
                GameState.graphics.PreferredBackBufferHeight = 480;
                GameState.graphics.PreferredBackBufferWidth = 800;
                GameState.graphics.ApplyChanges();

                GameState.CurrentState = States.F1tZIntro;
            }
        }

        public void Draw(GameTime gameTime)
        {
            if(State == IntroSatate.Start)
            {
                GameState.spriteBatch.Draw(StartImage, Vector2.Zero, Color.White);
            }

            if (State == IntroSatate.Rack)
            {
                GameState.spriteBatch.Draw(RackImage, Vector2.Zero, Color.White);
            }

            if (State == IntroSatate.End)
            {
                GameState.spriteBatch.Draw(EndImage, Vector2.Zero, Color.White);
            }
        }
    }
}
