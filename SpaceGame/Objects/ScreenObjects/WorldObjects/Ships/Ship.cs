using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNAGameLib2D;


namespace WindowsGame1
{

    public enum ShipStates : int
    {
        Normal          = 0,
        Boost           = 1,
        InGravityPull   = 2
    }

    public enum ShipAIStates : int
    {
        Evade = 1,
        Chase = 2
    }


    public class Ship : WorldEntity
    {
        //protected List<Thruster> thrusters;
        //protected Weapon m_PrimaryFire;
        //protected Weapon m_SecondaryFire;


        #region Constructors

        public Ship(IWorld world) : base(world) { }

        #endregion


        #region Initialize()

        public override void Initialize()
        {
            base.Initialize();

            Load("Ship.xml");
        }

        #endregion


        #region Load Routines

        public override void Load(XmlNode node)
        {
            base.Load(node);


            // Load the thrusters

            foreach (XmlNode thrnode in node.SelectNodes("thruster"))
            {
                Thruster thruster = new Thruster(this.World);
                
                thruster.Load(thrnode);

                this.thrusters.Add(thruster);
            }


            // Load the weapons
        }

        #endregion


        #region ProcessInput(gameTime, padState)

        public override void ProcessInput(GameTime gameTime, GamePadState padState)
        {
            float elapsed = ((float)gameTime.ElapsedGameTime.Milliseconds / 1000);


            // Calculate the thrust (0.0 to 1.0) and use it to determine the dest velocity

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                WorldParams.Accel.Val = WorldParams.Accel.Max;
            else
                WorldParams.Accel.Val = padState.ThumbSticks.Left.Y * WorldParams.Accel.Max;

           
            // Adjust the rotation

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                WorldParams.Normal = TrigHelper.RotateVector2(WorldParams.Normal, elapsed * (-WorldParams.MaxRotateSpeed.Val));
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                WorldParams.Normal = TrigHelper.RotateVector2(WorldParams.Normal, elapsed * (WorldParams.MaxRotateSpeed.Val));
            else
                WorldParams.Normal = TrigHelper.RotateVector2(WorldParams.Normal, elapsed * (padstate.ThumbSticks.Left.X * WorldParams.MaxRotateSpeed.Val));

        }

        #endregion


        #region Update(gameTime)

        public override void Update(GameTime gameTime)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);


            // If within the planets gravity range, adjust the velocity

            /*float pdist = TrigHelper.Pythagorean(m_WorldParams.Position.X - m_World.Planet.WorldParams.Position.X, m_WorldParams.Position.Y - m_World.Planet.WorldParams.Position.Y);
            
            if (pdist <= m_World.Planet.GravityRange)
            {
                Vector2 pull = m_World.Planet.GetGravityPull(m_WorldParams.Position, 1);

                m_WorldParams.Velocity.X += pull.X;
                m_WorldParams.Velocity.Y += pull.Y;

                AddState((int)ShipStates.InGravityPull);
            }
            else
            {
                RemoveState((int)ShipStates.InGravityPull);
            }*/

            // Perform the base logic

            base.Update(gameTime);

            
            // Emit thrust particles if the ship is thrusting
            
            if (WorldParams.Accel.Val > 0)
            {
                foreach (Thruster thruster in this.thrusters)
                    thruster.EmitThrust();
            }
            

            // Set the animation based on the state

            if (WorldParams.Accel.Val > .5)
                ScreenParams.SpriteAnimation.SetCurrFrameReel("anim1");
            else
                ScreenParams.SpriteAnimation.SetCurrFrameReel("standard");


            // Make sure the object is within bounds

            int halfWidth   = (int)(ScreenParams.SpriteRect.Width * ScreenParams.Scale) / 2;
            int halfHeight  = (int)(ScreenParams.SpriteRect.Height * ScreenParams.Scale) / 2;

            if (WorldParams.Position.X >= World.Width + halfWidth)      WorldParams.Position.X = -halfWidth;
            if (WorldParams.Position.X < -halfWidth)                    WorldParams.Position.X = World.Width + halfWidth;
            if (WorldParams.Position.Y >= World.Height + halfHeight)    WorldParams.Position.Y = -halfHeight;
            if (WorldParams.Position.Y < -halfHeight)                   WorldParams.Position.Y = World.Height + halfHeight;
        }

        #endregion


        #region Draw(spriteBatch, gameTime)

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //if (m_World.Camera.IsInVisibleRange(screenparams.GetScreenRect()))   
                base.Draw(spriteBatch, gameTime);
        }

        #endregion

    }
}
