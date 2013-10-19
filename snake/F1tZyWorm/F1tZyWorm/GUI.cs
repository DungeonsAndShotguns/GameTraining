using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    /// <summary>
    /// This class is actully used to draw all GUI or none game world assets
    /// </summary>
    public class GUI
    {
        SpriteFont DebugFont;

        public GUI() { }

        public GUI(SpriteFont debugFont)
        {
            DebugFont = debugFont;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Darw(GameTime gameTime)
        {
            if (States.CurrentState == GameStates.Ingame && States.Debug == true)
            {
                Renderers.spriteBatch.DrawString(DebugFont, "Food Bits " + States.FoodBitsCollected, new Vector2(Renderers.spriteBatch.GraphicsDevice.Viewport.Width - 150,
                    Renderers.spriteBatch.GraphicsDevice.Viewport.Height - 50), Color.Purple);
            }
        }
    }
}
