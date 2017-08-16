/*using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;
using XNAGameLib2D.Utilities;


namespace SpaceGame
{
    public class BattleView : LayeredWorldView<BattleWorld>
    {
        private float minCameraZoom;
        private float maxCameraZoom;
        private float halfScreenHyp;
        private float halfWorldHyp;


        #region Properties

        public float CameraViewWidth
        {
            get { return this.ScreenSize.X / this.Camera.Zoom; }
        }


        public float CameraViewHeight
        {
            get { return this.ScreenSize.Y / this.Camera.Zoom; }
        }

        #endregion


        #region Constructors

        public BattleView(Vector2 screenPos, Vector2 screenSize, BattleWorld world) : base(screenPos, screenSize, world, 1) {}

        #endregion


        public override void Initialize()
        {
 	        base.Initialize();

            halfScreenHyp   = TrigHelper.Pythagorean(this.ScreenSize.X, this.ScreenSize.Y) / 2;
            halfWorldHyp    = TrigHelper.Pythagorean(this.World.Width, this.World.Height) / 2;

            minCameraZoom = halfScreenHyp / halfWorldHyp;
            maxCameraZoom = 1;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            // Get the lowest/greatest X / Y ship positions

            Vector3 lowPos  = this.World.Ships[0].WorldPos;
            Vector3 highPos = this.World.Ships[0].WorldPos;

            for (int i = 1; i < this.World.Ships.Count; i++)
            {
                lowPos.X = Math.Min(lowPos.X, this.World.Ships[i].WorldPos.X);
                lowPos.Y = Math.Min(lowPos.Y, this.World.Ships[i].WorldPos.Y);

                highPos.X = Math.Max(highPos.X, this.World.Ships[i].WorldPos.X);
                highPos.Y = Math.Max(highPos.Y, this.World.Ships[i].WorldPos.Y);
            }


            // Center the camera between the ships

            this.Camera.WorldPos.X = (lowPos.X + highPos.X) / 2;
            this.Camera.WorldPos.Y = (lowPos.Y + highPos.Y) / 2;


            
            // Set the camera zoom

            float dist = TrigHelper.Pythagorean(highPos.X - lowPos.X, highPos.Y - lowPos.Y);

            dist = Math.Max(dist, 1);

            this.Camera.Zoom = halfScreenHyp / dist;
            
            this.Camera.Zoom = Math.Max(this.Camera.Zoom, minCameraZoom);
            this.Camera.Zoom = Math.Min(this.Camera.Zoom, maxCameraZoom);



            // Make sure the camera stays within limits

            Vector2 cameraLowBound  = new Vector2();
            Vector2 cameraHighBound = new Vector2();

            cameraLowBound      = new Vector2(this.CameraViewWidth / 2, this.CameraViewHeight / 2);
            cameraHighBound     = new Vector2(this.World.Width - cameraLowBound.X, this.World.Height - cameraLowBound.Y);

            this.Camera.WorldPos.X = Math.Max(this.Camera.WorldPos.X, cameraLowBound.X);
            this.Camera.WorldPos.X = Math.Min(this.Camera.WorldPos.X, cameraHighBound.X);

            this.Camera.WorldPos.Y = Math.Max(this.Camera.WorldPos.Y, cameraLowBound.Y);
            this.Camera.WorldPos.Y = Math.Min(this.Camera.WorldPos.Y, cameraHighBound.Y);
        }


        public override void DrawContent(GraphicsDevice graphics, GameTime gameTime)
        {
 	        base.DrawContent(graphics, gameTime);

            
            // Clear the background

            graphics.Clear(Color.Black);


            // Begin the sprite batch

            SpriteBatch batch = new SpriteBatch(graphics);

            batch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            //SamplerState sampler = graphics.SamplerStates[0];
            //sampler.MagFilter = TextureFilter.Point;
            //sampler.MinFilter = TextureFilter.Point;
            //sampler.MipFilter = TextureFilter.None;


            // Draw the objects
          
            DrawStarsAndPlanet(batch, gameTime);
            DrawShips(batch, gameTime);


            // End the sprite batch       
            
            batch.End();


        }


        protected void DrawShips(SpriteBatch spriteBatch, GameTime gameTime)
        {
                        
            for (int i = 0; i < 2; i++)
            {
                this.World.Ships[i].ScreenPos     = WorldToScreen(this.World.Ships[i].WorldPos);
                this.World.Ships[i].Sprite.Scale  = this.Camera.Zoom; 
                this.World.Ships[i].Draw(spriteBatch, gameTime);
            }
        }


        protected void DrawStarsAndPlanet(SpriteBatch spriteBatch, GameTime gameTime)
        {
                      
            // Draw the stars

            for (int l = 1; l >= 0; l--)
            {
                for (int i = 0; i < BattleWorld.MAX_STARS; i++)
                {
                    this.World.Stars[l,i].ScreenPos     = WorldToScreen(this.World.Stars[l,i].WorldPos);
                    
                    this.World.Stars[l,i].Draw(spriteBatch, gameTime);
                }
            }
            

            // Draw the planet

            this.World.Planet.ScreenPos     = WorldToScreen(this.World.Planet.WorldPos);
            this.World.Planet.Sprite.Scale  = this.Camera.Zoom; 
            this.World.Planet.Draw(spriteBatch, gameTime);

        }
    }
}*/
