using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyPong
{
   

    public class MainMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        int SelectedIndex;
        string[] MenuText = { "New Game", "Replay Intros", "Exit"};

        Color Normal = Color.White;
        Color Hilight = Color.Red;

        KeyboardState CurrentState;
        KeyboardState OldState;

        GamePadState PlayOneState;

        SpriteBatch SpriteBatch;
        SpriteFont SpriteFont;

        Vector2 NewGame = Vector2.Zero;
        Vector2 ReplayIntros = Vector2.Zero;
        Vector2 Exit = Vector2.Zero;

        //TimeSpan LastInteraction = new TimeSpan();
       

        public MainMenu(Game game, SpriteBatch spritebatch, SpriteFont spriteFont)
            : base(game)
        {
            this.SpriteBatch = spritebatch;
            this.SpriteFont = spriteFont;

            NewGame = new Vector2((spritebatch.GraphicsDevice.Viewport.Width / 2) - 100, 100F);
            ReplayIntros = new Vector2((spritebatch.GraphicsDevice.Viewport.Width / 2)- 100, 150f);
            Exit = new Vector2((spritebatch.GraphicsDevice.Viewport.Width / 2)- 100, 200f);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();

            if (CurrentState.IsKeyDown(Keys.Down) && OldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == MenuText.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if (CurrentState.IsKeyDown(Keys.Up) && OldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if (SelectedIndex < 0)
                {
                    SelectedIndex = MenuText.Length - 1;
                }
            }

            if (CurrentState.IsKeyDown(Keys.Enter) && OldState.IsKeyUp(Keys.Enter))
            {
                if (SelectedIndex == 0)
                {
                    GameState.CurrentState = States.Ingame;
                }

                if (SelectedIndex == 1)
                {
                    GameState.CurrentState = States.Intro;
                }

                if (SelectedIndex == 2)
                {
                    GameState.CurrentState = States.Exit;
                }
            }

            if(GamePad.GetCapabilities(PlayerIndex.One).IsConnected)
            {
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed && PlayOneState.DPad.Down == ButtonState.Released)
                {
                    SelectedIndex++;
                    if (SelectedIndex == MenuText.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed && PlayOneState.DPad.Up == ButtonState.Released)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = MenuText.Length - 1;
                    }
                }

                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    if (SelectedIndex == 0)
                    {
                        GameState.CurrentState = States.Ingame;
                    }

                    if (SelectedIndex == 1)
                    {
                        GameState.CurrentState = States.Intro;
                    }

                    if (SelectedIndex == 2)
                    {
                        GameState.CurrentState = States.Exit;
                    }
                }
                
                /* My 360 contoller seems to be a bit broken, I can only use the D Pad
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y >= 0)
                {
                    SelectedIndex++;
                    if (SelectedIndex == MenuText.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed && PlayOneState.DPad.Down == ButtonState.Released)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = MenuText.Length - 1;
                    }
                }
                 */

                PlayOneState = GamePad.GetState(PlayerIndex.One);
            }

            //LastInteraction = gameTime.TotalGameTime;
            OldState = CurrentState;
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (SelectedIndex == 0)
            {
                SpriteBatch.DrawString(SpriteFont, "New Game", NewGame, Hilight);
                SpriteBatch.DrawString(SpriteFont, "Replay Intros", ReplayIntros, Normal);
                SpriteBatch.DrawString(SpriteFont, "Exit", Exit, Normal);
            }

            if (SelectedIndex == 1)
            {
                SpriteBatch.DrawString(SpriteFont, "New Game", NewGame, Normal);
                SpriteBatch.DrawString(SpriteFont, "Replay Intros", ReplayIntros, Hilight);
                SpriteBatch.DrawString(SpriteFont, "Exit", Exit, Normal);
            }

            if (SelectedIndex == 2)
            {
                SpriteBatch.DrawString(SpriteFont, "New Game", NewGame, Normal);
                SpriteBatch.DrawString(SpriteFont, "Replay Intros", ReplayIntros, Normal);
                SpriteBatch.DrawString(SpriteFont, "Exit", Exit, Hilight);
            }

            //SpriteBatch.DrawString(SpriteFont, "X: " + GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X.ToString() + " Y: " + GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X.ToString(),
            //    new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2, GameState.spriteBatch.GraphicsDevice.Viewport.Height - 20), Color.White);

            base.Draw(gameTime);
        }
    }
}
