using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Breakout
{
    public enum GameStates
	{
        InGame, MainMenu, SiteIntro, PersonalIntro, DeathMenu, Exit, LevelSelect, PauseMenu, WinMenu
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
        public static bool Debug = false;
        public static bool Mute = false;

        // interface stuffs
        KeyboardState LastState = Keyboard.GetState();
        public static TimeSpan LastIneractTime = new TimeSpan();

        Breakout.F1tZLogo LogoMe = null;
        public static Level Level1 = new Level();
        public Menus.DeathMenu Dmenu = null;
        public Menus.MainMenu MMenu = null;
        public Menus.LevelSelect LMenu = null;
        public Menus.Pause PMenu = null;
        public Menus.Win WMenu = null;

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

            //Level1 = new Breakout.Levels.Classic();
            Dmenu = new Menus.DeathMenu();
            MMenu = new Menus.MainMenu();
            LMenu = new Menus.LevelSelect();
            PMenu = new Menus.Pause();
            WMenu = new Menus.Win();

            Level1.Load();

            if (Debug == false)
            {
                CurrentState = GameStates.PersonalIntro;
            }
            else
            {
                CurrentState = GameStates.MainMenu;
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

                Level1.Update(gameTime);

                LastState = Keyboard.GetState();
            }

            if (CurrentState == GameStates.DeathMenu)
            {
                Dmenu.Update(gameTime);
            }

            if (CurrentState == GameStates.MainMenu)
            {
                MMenu.Update(gameTime);
            }

            if (CurrentState == GameStates.Exit)
            {
                this.Exit();
            }

            if (CurrentState == GameStates.LevelSelect)
            {
                LMenu.Update(gameTime);
            }

            if (CurrentState == GameStates.PauseMenu)
            {
                PMenu.Update(gameTime);
            }

            if (CurrentState == GameStates.WinMenu)
            {
                WMenu.Update(gameTime);
            }

            base.Update(gameTime);
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
                Dmenu.Draw(gameTime);
            }

            if (CurrentState == GameStates.MainMenu)
            {
                MMenu.Draw(gameTime);
            }

            if (CurrentState == GameStates.LevelSelect)
            {
                LMenu.Draw(gameTime);
            }

            if (CurrentState == GameStates.PauseMenu)
            {
                Level1.Draw(gameTime);
                PMenu.Draw(gameTime);
            }

            if (CurrentState == GameStates.WinMenu)
            {
                Level1.Draw(gameTime);
                WMenu.Draw(gameTime);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
