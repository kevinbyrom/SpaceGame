using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class WorldCamera : WorldObject
    {
        protected int m_ScreenWidth;
        protected int m_ScreenHeight;
        protected int m_HalfScreenWidth;
        protected int m_HalfScreenHeight;
        protected List<WorldObject> m_Targets;

        public List<WorldObject> Targets
        {
            get
            {
                return m_Targets;
            }
        }

        public WorldCamera(World world) : base(world) 
        {
            m_Targets = new List<WorldObject>();
        }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_ScreenWidth       = graphics.PreferredBackBufferWidth;
            m_ScreenHeight      = graphics.PreferredBackBufferHeight;
            m_HalfScreenWidth   = m_ScreenWidth / 2;
            m_HalfScreenHeight  = m_ScreenHeight / 2;

            m_Params.Position.X = m_World.Bounds.Width / 2;
            m_Params.Position.Y = m_World.Bounds.Height / 2;
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Follow the tracking objects

            if (m_Targets.Count > 0)
            {
                float x = 0, y = 0;

                foreach (WorldObject obj in m_Targets)
                {
                    x += obj.WOParams.Position.X;
                    y += obj.WOParams.Position.Y;
                }

                m_Params.Position.X = x / m_Targets.Count;
                m_Params.Position.Y = y / m_Targets.Count;
            }


            // Make sure we do not exceed bounds

            m_Params.Position.X = MathHelper.Clamp(m_Params.Position.X, m_HalfScreenWidth / m_Params.Scale, m_World.Bounds.Width - (m_HalfScreenWidth / m_Params.Scale));
            m_Params.Position.Y = MathHelper.Clamp(m_Params.Position.Y, m_HalfScreenHeight / m_Params.Scale, m_World.Bounds.Height - (m_HalfScreenHeight / m_Params.Scale));
        }


        public Vector2 GetScreenPosition(Vector2 world)
        {
            return new Vector2(((world.X - m_Params.Position.X) * m_Params.Scale) + m_HalfScreenWidth, ((world.Y - m_Params.Position.Y) * m_Params.Scale) + m_HalfScreenHeight);
        }

        public float GetScreenScale(float world)
        {
            return world * m_Params.Scale;
        }
    }
}
