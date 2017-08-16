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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using XNAGameLib2D;



namespace SpaceGame
{

    public class SpaceGame : Microsoft.Xna.Framework.Game
    {
        private ScreenManager screenManager;
        private GameStateManager gameStateManager;


        public SpaceGame()
        {
            
            // Prepare the game manager
            
            //GameEngine2D.AssetsPath  = @"C:\Development\Game Source\SpaceGame\SpaceGame\Assets";
            //GameEngine2D.Graphics    = new GraphicsDeviceManager(this);
            //GameEngine2D.Content     = new ContentManager(Services);
            //GameEngine2D.Content.RootDirectory = "Content";

            //GameEngine2D.Stages.Push(new BattleStage());

        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            base.Initialize();
            
            this.IsFixedTimeStep = false;
            

            // Prep and add the game services

            this.screenManager = new ScreenManager(this, new GraphicsDeviceManager(this));
            this.Services.AddService(typeof(IScreenManager), this.screenManager);

            this.gameStateManager = new GameStateManager(this);
            this.Services.AddService(typeof(IGameStateManager), this.gameStateManager);


            // Initialize the graphics
           
            this.screenManager.SetScreenSize(1024, 768, false);


            // Initialize the current state

            BattleState battleState = new BattleState(this);

            battleState.Initialize();

            this.gameStateManager.PushState(battleState);

        }



        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the default game to exit on Xbox 360 and Windows
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            
         
            // Update using the state manager

            this.gameStateManager.Update(gameTime);

                         
           
            base.Update(gameTime);

        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // Call the base draw method

            base.Draw(gameTime);


            // Draw using the state manager

            this.gameStateManager.Draw(gameTime);
           
        }
    }
}
