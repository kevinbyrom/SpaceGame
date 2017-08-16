using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class Star : WorldObject
    {

        #region Constructors

        public Star(World world) : base(world) { }

        #endregion


        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_ScreenParams.Texture      = TextureManager.LoadTexture(graphics, "Star", Path.Combine(Game1.AssetsPath, "Star_1.png"));
            m_ScreenParams.SpriteRect   = new Rectangle(0, 0, 20, 20);
            m_ScreenParams.Origin.X     = 10;
            m_ScreenParams.Origin.Y     = 10;
            m_ScreenParams.IsVisible    = true;
            m_WorldParams.MaxSpeed      = new WOAttribute(0, 100);
            m_WorldParams.Accel.Val     = 100;
            m_WorldParams.Friction.Val  = 0;
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Make sure the object is within bounds

            int halfwidth = (int)(m_ScreenParams.SpriteRect.Width * m_ScreenParams.Scale) / 2;
            int halfheight = (int)(m_ScreenParams.SpriteRect.Height * m_ScreenParams.Scale) / 2;

            if (m_WorldParams.Position.X >= m_World.Bounds.Width + halfwidth)   m_WorldParams.Position.X = -halfwidth;
            if (m_WorldParams.Position.X < -halfwidth)                          m_WorldParams.Position.X = m_World.Bounds.Width + halfwidth;
            if (m_WorldParams.Position.Y >= m_World.Bounds.Height + halfheight) m_WorldParams.Position.Y = -halfheight;
            if (m_WorldParams.Position.Y < -halfheight)                         m_WorldParams.Position.Y = m_World.Bounds.Height + halfheight;
        }
    }
}