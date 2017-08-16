using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class DebugView : WorldView
    {

        #region Public Properties

        public DebugWorld ThisWorld
        {
            get
            {
                return (DebugWorld)m_World;
            }
        }

        #endregion


        #region Constructors

        public DebugView(World world, int width, int height) : base(world, width, height, new Color(new Vector4(0,0,0,1))) { }

        #endregion


        public override void DrawObjects(GameTime gametime)
        {

            // Begin the sprite batch

            SpriteBatch batch = new SpriteBatch(GameManager.Graphics.GraphicsDevice);

            batch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            SamplerState sampler = GameManager.Graphics.GraphicsDevice.SamplerStates[0];
            sampler.MagFilter = TextureFilter.Point;
            sampler.MinFilter = TextureFilter.Point;
            sampler.MipFilter = TextureFilter.None;


            // Draw the objects
          
            DrawStarsAndPlanet(batch, gametime);
            
            ThisWorld.BackParticles.DrawInView(this, batch, gametime);
            
            DrawShips(batch, gametime); 
            
            ThisWorld.FrontParticles.DrawInView(this, batch, gametime);

            // End the sprite batch       
            
            batch.End(); 

        }


        protected void DrawStarsAndPlanet(SpriteBatch batch, GameTime gametime)
        {
                      
            // Draw the stars

            foreach (Star star in ThisWorld.Stars)
            {
                star.DrawInView(this, batch, gametime);
            }

            
            // Draw the planet

            ThisWorld.Planet.DrawInView(this, batch, gametime);

        }


        protected void DrawShips(SpriteBatch batch, GameTime gametime)
        {
 
            // Draw the ships

            foreach (Ship ship in ThisWorld.Ships)
            {
                ship.DrawInView(this, batch, gametime);
            }

        }
    }
}
