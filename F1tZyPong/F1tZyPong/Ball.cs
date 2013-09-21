using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyPong
{
    public class Ball : Entity
    {
        public Ball() { }

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

                Volcity.X *= -1;
            }
            if (Posistion.Y > MaxY || Posistion.Y < 0) 
            { Volcity.Y *= -1; }
                
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameState.spriteBatch.Draw(Image, this.Posistion, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 1);

            if (GameState.Debug == true)
            {
                Texture2D FillBoundingBox = new Texture2D(GameState.spriteBatch.GraphicsDevice, 1, 1);
                FillBoundingBox.SetData(new Color[] { Color.White });
                GameState.spriteBatch.Draw(FillBoundingBox, this.BoundindBox, Color.Red);
            }
        }
    }
}
