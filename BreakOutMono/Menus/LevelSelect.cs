using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Breakout.Menus
{
    public class LevelSelect
    {
        int CurrentSelection = 0; //0 = Choose Level, 1 = Options, 2 = Exit
        SpriteFont UIFont { get; set; }
        KeyboardState LastKeyHit = new KeyboardState();
        Level CurrentDisplayLevel = new Level();

        public LevelSelect()
        {
            UIFont = Game1.Load.Load<SpriteFont>("UI");
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Add(-Game1.LastIneractTime) > new TimeSpan(0, 0, 0, 0, 500))
            {

                #region Keyboard
                KeyboardState CurrentKeyState = Keyboard.GetState();

                if (CurrentKeyState.IsKeyDown(Keys.Right) && LastKeyHit.IsKeyUp(Keys.Right))
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

                if (CurrentKeyState.IsKeyDown(Keys.Left) && LastKeyHit.IsKeyUp(Keys.Left))
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
                        Game1.Level1 = new Levels.Classic(true);
                        Game1.Level1.Load();
                        Game1.CurrentState = GameStates.InGame;
                    }

                    if (CurrentSelection == 1)
                    {
                        Game1.Level1 = new Levels.EasyPie(true);
                        Game1.Level1.Load();
                        Game1.CurrentState = GameStates.InGame;
                    }

                    if (CurrentSelection == 2)
                    {
                        Game1.CurrentState = GameStates.MainMenu;
                    }
                }

                LastKeyHit = CurrentKeyState;
                #endregion

                if (CurrentSelection == 0)
                {
                    CurrentDisplayLevel = new Levels.Classic(false);
                }

                if (CurrentSelection == 1)
                {
                    CurrentDisplayLevel = new Levels.EasyPie(false);
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            CurrentDisplayLevel.Draw(gameTime);

            if (CurrentSelection == 2)
            {
                Rectangle ClearScreen = new Rectangle(0, 0, Game1.spriteBatch.GraphicsDevice.Viewport.Width, Game1.spriteBatch.GraphicsDevice.Viewport.Height);
                Texture2D Backgound = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                Backgound.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(Backgound, ClearScreen, Color.Black);

                Game1.spriteBatch.DrawString(UIFont, "Back To Main Menu", new Vector2(300, 450), Color.White);
                return;
            }

            Game1.spriteBatch.DrawString(UIFont, CurrentDisplayLevel.GetName(), new Vector2(350, 450), Color.White);

        }

    }
}
