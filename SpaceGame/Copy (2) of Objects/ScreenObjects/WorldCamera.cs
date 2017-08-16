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


        #region Public Properties
        
        public List<WorldObject> Targets
        {
            get
            {
                return m_Targets;
            }
        }

        #endregion


        #region Constructors

        public WorldCamera(World world) : base(world) 
        {
            m_Targets = new List<WorldObject>();
        }

        #endregion


        #region Initialize(graphics)

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_ScreenWidth       = graphics.PreferredBackBufferWidth;
            m_ScreenHeight      = graphics.PreferredBackBufferHeight;
            m_HalfScreenWidth   = m_ScreenWidth / 2;
            m_HalfScreenHeight  = m_ScreenHeight / 2;

            m_WorldParams.Position.X = m_World.Bounds.Width / 2;
            m_WorldParams.Position.Y = m_World.Bounds.Height / 2;
        }

        #endregion


        #region Update(gametime)

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Follow the tracking objects

            if (m_Targets.Count > 0)
            {
                float x = 0, y = 0;

                foreach (WorldObject obj in m_Targets)
                {
                    x += obj.WorldParams.Position.X;
                    y += obj.WorldParams.Position.Y;
                }

                m_WorldParams.Position.X = x / m_Targets.Count;
                m_WorldParams.Position.Y = y / m_Targets.Count;
            }


            // Make sure we do not exceed bounds

            m_WorldParams.Position.X = MathHelper.Clamp(m_WorldParams.Position.X, m_HalfScreenWidth / m_ScreenParams.Scale, m_World.Bounds.Width - (m_HalfScreenWidth / m_ScreenParams.Scale));
            m_WorldParams.Position.Y = MathHelper.Clamp(m_WorldParams.Position.Y, m_HalfScreenHeight / m_ScreenParams.Scale, m_World.Bounds.Height - (m_HalfScreenHeight / m_ScreenParams.Scale));
        }

        #endregion


        #region ConvertScreenParams(obj)

        public ScreenObjParams ConvertScreenParams(WorldObject obj)
        {
            ScreenObjParams converted = (ScreenObjParams)obj.ScreenParams.Clone();

            converted.Position.X    = ((obj.WorldParams.Position.X - m_WorldParams.Position.X) * m_ScreenParams.Scale) + m_HalfScreenWidth;
            converted.Position.Y    = ((obj.WorldParams.Position.Y - m_WorldParams.Position.Y) * m_ScreenParams.Scale) + m_HalfScreenHeight;
            converted.Scale         = converted.Scale * m_ScreenParams.Scale;
            
            return converted;
        }

        #endregion

    }
}
