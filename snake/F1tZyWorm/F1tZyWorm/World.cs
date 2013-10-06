using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F1tZyWorm
{
    /// <summary>
    /// Holds the play feild and other such stuff
    /// </summary>
    public class World
    {
    }

    /// <summary>
    /// Used to store statics and globals in the game
    /// </summary>
    public static class States
    {
        public static Vector2 WormStartPos = new Vector2(10, 10);
        public static bool FullScreen = true;
    }

    public static class Renderers
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
    }
}
