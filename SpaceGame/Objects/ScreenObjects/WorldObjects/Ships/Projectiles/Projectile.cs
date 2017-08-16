using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
   /* public class Projectile : WorldEntity
    {
        private WorldEntity parentEntity;
        private StreamEmitter<WorldEntity> thrustEmitter;
        

        public Projectile(World world, WorldEntity parentEntity, ObjectManager<WorldObject> particlemanager) : base(world)
        {
            
            // Load the graphics

            Load("projectile.xml");


            // Set the owner

            m_Owner     = owner;
            m_IsAlive   = true;


            // Set the initial values

            m_WorldParams.Normal    = m_Owner.WorldParams.Normal;
            m_WorldParams.MaxSpeed  = new GameAttribute(2000, 2000, 2000);
            m_WorldParams.Accel     = new GameAttribute(10, 10, 10);
            m_WorldParams.Mass      = new GameAttribute(0, 0, 0);
            m_ScreenParams.SpriteAnimation.SetCurrFrameReel("primaryfire");


            // Setup the trust emitter

            m_ThrustEmitter                 = new StreamEmitter<WorldObject>(world, 20, 0, 0);  
            m_ThrustEmitter.ObjectManager   = particlemanager;

        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Update the thrust emitter

            m_ThrustEmitter.WorldParams.Normal.X = -this.m_WorldParams.Normal.X;
            m_ThrustEmitter.WorldParams.Normal.Y = -this.m_WorldParams.Normal.Y;
            m_ThrustEmitter.WorldParams.Position = this.m_WorldParams.Position;
                
            m_ThrustEmitter.Emit();


            // If the projectile passes the world bounds, kill it

            if (m_WorldParams.Position.X < 0 || m_WorldParams.Position.X > m_World.Width ||
                m_WorldParams.Position.Y < 0 || m_WorldParams.Position.Y > m_World.Height)
                m_IsAlive = false;
        }
    }*/
}
