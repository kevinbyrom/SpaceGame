using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class DebugWorld : World
    {
        private List<Star>  stars;
        private DebugPlanet planet;
        private List<Ship>  ships;
        //protected ObjectManager<WorldEntity> m_FrontParticles;
        //protected ObjectManager<WorldEntity> m_BackParticles;


        #region Public Properties

        public List<Star> Stars
        {
            get
            {
                return m_Stars;
            }
        }

        public DebugPlanet Planet
        {
            get
            {
                return m_Planet;
            }
        }

        public List<Ship> Ships
        {
            get
            {
                return m_Ships;
            }
        }

        /*public ObjectManager<WorldEntity> FrontParticles
        {
            get
            {
                return m_FrontParticles;
            }
        }

        public ObjectManager<WorldEntity> BackParticles
        {
            get
            {
                return m_BackParticles;
            }
        }*/

        #endregion


        public DebugWorld(float width, float height) : base(new Vector2(1, 1), Vector2.Zero, width, height)
        {
            stars             = new List<Star>();
            planet            = new DebugPlanet(this, 20, 450);
            ships             = new List<Ship>();
            //FrontParticles    = new ObjectManager<WorldEntity>(1000, true);
            //m_BackParticles     = new ObjectManager<WorldEntity>(1000, true);
        }
    }
}
