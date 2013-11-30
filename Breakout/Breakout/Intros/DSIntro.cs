using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Breakout;

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

        private TimeSpan EndIntroTime;
        private TimeSpan StartTime;

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
            StartImage = Content.Load<Texture2D>("DS\\startG");
            RackImage = Content.Load<Texture2D>("DS\\cockG");
            EndImage = Content.Load<Texture2D>("DS\\EndG");
            IntroSound = Content.Load<SoundEffect>("DS\\DSLogoAudio");
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                Game1.CurrentState = GameStates.PersonalIntro;

                Game1.graphics.PreferredBackBufferHeight = 480;
                Game1.graphics.PreferredBackBufferWidth = 800;
                Game1.graphics.ApplyChanges();
            }

            if (SoundPalyed == false)
            {
                IntroSound.Play();
                SoundPalyed = true;
                State = IntroSatate.Start;

                Game1.graphics.PreferredBackBufferHeight = 480;
                Game1.graphics.PreferredBackBufferWidth = 640;
                Game1.graphics.ApplyChanges();
            }

            if (gameTime.TotalGameTime.TotalMilliseconds > StartTime.Add(new TimeSpan(0, 0, 0, 0, 1)).TotalMilliseconds && State == IntroSatate.Start)
            {
                StartTime = gameTime.TotalGameTime;
                State = IntroSatate.Rack;
            }

            if (gameTime.TotalGameTime.TotalMilliseconds > StartTime.Add(new TimeSpan(0,0,0,0,860)).TotalMilliseconds && State == IntroSatate.Rack)
            {
                State = IntroSatate.End;
            }

            if (gameTime.TotalGameTime.TotalMilliseconds > StartTime.Add(new TimeSpan(0, 0, 0, 0, 6)).TotalMilliseconds && State == IntroSatate.End)
            {
                Game1.graphics.PreferredBackBufferHeight = 480;
                Game1.graphics.PreferredBackBufferWidth = 800;
                Game1.graphics.ApplyChanges();

                Game1.CurrentState = GameStates.PersonalIntro;
            }
        }

        public void Draw(GameTime gameTime)
        {
            if(State == IntroSatate.Start)
            {
                Game1.spriteBatch.Draw(StartImage, Vector2.Zero, Color.White);
            }

            if (State == IntroSatate.Rack)
            {
                Game1.spriteBatch.Draw(RackImage, Vector2.Zero, Color.White);
            }

            if (State == IntroSatate.End)
            {
                Game1.spriteBatch.Draw(EndImage, Vector2.Zero, Color.White);
            }
        }
    }
}
