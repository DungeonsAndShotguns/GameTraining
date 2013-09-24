using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace F1tZyPong
{

    public enum States
    {
        Intro, F1tZIntro, Ingame, Exit
    }

    /// <summary>
    /// This class holds all global veribales and states for the game
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// The current state of the game 
        /// </summary>
        public static States CurrentState { get; set; }

        public static bool Debug = false;

        public static KeyMap KMap = new KeyMap();

        public static int LeftScore = 0;
        public static int RightScore = 0;
        public static int LeftWin = 0;
        public static int Rightwin = 0;

        public static SpriteFont GUIFont = null;

        /// <summary>
        /// The gloabl manager to mange the screen
        /// </summary>
        public static GraphicsDeviceManager graphics;

        /// <summary>
        /// The gloabl spritebatch used to draw all grapihcs to the screen
        /// </summary>
        public static SpriteBatch spriteBatch;

        public static void DrawScore(GameTime gameTime)
        {
            if (GUIFont != null)
            {
                spriteBatch.DrawString(GUIFont, "Left: " + LeftScore, new Vector2(((spriteBatch.GraphicsDevice.Viewport.Width / 2) / 2) - 10, 10), Color.White);
                spriteBatch.DrawString(GUIFont, "Right: " + RightScore, new Vector2((((spriteBatch.GraphicsDevice.Viewport.Width / 2) * 2) / 2) + 100, 10), Color.White);
            }
            else
            {
                throw new Exception("Did not load Font correctly");
            }
        }
    }
}
