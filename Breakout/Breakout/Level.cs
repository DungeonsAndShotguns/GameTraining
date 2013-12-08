using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    public class Level
    {
        List<Entity> LevelEntites = new List<Entity>();

        Texture2D Background = null;
        SpriteFont UIFont = null;
        SpriteFont UISmallFont = null;
        Rectangle PlaySurface = new Rectangle();
        int Score = 0;
        int BallAmount = 1;
        string LevelName = string.Empty;
        string TagLine = string.Empty;
        string DeathMessage = string.Empty;
        bool ResetPOS = false;
        bool DrawUI = true;

        public Level() { }

        public Level(Texture2D backgroundImage, SpriteFont uiFont, SpriteFont uiSmallFont ,Rectangle playSurface, bool drawUI)
        {
            Background = backgroundImage;
            UIFont = uiFont;
            UISmallFont = uiSmallFont;
            PlaySurface = playSurface;
            DrawUI = drawUI;
        }

        public void SetBackground(Texture2D bg)
        {
            Background = bg;
        }

        public void SetName(string name)
        {
            LevelName = name;
        }

        public void SetTagLine(string tagLine)
        {
            TagLine = tagLine;
        }

        public void SetBallAmount(int balls)
        {
            BallAmount = balls;
        }

        public string GetName()
        {
            return LevelName;
        }

        public Level AddEntity(Entity entToAdd)
        {
            LevelEntites.Add(entToAdd);
            return this;
        }

        public Level Load()
        {
            foreach (Entity currentEnt in LevelEntites)
            {
                if (currentEnt.GetType() == typeof(Entities.Ball))
                {
                    ((Entities.Ball)currentEnt).SetDirection(0, 1);
                    ((Entities.Ball)currentEnt).ToggleMovment();
                }
            }

            return this;
        }

        private void CheckCollsions()
        {
            foreach (Entity currentEnt in LevelEntites)
            {
                foreach (Entity compareEnt in LevelEntites)
                {
                    if (currentEnt.ReturnBoundingBox().Intersects(compareEnt.ReturnBoundingBox()) == true)
                    {
                        currentEnt.OnCollide(compareEnt);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (BallAmount < 1)
            {
                Game1.PreviousScore = Score;
                Game1.CurrentState = GameStates.DeathMenu;
                return;
            }

            bool foundBlock = false;
            foreach (Entity CurEnt in LevelEntites)
            {
                if (CurEnt.GetType() == typeof(Entities.Block))
                {
                    foundBlock = true;
                }
            }

            if (foundBlock == false)
            {
                Game1.CurrentState = GameStates.WinMenu;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game1.CurrentState = GameStates.PauseMenu;

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                List<Entity> TempEnt = new List<Entity>();

                foreach (Entity CurrentEnt in LevelEntites)
                {
                    if (CurrentEnt.GetType() == typeof(Entities.Block))
                    {
                        continue;
                    }

                    TempEnt.Add(CurrentEnt);
                }

                LevelEntites = TempEnt;
            }

            #region Ent Handle
            foreach (Entity currentEnt in LevelEntites)
            {
                if (currentEnt.GetType() == typeof(Entities.Ball))
                {
                    if (((Entities.Ball)currentEnt).GetScoreBuffer() == -1)
                    {
                        BallAmount = BallAmount - 1;
                        ((Entities.Ball)currentEnt).ClearScoreBuffer();
                        ((Entities.Ball)currentEnt).RestPOS();
                        ResetPOS = true;

                    }

                    if (((Entities.Ball)currentEnt).GetScoreBuffer() > 0)
                    {
                        Score = Score + ((Entities.Ball)currentEnt).GetScoreBuffer();
                        ((Entities.Ball)currentEnt).ClearScoreBuffer();
                    }
                }

                if (currentEnt.GetType() == typeof(Entities.Paddle))
                {
                    if (ResetPOS == true)
                    {
                        currentEnt.RestPOS();
                        ResetPOS = false;
                    }
                }

                currentEnt.Update(gameTime, PlaySurface);
            }

            CheckCollsions();

            #endregion
        }

        public void Draw(GameTime gameTime)
        {
            if (Background != null)
            {
                Game1.spriteBatch.Draw(Background, PlaySurface, Color.White);
            }

            if (Game1.Debug == true)
            {
                Texture2D BoundingDraw = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                BoundingDraw.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(BoundingDraw, this.PlaySurface , Color.GreenYellow);
            }

            foreach (Entity currentEnt in LevelEntites)
            {
                currentEnt.Draw(gameTime);
            }

            if (UIFont != null && DrawUI == true)
            {
                Game1.spriteBatch.DrawString(UIFont, "Score " + Score, new Vector2(680f, 2f), Color.White);

                if (string.IsNullOrEmpty(LevelName) == false && UIFont != null)
                {
                    Game1.spriteBatch.DrawString(UIFont, LevelName, new Vector2(24f, 2f), Color.White);
                }

                if (string.IsNullOrEmpty(TagLine) == false && UISmallFont != null)
                {
                    Game1.spriteBatch.DrawString(UISmallFont, TagLine, new Vector2(28f, 458f), Color.White);
                }

                if (string.IsNullOrEmpty(LevelName) == false && UIFont != null)
                {
                    Game1.spriteBatch.DrawString(UIFont, "Balls " + BallAmount, new Vector2(700f, 450f), Color.White);
                }
            }
        }
    }
}
