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
        Ingame, Exit
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

        /// <summary>
        /// The gloabl manager to mange the screen
        /// </summary>
        public static GraphicsDeviceManager graphics;

        /// <summary>
        /// The gloabl spritebatch used to draw all grapihcs to the screen
        /// </summary>
        public static SpriteBatch spriteBatch;
    }
}
