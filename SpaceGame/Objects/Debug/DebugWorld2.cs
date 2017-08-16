using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D.Core;


namespace WindowsGame1
{
    public class DebugWorld2 : World
    {
        protected StreamEmitter<WorldEntity> m_Emitter;
        protected ObjectManager<WorldEntity> m_Particles;
        

        #region Public Properties

        public StreamEmitter<WorldEntity> Emitter
        {
            get
            {
                return m_Emitter;
            }
        }

        public ObjectManager<WorldEntity> Particles
        {
            get
            {
                return m_Particles;
            }
        }

        #endregion


        public DebugWorld2(float width, float height) : base(new Vector2(1,1), Vector2.Zero, width, height)
        {
            //m_Emitter               = new StreamEmitter<SmokeParticle>(this, 10, 0, 0);
            //m_Particles             = new ObjectManager<SmokeParticle>(10000, true);
           /// m_Emitter.ObjectManager = m_Particles;

            //m_Emitter.WorldParams.Position.X = width / 2;
            //m_Emitter.WorldParams.Position.Y = height / 2;
            //m_Emitter.EmitRect = new Rectangle(-10, 0, 20, 1);
        }
    }
}
