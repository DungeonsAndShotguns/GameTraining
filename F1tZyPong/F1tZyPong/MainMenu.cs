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

        SpriteBatch SpriteBatch;
        SpriteFont SpriteFont;

        Vector2 Position;
        float Width = 0f;
        float Height = 0f;

       

        public MainMenu(Game game, SpriteBatch spritebatch, SpriteFont spriteFont)
            : base(game)
        {
            this.SpriteBatch = spritebatch;
            this.SpriteFont = spriteFont;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();

            if (CurrentState.IsKeyDown(Keys.Down) == true)
            {
                SelectedIndex++;
                if (SelectedIndex == MenuText.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if (CurrentState.IsKeyDown(Keys.Up) == true)
            {
                SelectedIndex--;
                if (SelectedIndex < 0)
                {
                    SelectedIndex = MenuText.Length - 1;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
