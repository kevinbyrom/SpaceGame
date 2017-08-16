using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNAGameLib2D;


namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SpaceGame : Microsoft.Xna.Framework.Game
    {   
        public SpaceGame()
        {

            // Prepare the game manager
            
            GameEngine2D.AssetsPath  = @"c:\Development\Game Source\SpaceGame\SpaceGame\Assets";
            GameEngine2D.Graphics    = new GraphicsDeviceManager(this);
            GameEngine2D.Content     = new ContentManager(Services);
            
            GameEngine2D.Stages.Push(new BattleStage());

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
            
            this.IsFixedTimeStep = false;
            

            // Initialize the graphics
           
            GameEngine2D.SetScreenSize(1440, 900, true);


            // Initialize the current stage

            GameEngine2D.Stages.Peek().Initialize();

            
        }


        /// <summary>
        /// Load your graphics content.  If loadAllContent is true, you should
        /// load content from both ResourceManagementMode pools.  Otherwise, just
        /// load ResourceManagementMode.Manual content.
        /// </summary>
        /// <param name="loadAllContent">Which type of content to load.</param>
        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                //GameManager.DebugFont = GameManager.Content.Load<SpriteFont>("SpriteFont1");
                //m_Batch = new SpriteBatch(m_Graphics.GraphicsDevice);
            }

            // TODO: Load any ResourceManagementMode.Manual content
   
        }


        /// <summary>
        /// Unload your graphics content.  If unloadAllContent is true, you should
        /// unload content from both ResourceManagementMode pools.  Otherwise, just
        /// unload ResourceManagementMode.Manual content.  Manual content will get
        /// Disposed by the GraphicsDevice during a Reset.
        /// </summary>
        /// <param name="unloadAllContent">Which type of content to unload.</param>
        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent == true)
            {
                GameEngine2D.Content.Unload();
            }
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gametime)
        {
            
            // Allows the default game to exit on Xbox 360 and Windows
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            
         
            // Update the current stage

            GameEngine2D.Stages.Peek().Update(gametime);
                          
           
            base.Update(gametime);

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            // Call the base draw method

            base.Draw(gameTime);


            // Draw the current stage

            GameEngine2D.Stages.Peek().Draw(GameEngine2D.Graphics.GraphicsDevice, gameTime);
           
        }
    }
}