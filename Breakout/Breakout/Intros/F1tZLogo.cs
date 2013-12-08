using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    public class F1tZLogo
    {
        private ContentManager Content;
        private Texture2D Logo;
        private SoundEffect LogoSound;
        private SpriteFont Font;

        private bool SoundPlayed = false;

        private TimeSpan EndIntroTime;
        private TimeSpan StartTime;

        private float FontScale;
        private float FontOffSetX;
        private float FontOffSetY;
        private bool One = false;
        private bool Two = false;
        private bool Three = false;
        private bool Four = false;
        private bool Five = false;

        public F1tZLogo(ContentManager Content)
        {
            this.Content = Content;
            LoadContent();
            FontScale = 4f;
            FontOffSetX = 120f;
            FontOffSetY = -170f;
        }

        public void LoadContent()
        {
            Logo = Content.Load<Texture2D>("f1tz\\f1tzlogo");
            LogoSound = Content.Load<SoundEffect>("f1tz\\f1tzlogoaudio");
            Font = Content.Load<SpriteFont>("f1tz\\F1tZ");
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime > StartTime.Add(new TimeSpan(0, 0, 0, 0, 500)))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    //Game1.CurrentState = States.MainMenu;
                }
            }

            if (SoundPlayed == false)
            {
                StartTime = gameTime.TotalGameTime;
                EndIntroTime = (gameTime.TotalGameTime).Add(LogoSound.Duration).Add(new TimeSpan(0,0,2));
                LogoSound.Play();
                SoundPlayed = true;
                One = true;
            }

            if (gameTime.TotalGameTime > EndIntroTime)
            {
                Game1.CurrentState = GameStates.MainMenu;
            }

            if (gameTime.TotalGameTime > StartTime.Add(new TimeSpan(0, 0, 0, 0, 100)))
            {
                Two = true;
            }

            if (gameTime.TotalGameTime > StartTime.Add(new TimeSpan(0, 0, 0, 0, 200)))
            {
                Three = true;
            }

            if (gameTime.TotalGameTime > StartTime.Add(new TimeSpan(0, 0, 0, 0, 300)))
            {
                Four = true;
            }

            if (gameTime.TotalGameTime > StartTime.Add(new TimeSpan(0, 0, 0, 0, 400)))
            {
                Five = true;
            }

        }

        public void Draw(GameTime gameTime)
        {
            if (One == true)
            {
                Game1.spriteBatch.DrawString(Font, "F", new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - FontOffSetX, (Game1.spriteBatch.GraphicsDevice.Viewport.Height) + FontOffSetY), Color.White, 0, Vector2.Zero, FontScale, SpriteEffects.None, 0f);
            }

            if (Two == true)
            {
                Game1.spriteBatch.DrawString(Font, "F1", new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - FontOffSetX, (Game1.spriteBatch.GraphicsDevice.Viewport.Height) + FontOffSetY), Color.White, 0, Vector2.Zero, FontScale, SpriteEffects.None, 0f);
            }

            if (Three == true)
            {
                Game1.spriteBatch.DrawString(Font, "F1t", new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - FontOffSetX, (Game1.spriteBatch.GraphicsDevice.Viewport.Height) + FontOffSetY), Color.White, 0, Vector2.Zero, FontScale, SpriteEffects.None, 0f);
            }

            if (Four == true)
            {
                Game1.spriteBatch.DrawString(Font, "F1tZ", new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - FontOffSetX, (Game1.spriteBatch.GraphicsDevice.Viewport.Height) + FontOffSetY), Color.White, 0, Vector2.Zero, FontScale, SpriteEffects.None, 0f);
            }

            if (Five == true)
            {
                Game1.spriteBatch.DrawString(Font, "F1tZy", new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) - FontOffSetX, (Game1.spriteBatch.GraphicsDevice.Viewport.Height) + FontOffSetY), Color.White, 0, Vector2.Zero, FontScale, SpriteEffects.None, 0f);
            }

            Game1.spriteBatch.Draw(Logo, new Vector2((Game1.spriteBatch.GraphicsDevice.Viewport.Width / 2) -150, (Game1.spriteBatch.GraphicsDevice.Viewport.Height / 2) - 200), null, Color.White, 0, Vector2.Zero, 3f, SpriteEffects.None, 0f);
        }

    }
}
