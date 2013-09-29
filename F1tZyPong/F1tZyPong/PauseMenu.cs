using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyPong
{
   

    public class PauseMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        int SelectedIndex;
        string[] MenuText = { "Resume", "Main Menu", "Exit"};

        Color Normal = Color.White;
        Color Hilight = Color.Red;

        KeyboardState CurrentState;
        KeyboardState OldState;

        SpriteBatch SpriteBatch;
        SpriteFont SpriteFont;

        Vector2 NewGame = Vector2.Zero;
        Vector2 MainMenu = Vector2.Zero;
        Vector2 Exit = Vector2.Zero;

        TimeSpan LastInteraction = new TimeSpan();
       

        public PauseMenu(Game game, SpriteBatch spritebatch, SpriteFont spriteFont)
            : base(game)
        {
            this.SpriteBatch = spritebatch;
            this.SpriteFont = spriteFont;

            NewGame = new Vector2((spritebatch.GraphicsDevice.Viewport.Width / 2) - 100, 100F);
            MainMenu = new Vector2((spritebatch.GraphicsDevice.Viewport.Width / 2) - 100, 150f);
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
                    GameState.CurrentState = States.MainMenu;
                }

                if (SelectedIndex == 2)
                {
                    GameState.CurrentState = States.Exit;
                }
            }

            LastInteraction = gameTime.TotalGameTime;
            OldState = CurrentState;
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (SelectedIndex == 0)
            {
                SpriteBatch.DrawString(SpriteFont, MenuText[0], NewGame, Hilight);
                SpriteBatch.DrawString(SpriteFont, MenuText[1], MainMenu, Normal);
                SpriteBatch.DrawString(SpriteFont, MenuText[2], Exit, Normal);
            }

            if (SelectedIndex == 1)
            {
                SpriteBatch.DrawString(SpriteFont, MenuText[0], NewGame, Normal);
                SpriteBatch.DrawString(SpriteFont, MenuText[1], MainMenu, Hilight);
                SpriteBatch.DrawString(SpriteFont, MenuText[2], Exit, Normal);
            }

            if (SelectedIndex == 2)
            {
                SpriteBatch.DrawString(SpriteFont, MenuText[0], NewGame, Normal);
                SpriteBatch.DrawString(SpriteFont, MenuText[1], MainMenu, Normal);
                SpriteBatch.DrawString(SpriteFont, MenuText[2], Exit, Hilight);
            }

            base.Draw(gameTime);
        }
    }
}
