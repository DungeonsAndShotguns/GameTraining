using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace F1tZyWorm
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GUI GUIToDisplay = new GUI();
        Worm WormInPaly = new Worm();
        World GameWorld = new World();

        public Game1()
        {
            Renderers.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            States.Debug = true;

            if (States.FullScreen == true && States.Debug == false)
            {
                Renderers.graphics.ToggleFullScreen();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Renderers.spriteBatch = new SpriteBatch(GraphicsDevice);

            // init the gui
            GUIToDisplay = new GUI(this.Content.Load<SpriteFont>("GUI"));

            // instaiate our hero
            WormInPaly = new Worm(States.WormStartPos, this.Content.Load<Texture2D>("Worm\\Worm"));

            // Load up the graphics for quick reuse
            States.WormDefaultImage = this.Content.Load<Texture2D>("Worm\\Worm");
            States.FoodDefaultImage = this.Content.Load<Texture2D>("Food\\Food");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            GameWorld.Update(gameTime);
            WormInPaly.Update(gameTime);

            GameWorld.CollsionDetection(WormInPaly);

            GUIToDisplay.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Renderers.spriteBatch.Begin();

            GUIToDisplay.Darw(gameTime);
            GameWorld.Draw(gameTime);
            WormInPaly.Draw(gameTime);

            base.Draw(gameTime);

            Renderers.spriteBatch.End();
        }
    }
}
