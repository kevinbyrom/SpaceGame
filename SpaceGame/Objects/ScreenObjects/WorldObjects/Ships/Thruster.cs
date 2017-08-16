using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using XNAGameLib2D;


namespace WindowsGame1
{
    /*public class Thruster : WorldObject
    {
        protected Vector3 m_RelativePos;
        protected Emitter<Particle> m_Emitter;


        #region Public Properties

        public Vector3 RelativePos
        {
            get
            {
                return m_RelativePos;
            }
        }

        public Emitter<Particle> Emitter
        {
            get
            {
                return m_Emitter;
            }
        }

        #endregion
        

        #region Constructors

        public Thruster(IWorld world) : base(world) { }

        #endregion


        #region Initialize()

        public override void Initialize()
        {
            base.Initialize();

            m_Emitter = new Emitter<Particle>(this.World, 10);
        }

        #endregion


        public void EmitThrust()
        {
            m_Emitter.WorldParams.Normal = this.WorldParams.Normal;
            m_Emitter.Emit();
        }
    }*/
}
