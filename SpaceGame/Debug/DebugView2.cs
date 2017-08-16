using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D.Core;


namespace WindowsGame1
{
    public class DebugView2 : WorldView
    {

        #region Public Properties

        public DebugWorld2 ThisWorld
        {
            get
            {
                return (DebugWorld2)m_World;
            }
        }

        #endregion


        #region Constructors

        public DebugView2(World world, int width, int height) : base(world, width, height, new Color(new Vector4(0,0,0,1))) { }

        #endregion


        public override void DrawObjects(GameTime gametime)
        {
            this.BackColor = new Color(new Vector3(0,0,0));


            // Begin the sprite batch

            SpriteBatch batch = new SpriteBatch(GameEngine.Graphics.GraphicsDevice);
            
            batch.Begin(SpriteBlendMode.AlphaBlend , SpriteSortMode.Immediate, SaveStateMode.None);
                         
            SamplerState sampler = GameEngine.Graphics.GraphicsDevice.SamplerStates[0];
            sampler.MagFilter = TextureFilter.Point;
            sampler.MinFilter = TextureFilter.Point;
            sampler.MipFilter = TextureFilter.None;

            // Draw the objects
          
            ThisWorld.Particles.DrawInView(this, batch, gametime);
            

            // End the sprite batch       
            
            batch.End(); 

        }
    }
}
