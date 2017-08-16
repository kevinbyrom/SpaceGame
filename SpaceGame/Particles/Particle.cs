using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
    /*public class Particle : WorldObject
    {
        protected int m_MaxLifeMsecs;
        protected int m_AliveTimeMsecs;


        #region Constructors

        public Particle(IWorld world) : this(world, int.MaxValue) {}

        public Particle(IWorld world, int maxlifemsecs) : base(world)
        {
            m_MaxLifeMsecs      = maxlifemsecs;
            m_AliveTimeMsecs    = 0;
            m_IsAlive           = true;
        }

        #endregion


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            if (m_MaxLifeMsecs < int.MaxValue)
            {
                m_AliveTimeMsecs    += gametime.ElapsedGameTime.Milliseconds;
                m_IsAlive           = m_AliveTimeMsecs < m_MaxLifeMsecs;
            }
        }
    }*/
}
