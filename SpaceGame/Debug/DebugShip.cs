/*using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class DebugShip : Ship
    {
        private float highestSpeed;
        private EntityGroup<StarParticle> thrustParticles;
        private ConeEmitter<StarParticle> thrustEmitter;
        

        #region Public Properties

        public BattleWorld ThisWorld 
        {
            get
            {
                return this.World as BattleWorld;
            }
        }

        #endregion


        #region Constructors

        public DebugShip(IWorld world) : base(world) 
        {
            highestSpeed = 0f;
            
            // Prepare the emitters

            thrustEmitter = new ConeEmitter<StarParticle>(world, 50, 100, 100, MathHelper.PiOver2);    
            
            //m_PrimaryFire = new StreamEmitter<WorldObject>(world, 5, 0, 0);
            //m_PrimaryFire.ObjectManager = ThisWorld.BackParticles;
        }

        #endregion


        #region Initialize()

        public override void Initialize()
        {
            base.Initialize();

            Load("debugship.xml");

            m_ScreenParams.SpriteAnimation.SetCurrFrameReel("anim1");

            m_WorldParams.Mass = new GameAttribute(.01f, 0, .01f);
            
            //GameManager.ParticleManager.AddEmitter(m_ThrustEmitter);
        }

        #endregion


        #region ProcessInput(gametime, padstate)

        public override void ProcessInput(GameTime gametime, GamePadState padstate)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);
            KeyboardState keystate = Keyboard.GetState();


            // Call the base logic

            base.ProcessInput(gametime, padstate);


            // Check for boosts

            if (padstate.Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))   
                AddState((int)ShipStates.Boost);
            else
                RemoveState((int)ShipStates.Boost);


            // Adjust the scale

            if (keystate.IsKeyDown(Keys.Q))
                m_World.Camera.ScreenParams.Scale += -elapsed;
            if (keystate.IsKeyDown(Keys.W))
                m_World.Camera.ScreenParams.Scale += elapsed;
            else
                m_World.Camera.ScreenParams.Scale += elapsed * (padstate.ThumbSticks.Right.Y * 1);
            
            m_World.Camera.ScreenParams.Scale    = MathHelper.Clamp(m_World.Camera.ScreenParams.Scale, .33f, 3f);


            // Check for top speed clear

            if (keystate.IsKeyDown(Keys.D1))
                m_HighestSpeed = 0f;


            // Check for primary fire

            //if (keystate.IsKeyDown(Keys.S) || padstate.Buttons.X == ButtonState.Pressed)
              //  m_PrimaryFire.Emit(new Projectile(m_World, this, ThisWorld.BackParticles));

        }

        #endregion


        #region Update(gametime)

        public override void Update(GameTime gametime)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);
                               

            // Check for boosting

            if (InState((int)ShipStates.Boost))
            {
                m_WorldParams.MaxSpeed.SetModifier(2f, GameAttrModType.Multiply);
                //m_ScreenParams.Tint.B = 128;
                //m_ScreenParams.Tint.G = 128;
            }
            else
            {
                m_WorldParams.MaxSpeed.SetModifier(1f, GameAttrModType.Multiply);
                //m_ScreenParams.Tint..B = 255;
                //m_ScreenParams.Tint.G = 255;
            }


            // If within the planets gravity range, adjust the velocity

            float pdist = TrigHelper.Pythagorean(m_WorldParams.Position.X - ThisWorld.Planet.WorldParams.Position.X, m_WorldParams.Position.Y - ThisWorld.Planet.WorldParams.Position.Y);
            
            if (pdist <= ThisWorld.Planet.GravityRange)
            {
                Vector2 pull = ThisWorld.Planet.GetGravityPull(m_WorldParams.Position, 1);

                m_WorldParams.Velocity.X += pull.X;
                m_WorldParams.Velocity.Y += pull.Y;

                AddState((int)ShipStates.InGravityPull);
            }
            else
            {
                RemoveState((int)ShipStates.InGravityPull);
            }


            if (m_WorldParams.Accel.Val > 0)
            {
               m_ThrustEmitter.WorldParams.Normal.X = -this.m_WorldParams.Normal.X;
               m_ThrustEmitter.WorldParams.Normal.Y = -this.m_WorldParams.Normal.Y;
               m_ThrustEmitter.WorldParams.Position = this.m_WorldParams.Position;
                
               m_ThrustEmitter.Emit();
            }


            // Update the primary fire emitter

            //m_PrimaryFire.WorldParams.Normal    = this.m_WorldParams.Normal;
            //m_PrimaryFire.WorldParams.Position  = this.m_WorldParams.Position;


            // Call the base update
            
            base.Update(gametime);
        }

        #endregion


        #region DrawInView(view, spritebatch, gametime)

        public override void DrawInView(WorldView view, SpriteBatch spritebatch, GameTime gametime)
        {
                       
            // Draw the particles

            //m_ThrustEmitter.DrawInView(view, spritebatch, gametime);


            // Draw the primary fire

            //m_PrimaryFire.DrawInView(view, spritebatch, gametime);


            // Call the base draw

            base.DrawInView(view, spritebatch, gametime);


            // Track the speed

            float speed = TrigHelper.Pythagorean(m_WorldParams.Velocity.X, m_WorldParams.Velocity.Y);
            
            if (speed > m_HighestSpeed)
                m_HighestSpeed = speed;


            // Draw the speed

            spritebatch.DrawString(GameManager.DebugFont, String.Format("Speed = {0:.00}", speed), new Vector2(m_ScreenParams.Position.X + (m_ScreenParams.Scale * 100), m_ScreenParams.Position.Y + 100), Color.White);
            spritebatch.DrawString(GameManager.DebugFont, String.Format("High (1) = {0:.00}", m_HighestSpeed), new Vector2(m_ScreenParams.Position.X + (m_ScreenParams.Scale * 100), m_ScreenParams.Position.Y + 120), Color.White);
            spritebatch.DrawString(GameManager.DebugFont, String.Format("Normal ({0:.00}, {1:.00})", m_WorldParams.Normal.X, m_WorldParams.Normal.Y), new Vector2(m_ScreenParams.Position.X + (m_ScreenParams.Scale * 100), m_ScreenParams.Position.Y + 140), Color.White);
            
        }

        #endregion


        #region AI Routines

        public override void ProcessAI(GameTime gametime)
        {
            base.ProcessAI(gametime);

            if (InAIState((int)ShipAIStates.Evade))
                EvadeTargets(gametime);
            else if (InAIState((int)ShipAIStates.Chase))
                ChaseTargets(gametime);
        }


        protected void EvadeTargets(GameTime gametime)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);


            if (m_AITargets.Count > 0)
            {
                WorldObject target = m_AITargets[0];
                
                float xdist = target.WorldParams.Position.X - m_WorldParams.Position.X;
                float ydist = target.WorldParams.Position.Y - m_WorldParams.Position.Y;
                float dist  = TrigHelper.Pythagorean(xdist, ydist);
                float angle = TrigHelper.Vector2ToRadians(new Vector2(xdist, ydist));


                // Aim away from the target

                if (Math.Abs(TrigHelper.Vector2ToRadians(m_WorldParams.Normal) - angle) > MathHelper.Pi)
                    m_WorldParams.Normal = TrigHelper.RotateVector2(m_WorldParams.Normal, elapsed * (m_WorldParams.MaxRotateSpeed.Val));


                // Accelerate if too far from target

                if (dist < 1000)
                {
                    m_WorldParams.Accel.Val = m_WorldParams.Accel.Max;

                    if (dist < 500)
                        AddState((int)ShipStates.Boost);
                    else
                        RemoveState((int)ShipStates.Boost);
                }                   
                else
                     m_WorldParams.Accel.Val = 0;
                    
            }
        }


        protected void ChaseTargets(GameTime gametime)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);


            if (m_AITargets.Count > 0)
            {
                WorldObject target = m_AITargets[0];
                
                float xdist = target.WorldParams.Position.X - m_WorldParams.Position.X;
                float ydist = target.WorldParams.Position.Y - m_WorldParams.Position.Y;
                float dist  = TrigHelper.Pythagorean(xdist, ydist);
                float angle = TrigHelper.Vector2ToRadians(new Vector2(xdist, ydist));


                // Aim towards target

                RotateToVector(new Vector2(xdist, ydist), gametime);
            

                // Accelerate if too far from target

                if (dist > 100)
                {
                    m_WorldParams.Accel.Val = m_WorldParams.Accel.Max;

                    if (dist > 1000)
                        AddState((int)ShipStates.Boost);
                    else
                        RemoveState((int)ShipStates.Boost);
                }
                else
                    m_WorldParams.Accel.Val = 0;

            }
        }

        #endregion


        public override void StateChanged()
        {
            base.StateChanged();

            if (InState((int)ShipStates.Boost))
            {
               thrustEmitter.DelayMsecs = 5;
               thrustEmitter.MinForce = 150;
               thrustEmitter.MaxForce = 150;
            }
            else
            {
               thrustEmitter.DelayMsecs = 50;
               thrustEmitter.MinForce = 10;
               thrustEmitter.MaxForce = 10;
            }
        }
    }
}
*/