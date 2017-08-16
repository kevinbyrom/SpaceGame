/*using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class DebugPlanet : Planet
    {
        protected Planet gravPlanet;


        #region Constructors

        public DebugPlanet(World world, float gravity, float gravityRange) : base(world, gravity, gravityRange) 
        {
            gravPlanet = new Planet(world, gravity, gravityRange);
        }

        #endregion


        public override void Initialize()
        {
            base.Initialize();
                        
            gravPlanet.Initialize();
            gravPlanet.ScreenParams.Tint = new Color(new Vector4(1,1,1,.2f));
        }


        #region ProcessInput(gameTime, padState)

        public override void ProcessInput(GameTime gameTime, GamePadState padState)
        {
            KeyboardState keyState = Keyboard.GetState();


            // Call the base logic

            base.ProcessInput(gameTime, padState);
            
             
            // Check for debug keys
                        
            if (keyState.IsKeyDown(Keys.D2)) gravity -= .5f;
            if (keyState.IsKeyDown(Keys.D3)) gravity += .5f;
            if (keyState.IsKeyDown(Keys.D4)) gravityRange -= 5;
            if (keyState.IsKeyDown(Keys.D5)) gravityRange += 5;

        }

        #endregion


        #region Update(gameTime)

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            gravPlanet.WorldParams.Position   = this.WorldParams.Position;
            gravPlanet.WorldParams.Scale      = ((gravityRange * 2) / gravPlanet.ScreenParams.SpriteRect.Width);
        }

        #endregion


        #region DrawInView(view, spritebatch, gametime)

        public override void DrawInView(WorldView view, SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            // Draw the grav planet
            
            gravPlanet.DrawInView(view, spriteBatch, gameTime);


            // Call the base draw

            base.DrawInView(view, spriteBatch, gameTime);
            
            
            // Draw the debug info

            DrawGravity(spriteBatch);

        }


        protected void DrawGravity(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameManager.DebugFont, String.Format("Grav (2/3) = {0:.00}, Range (4/5) = {1:.00}", this.gravity, this.gravityRange), new Vector2(this.ScreenParams.Position.X + (100 * this.ScreenParams.Scale), this.ScreenParams.Position.Y + (100 * this.ScreenParams.Scale)), Color.White);
        }

        #endregion

    }
}*/
