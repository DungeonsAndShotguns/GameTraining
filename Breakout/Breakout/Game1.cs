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

namespace Breakout
{
    public enum GameStates
	{
        InGame, MainMenu, SiteIntro, PersonalIntro, DeathMenu   
	}

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager Load;
        public static GameStates CurrentState;

        public static int PreviousScore;

        // States
        public static bool Debug = true;
        Breakout.F1tZLogo LogoMe = null;

        // interface stuffs
        KeyboardState LastState = Keyboard.GetState();

        public Entities.Paddle Paddle = null;
        public Entities.Ball Ball = null;
        public Level Level1 = new Level();

        public Texture2D DebugBug = null;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Load = Content;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            DebugBug = Content.Load<Texture2D>("Images\\Bug");

            LogoMe = new F1tZLogo(Content);

            Level1 = new Breakout.Levels.Classic();

            Level1.Load();

            if (Debug == false)
            {
                CurrentState = GameStates.PersonalIntro;
            }
            else
            {
                CurrentState = GameStates.InGame;
                Debug = false;
            }
            
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

            if (CurrentState == GameStates.PersonalIntro)
            {
                LogoMe.Update(gameTime);
            }

            if (CurrentState == GameStates.InGame)
            {
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    this.Exit();
                if (Keyboard.GetState().IsKeyDown(Keys.D) && LastState.IsKeyUp(Keys.D))
                {
                    if (Debug == true)
                    {
                        Debug = false;
                    }
                    else
                    {
                        Debug = true;
                    }
                }

                //Paddle.Update(gameTime);
                //Ball.Update(gameTime);
                Level1.Update(gameTime);

                base.Update(gameTime);

                LastState = Keyboard.GetState();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (CurrentState == GameStates.PersonalIntro)
            {
                LogoMe.Draw(gameTime);
            }

            if (CurrentState == GameStates.InGame)
            {
                if (Debug == true)
                {
                    spriteBatch.Draw(DebugBug, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - 40, 10),
                        Color.White);
                }

                Level1.Draw(gameTime);
            }

            if (CurrentState == GameStates.DeathMenu)
            {
                Level1.Draw(gameTime);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
