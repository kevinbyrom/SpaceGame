using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics; 


namespace WindowsGame1
{
    public class WorldObject : ScreenObject
    {
        protected World m_World;
        protected WorldObjParams m_WorldParams;


        #region Public Properties

        public WorldObjParams WorldParams
        {
            get
            {
                return m_WorldParams;
            }
        }

        #endregion


        public WorldObject(World world)
        {
            m_World         = world;
            m_WorldParams   = new WorldObjParams();
        }


        #region Initialize(graphics)

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_WorldParams.Position.X = 100;
            m_WorldParams.Position.Y = 100;
        }

        #endregion


        #region Update(gametime)

        public override void Update(GameTime gametime)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);

            
            base.Update(gametime);


            // Calculate the normal

            m_WorldParams.Normal.X = (float)Math.Cos(m_ScreenParams.Rotation);
            m_WorldParams.Normal.Y = (float)Math.Sin(m_ScreenParams.Rotation);


            // Change the velocity based on the thrust

            if (m_WorldParams.Accel.Val > 0f)
            {

                // Calculate the target velocity

                Vector2 target;

                target.X = m_WorldParams.Normal.X * m_WorldParams.MaxSpeed.Val;
                target.Y = m_WorldParams.Normal.Y * m_WorldParams.MaxSpeed.Val;

                float highx = Math.Max(Math.Abs(target.X), Math.Abs(m_WorldParams.Velocity.X));
                float highy = Math.Max(Math.Abs(target.Y), Math.Abs(m_WorldParams.Velocity.Y));

                m_WorldParams.Velocity.X = MathHelper.Clamp(m_WorldParams.Velocity.X + (target.X * m_WorldParams.Accel.Val * elapsed), -highx, highx);
                m_WorldParams.Velocity.Y = MathHelper.Clamp(m_WorldParams.Velocity.Y + (target.Y * m_WorldParams.Accel.Val * elapsed), -highy, highy);
            }


            // Add some friction

            m_WorldParams.Velocity.X = m_WorldParams.Velocity.X * (1f - m_WorldParams.Friction.Val);
            m_WorldParams.Velocity.Y = m_WorldParams.Velocity.Y * (1f - m_WorldParams.Friction.Val);


            // Adjust the position, scale and rotation

            m_WorldParams.Position.X += elapsed * m_WorldParams.Velocity.X;
            m_WorldParams.Position.Y += elapsed * m_WorldParams.Velocity.Y;     

        }

        #endregion


        #region Draw(spritebatch)

        public override void Draw(SpriteBatch spritebatch)
        {
            ScreenObjParams screenparams = m_World.Camera.ConvertScreenParams(this);
            base.Draw(spritebatch, screenparams);
        }

        #endregion

    }
}
