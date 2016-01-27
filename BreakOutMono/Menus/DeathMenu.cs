using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Menus
{
    

    public class DeathMenu
    { 
        int CurrentSelction { get; set; } // 0 = retry, 1 = MainMenu, 2 = Mute
        Rectangle MenuScreen { get; set; }
        Rectangle InnerScreen { get; set; }
        SpriteFont UIFont { get; set; }
        Texture2D BlockRed { get; set; }
        Texture2D BlockGrey { get; set; }
        KeyboardState LastKeyHit = new KeyboardState();

        public DeathMenu()
        {
            MenuScreen = new Rectangle(300,
                100, 180, 140);

            InnerScreen = new Rectangle(MenuScreen.X + 10, MenuScreen.Y + 40, 160, 100);

            CurrentSelction = 0; // Retry

            UIFont = Game1.Load.Load<SpriteFont>("UI");
            BlockRed = Game1.Load.Load<Texture2D>("Images\\blocks\\RedBlock");
            BlockGrey = Game1.Load.Load<Texture2D>("Images\\blocks\\GreyBlock");
        }

        public void Update(GameTime gameTime)
        {
            #region Keyboard
            KeyboardState CurrentKeyState = Keyboard.GetState();

            if (CurrentKeyState.IsKeyDown(Keys.Down) && LastKeyHit.IsKeyUp(Keys.Down))
            {
                if (CurrentSelction < 2)
                {
                    CurrentSelction = CurrentSelction + 1;
                }
                else
                {
                    CurrentSelction = 0;
                }
            }

            if (CurrentKeyState.IsKeyDown(Keys.Up) && LastKeyHit.IsKeyUp(Keys.Up))
            {
                if (CurrentSelction == 0)
                {
                    CurrentSelction = 2;
                }
                else
                {
                    CurrentSelction = CurrentSelction - 1;
                }
            }

            if (CurrentKeyState.IsKeyDown(Keys.Enter) && LastKeyHit.IsKeyUp(Keys.Enter))
            {
                if (CurrentSelction == 0)
                {
                    if (Game1.Level1.GetType() == typeof(Levels.Classic))
                    {
                        Game1.Level1 = new Levels.Classic(true);
                        Game1.Level1.Load();
                        Game1.CurrentState = GameStates.InGame;
                    }

                    if (Game1.Level1.GetType() == typeof(Levels.EasyPie))
                    {
                        Game1.Level1 = new Levels.EasyPie(true);
                        Game1.Level1.Load();
                        Game1.CurrentState = GameStates.InGame;
                    }
                }

                if (CurrentSelction == 1)
                {
                    Game1.CurrentState = GameStates.MainMenu;
                }

                if (CurrentSelction == 2)
                {
                    if (Game1.Mute == false)
                    {
                        Game1.Mute = true;
                    }
                    else
                    {
                        Game1.Mute = false;
                    }
                }
            }

            LastKeyHit = CurrentKeyState;
            #endregion
        }

        public void Draw(GameTime gameTime)
        {
            Texture2D Backgound = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            Backgound.SetData(new Color[] { Color.White });

            Game1.spriteBatch.Draw(Backgound, MenuScreen, Color.Black);

            #region Border
            int xStep = 36;
            int yStep = 10;
            int startX = MenuScreen.X;
            int startY = MenuScreen.Y;
            int currentX = MenuScreen.X - xStep;
            int currentY = MenuScreen.Y - yStep;

            while (currentY < MenuScreen.Bottom)
            {
                currentY += yStep;

                while (currentX < MenuScreen.Right - 36)
                {
                    currentX += xStep;

                    Game1.spriteBatch.Draw(BlockGrey, new Vector2(currentX, currentY), Color.White);
                }

                currentX = startX - 36;
            }
            #endregion

            #region Insult
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 12, MenuScreen.Y + 8), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 42, MenuScreen.Y + 8), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 78, MenuScreen.Y + 8), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 98, MenuScreen.Y + 8), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 128, MenuScreen.Y + 8), Color.Brown);

            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 12, MenuScreen.Y + 18), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 42, MenuScreen.Y + 18), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 78, MenuScreen.Y + 18), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 98, MenuScreen.Y + 18), Color.Brown);
            Game1.spriteBatch.Draw(BlockRed, new Vector2(MenuScreen.X + 128, MenuScreen.Y + 18), Color.Brown);
            Game1.spriteBatch.DrawString(UIFont, "You Are Balless", new Vector2(MenuScreen.X + 14, MenuScreen.Y + 8), Color.White);
            #endregion

            #region InnerBox
            Game1.spriteBatch.Draw(Backgound, InnerScreen, Color.Black);
            #endregion

            if (CurrentSelction == 0)
            {
                Game1.spriteBatch.DrawString(UIFont, "Retry", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 10), Color.Blue);
                Game1.spriteBatch.DrawString(UIFont, "Main Menu", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 40), Color.White);
                Game1.spriteBatch.DrawString(UIFont, "Mute", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 70), Color.White);
            }

            if (CurrentSelction == 1)
            {
                Game1.spriteBatch.DrawString(UIFont, "Retry", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 10), Color.White);
                Game1.spriteBatch.DrawString(UIFont, "Main Menu", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 40), Color.Blue);
                Game1.spriteBatch.DrawString(UIFont, "Mute", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 70), Color.White);
            }

            if (CurrentSelction == 2)
            {
                Game1.spriteBatch.DrawString(UIFont, "Retry", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 10), Color.White);
                Game1.spriteBatch.DrawString(UIFont, "Main Menu", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 40), Color.White);
                Game1.spriteBatch.DrawString(UIFont, "Mute", new Vector2(InnerScreen.X + 10, InnerScreen.Y + 70), Color.Blue);
            }
        }
    }
}
