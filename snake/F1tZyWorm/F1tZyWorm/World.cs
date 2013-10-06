using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace F1tZyWorm
{
    /// <summary>
    /// Holds the play feild and other such stuff
    /// </summary>
    public class World
    {
        List<Food> FoodBits = new List<Food>();

        public void Update(GameTime gameTime)
        {
            if (FoodBits.Count == 0)
            {
                FoodBits.Add(new Food(new Vector2(100, 200), States.FoodDefaultImage));
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Food CurrentBit in FoodBits)
            {
                CurrentBit.Draw(gameTime);
            }
        }
    }

    /// <summary>
    /// Used to store statics and globals in the game
    /// </summary>
    public static class States
    {
        public static Vector2 WormStartPos = new Vector2(10, 10);
        public static bool FullScreen = true;
        public static KeyboardState PreviousKeyState = new KeyboardState();

        public static float WormSpeed = 1;
        public static Texture2D WormDefaultImage;

        public static Texture2D FoodDefaultImage;
    }

    /// <summary>
    /// Used to hold any sort of IO system that needs to be accessed from
    /// many classes. Screen, speakers, network, disk IO.
    /// </summary>
    public static class Renderers
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
    }
}
