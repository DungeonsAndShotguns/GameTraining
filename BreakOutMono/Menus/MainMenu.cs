using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Breakout.Menus
{
    public class MainMenu
    {
        int CurrentSelection = 0; //0 = Choose Level, 1 = Options, 2 = Exit
        SpriteFont UIFont { get; set; }
        KeyboardState LastKeyHit = new KeyboardState();

        public MainMenu()
        {
            UIFont = Game1.Load.Load<SpriteFont>("UI");
        }

        public void Update(GameTime gameTime)
        {
            #region Keyboard
            KeyboardState CurrentKeyState = Keyboard.GetState();

            if (CurrentKeyState.IsKeyDown(Keys.Down) && LastKeyHit.IsKeyUp(Keys.Down))
            {
                if (CurrentSelection < 2)
                {
                    CurrentSelection = CurrentSelection + 1;
                }
                else
                {
                    CurrentSelection = 0;
                }
            }

            if (CurrentKeyState.IsKeyDown(Keys.Up) && LastKeyHit.IsKeyUp(Keys.Up))
            {
                if (CurrentSelection == 0)
                {
                    CurrentSelection = 2;
                }
                else
                {
                    CurrentSelection = CurrentSelection - 1;
                }
            }

            if (CurrentKeyState.IsKeyDown(Keys.Enter) && LastKeyHit.IsKeyUp(Keys.Enter))
            {
                if (CurrentSelection == 0)
                {
                    Game1.CurrentState = GameStates.LevelSelect;
                }

                if (CurrentSelection == 1)
                {
                    
                }

                if (CurrentSelection == 2)
                {
                    Game1.CurrentState = GameStates.Exit;
                }
            }

            LastKeyHit = CurrentKeyState;


            #endregion

            Game1.LastIneractTime = gameTime.TotalGameTime;
        }

        public void Draw(GameTime gameTime)
        {
            switch (CurrentSelection)
            {
                case 0:
                    Game1.spriteBatch.DrawString(UIFont, "Choose Level", new Vector2(200, 50), Color.Blue);
                    Game1.spriteBatch.DrawString(UIFont, "Options", new Vector2(200, 70), Color.White);
                    Game1.spriteBatch.DrawString(UIFont, "Exit", new Vector2(200, 90), Color.White);
                    break;
                case 1:
                    Game1.spriteBatch.DrawString(UIFont, "Choose Level", new Vector2(200, 50), Color.White);
                    Game1.spriteBatch.DrawString(UIFont, "Options", new Vector2(200, 70), Color.Blue);
                    Game1.spriteBatch.DrawString(UIFont, "Exit", new Vector2(200, 90), Color.White);
                    break;
                case 2:
                    Game1.spriteBatch.DrawString(UIFont, "Choose Level", new Vector2(200, 50), Color.White);
                    Game1.spriteBatch.DrawString(UIFont, "Options", new Vector2(200, 70), Color.White);
                    Game1.spriteBatch.DrawString(UIFont, "Exit", new Vector2(200, 90), Color.Blue);
                    break;
            }
        }
    }
}
