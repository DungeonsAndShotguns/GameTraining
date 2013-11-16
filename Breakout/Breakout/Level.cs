using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Level
    {
        List<Entity> LevelEntites = new List<Entity>();

        Texture2D Background = null;
        SpriteFont UIFont = null;
        Rectangle PlaySurface = new Rectangle();
        int Score = 0;

        public Level() { }

        public Level(Texture2D backgroundImage, SpriteFont uiFont, Rectangle playSurface)
        {
            Background = backgroundImage;
            UIFont = uiFont;
            PlaySurface = playSurface;
        }

        public void AddEntity(Entity entToAdd)
        {
            LevelEntites.Add(entToAdd);
        }

        public void Load()
        {
            foreach (Entity currentEnt in LevelEntites)
            {
                if (currentEnt.GetType() == typeof(Entities.Ball))
                {
                    ((Entities.Ball)currentEnt).SetDirection(0, 1);
                    ((Entities.Ball)currentEnt).ToggleMovment();
                }
            }
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
            foreach (Entity currentEnt in LevelEntites)
            {
                //if (currentEnt.GetType() == typeof(Entities.Ball))
                //{
                //    ((Entities.Ball)currentEnt).Update(gameTime, PlaySurface);
                //}

                //if (currentEnt.GetType() == typeof(Entities.Paddle))
                //{
                    //((Entities.Paddle)currentEnt).Update(gameTime, PlaySurface);
                //}

                currentEnt.Update(gameTime, PlaySurface);
            }

            CheckCollsions();
        }

        public void Draw(GameTime gameTime)
        {
            if (Game1.Debug == true)
            {
                Texture2D BoundingDraw = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
                BoundingDraw.SetData(new Color[] { Color.White });
                Game1.spriteBatch.Draw(BoundingDraw, this.PlaySurface , Color.GreenYellow);
            }

            foreach (Entity currentEnt in LevelEntites)
            {
                //if (currentEnt.GetType() == typeof(Entities.Ball))
                //{
                //    ((Entities.Ball)currentEnt).Draw(gameTime);
                //}

                //if (currentEnt.GetType() == typeof(Entities.Paddle))
                //{
                //    ((Entities.Paddle)currentEnt).Draw(gameTime);
                //}

                currentEnt.Draw(gameTime);
            }
        }
    }
}
