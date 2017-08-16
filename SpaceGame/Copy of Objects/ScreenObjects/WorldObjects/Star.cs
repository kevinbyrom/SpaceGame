using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class Star : MassObject
    {

        #region Constructors

        public Star(World world) : base(world) { }

        #endregion


        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_Params.Texture    = TextureManager.LoadTexture(graphics, "Star", Path.Combine(Game1.AssetsPath, "Star_1.png"));
            m_Params.SpriteRect = new Rectangle(0, 0, 20, 20);
            m_Params.Origin.X   = 10;
            m_Params.Origin.Y   = 10;
            m_Params.IsVisible  = true;
            m_Speed_Units_Sec   = new WOAttribute(0, 100);
            m_Accel.Val         = 100;
            m_Friction.Val      = 0;
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Make sure the object is within bounds

            int halfwidth = (int)(m_Params.SpriteRect.Width * m_Params.Scale) / 2;
            int halfheight = (int)(m_Params.SpriteRect.Height * m_Params.Scale) / 2;

            if (m_Params.Position.X >= m_World.Bounds.Width + halfwidth) m_Params.Position.X = -halfwidth;
            if (m_Params.Position.X < -halfwidth) m_Params.Position.X = m_World.Bounds.Width + halfwidth;
            if (m_Params.Position.Y >= m_World.Bounds.Height + halfheight) m_Params.Position.Y = -halfheight;
            if (m_Params.Position.Y < -halfheight) m_Params.Position.Y = m_World.Bounds.Height + halfheight;
        }
    }
}