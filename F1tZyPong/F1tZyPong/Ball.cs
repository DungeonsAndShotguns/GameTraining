using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace F1tZyPong
{
    public class Ball : Entity
    {
        SoundEffect Score;

        public Ball() { }

        public void LoadAudio(SoundEffect Score)
        {
            this.Score = Score;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Graphics.Texture2D TextureToAssign)
        {
            this.Image = TextureToAssign;

            Scale = new Vector2(.5f);
            Posistion = new Vector2(GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2, GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2);

            Volcity = new Vector2(3, 0);

            BoundindBox = new Rectangle((int)(Posistion.X), (int)(Posistion.Y), (int)(Image.Width * Scale.X), (int)(Image.Height * Scale.Y));
        }

        public override void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this.Posistion += Volcity;
            this.BoundindBox.X = (int)Posistion.X;
            this.BoundindBox.Y = (int)Posistion.Y;

            float MaxX = GameState.spriteBatch.GraphicsDevice.Viewport.Width - Image.Width;
            float MaxY = GameState.spriteBatch.GraphicsDevice.Viewport.Height - Image.Height;

            if (Posistion.X > MaxX || Posistion.X < 0) 
            {
                if (Posistion.X > MaxX)
                {
                    GameState.LeftScore += 1;
                }
                else
                {
                    GameState.RightScore += 1;
                }

                if (GameState.LeftScore == 5 || GameState.RightScore == 5)
                {
                    if (GameState.LeftScore == 5)
                    {
                        this.Posistion.X = GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2;
                        this.Posistion.Y = GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2;
                        this.Volcity.X = -3f;
                        this.Volcity.Y = 0f;
                        GameState.LeftWin += 1;
                        GameState.LeftScore = 0;
                        GameState.RightScore = 0;
                    }
                    else
                    {
                        this.Posistion.X = GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2;
                        this.Posistion.Y = GameState.spriteBatch.GraphicsDevice.Viewport.Height / 2;
                        this.Volcity.X = 3f;
                        this.Volcity.Y = 0f;
                        GameState.Rightwin += 1;
                        GameState.LeftScore = 0;
                        GameState.RightScore = 0;
                    }
                }

                Volcity.X *= -1;

                Score.Play();
            }

            if (Posistion.Y > MaxY || Posistion.Y < 0) 
            { Volcity.Y *= -1; }
                
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 1);

            if (GameState.Debug == true)
            {
                GameState.spriteBatch.DrawString(GameState.GUIFont, "Ball Volicity: " + this.Volcity.X, new Vector2((GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2) - 100, GameState.spriteBatch.GraphicsDevice.Viewport.Height - 20), Color.White);
                GameState.spriteBatch.DrawString(GameState.GUIFont, "Ball Vert: " + this.Volcity.Y, new Vector2((GameState.spriteBatch.GraphicsDevice.Viewport.Width / 2) - 100, GameState.spriteBatch.GraphicsDevice.Viewport.Height - 40), Color.White);

                Texture2D FillBoundingBox = new Texture2D(GameState.spriteBatch.GraphicsDevice, 1, 1);
                FillBoundingBox.SetData(new Color[] { Color.White });
                GameState.spriteBatch.Draw(FillBoundingBox, this.BoundindBox, Color.Red);                
            }
        }
    }
}
