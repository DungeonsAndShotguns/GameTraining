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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        // States
        public static bool Debug = false;

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
            // TODO: Add your initialization logic here

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

            // Load up the paddle
            Paddle = new Entities.Paddle(new Vector2(spriteBatch.GraphicsDevice.Viewport.Width / 2, spriteBatch.GraphicsDevice.Viewport.Height - 50), 
                new Rectangle(100, 400, 52, 12));
            Paddle.LoadImage(Content.Load<Texture2D>("Images\\paddleRed"));
            Paddle.ResizeBoundingBox(Paddle.ReturnImage());

            Ball = new Entities.Ball(new Vector2(spriteBatch.GraphicsDevice.Viewport.Width / 2, spriteBatch.GraphicsDevice.Viewport.Height / 2),
                new Rectangle(), 2, Content.Load<Texture2D>("Images\\ballGrey"));
            Ball.ResizeBoundingBox(Ball.ReturnImage());

            Level1 = new Level(null, null, new Rectangle(25, 25, 750, 425));

            Level1.AddEntity(Paddle);
            Level1.AddEntity(Ball);
            Level1.Load();
            
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (Debug == true)
            {
                spriteBatch.Draw(DebugBug, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - 40, 10),
                    Color.White);
            }

            //Paddle.Draw(gameTime);
            //Ball.Draw(gameTime);

            Level1.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
