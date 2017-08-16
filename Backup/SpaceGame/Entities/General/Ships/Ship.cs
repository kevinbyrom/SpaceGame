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



namespace SpaceGame
{




    public class Ship : DrawableGameComponent, IShip
    {
        private bool isThrusting;
        private ShipTurnDirection turnDirection;

        protected Vector3 worldPos;
        protected Vector2 velocity;
        protected float acceleration;
        protected float mass;
        protected float friction;
        protected float maxSpeed;
        protected float maxRotateSpeed;


        public bool IsThrusting
        {
            get
            {
                return this.isThrusting;
            }
        }

        public bool IsTurning
        {
            get
            {
                return this.turnDirection != ShipTurnDirection.None;
            }
        }


        #region Constructors

        public Ship(Game game) : base(game) 
        { 
            this.worldPos = Vector3.Zero;
            this.velocity = Vector2.Zero;
            this.acceleration = 1;
            this.mass = 1;
            this.friction = 0;
            this.maxSpeed = 1;
            this.maxRotateSpeed = 1;

            this.isThrusting = false;
            this.turnDirection = ShipTurnDirection.None;
        }

        #endregion



        #region ProcessInput(gameTime, padState)

        public void ProcessInput(GameTime gameTime, GamePadState padState)
        {
            
            // Calculate the thrust (0.0 to 1.0) and use it to determine the dest velocity

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Thrust(1);
            else if (padState.ThumbSticks.Left.Y > 0)
                Thrust(padState.ThumbSticks.Left.Y);
            else
                StopThrust();
           

            // Adjust the rotation

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Turn(ShipTurnDirection.Left);
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Turn(ShipTurnDirection.Right);
            else
                Turn(ShipTurnDirection.None);

        }

        #endregion


        #region Update Routines

        public override void Update(GameTime gameTime)
        {

            // Perform the base logic

            base.Update(gameTime);


            // Perform the updates

            UpdateMove(gameTime);
                             

            // Update the weapons


        }


        private void UpdateMove(GameTime gameTime)
        {
    
            // If turning, rotate ship

            switch(this.turnDirection)
            {
                case ShipTurnDirection.Left:
                    this.normal = TrigHelper.RotateVector3(this.Normal, (float)gameTime.ElapsedGameTime.TotalSeconds * -this.MaxRotateSpeed);
                    break;

                case ShipTurnDirection.Right:
                    this.normal = TrigHelper.RotateVector3(this.Normal, (float)gameTime.ElapsedGameTime.TotalSeconds * this.MaxRotateSpeed);
                    break;
            }


            // If within the planets gravity range, adjust the velocity

            /*float planetDist = TrigHelper.Pythagorean(this.WorldPos.X - this.World.Planet.WorldPos.X, WorldPos.Y - this.World.Planet.WorldPos.Y);
            
            if (planetDist <= this.World.Planet.GravityRange)
            {
                Vector3 pull = this.World.Planet.GetGravityPull(this.WorldPos, 1);

                this.Velocity.X += pull.X;
                this.Velocity.Y += pull.Y;

                AddState((int)ShipStates.InGravityPull);
            }
            else
            {
                RemoveState((int)ShipStates.InGravityPull);
            }*/
                        

            
            // If the ship is thrusting, accelerate
            
            if (this.isThrusting)
            {
                //  foreach (Thruster thruster in this.thrusters)
                //    thruster.EmitThrust();

                // Calculate the target velocity

                Vector2 target;

                target.X = this.normal.X * this.maxSpeed;
                target.Y = this.normal.Y * this.maxSpeed;

                float highX = Math.Max(Math.Abs(target.X), Math.Abs(this.velocity.X));
                float highY = Math.Max(Math.Abs(target.Y), Math.Abs(this.velocity.Y));

                this.velocity.X = MathHelper.Clamp(this.velocity.X + (target.X * this.acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds), -highX, highX);
                this.velocity.Y = MathHelper.Clamp(this.velocity.Y + (target.Y * this.acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds), -highY, highY);

            }
            


            // Set the animation based on the state

            //if (WorldParams.Accel.Val > .5)
            //    ScreenParams.SpriteAnimation.SetCurrFrameReel("anim1");
            //else
            //    ScreenParams.SpriteAnimation.SetCurrFrameReel("standard");



            // Apply friction

            this.velocity.X = this.velocity.X * (1f - (this.mass * this.friction.X));
            this.velocity.Y = this.velocity.Y * (1f - (this.mass * this.friction.Y));



            // Move the object
            
            this.worldPos.X += (float)gameTime.ElapsedGameTime.TotalSeconds * this.velocity.X;
            this.worldPos.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * this.velocity.Y;
            
            

            // Make sure the object is within world bounds

            /*float halfWidth     = this.Size.X / 2;
            float halfHeight    = this.Size.Y / 2;

            if (this.worldPos.X >= World.Width)                 this.worldPos.X = -halfWidth;
            if (this.worldPos.X < -halfWidth)                   this.worldPos.X = World.Width + halfWidth;
            if (this.worldPos.Y >= World.Height + halfHeight)   this.worldPos.Y = -halfHeight;
            if (this.worldPos.Y < -halfHeight)                  this.worldPos.Y = World.Height + halfHeight;*/
            
        }

        #endregion


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            //this.Sprite.Rotation = TrigHelper.Vector3ToRadians(this.Normal);
        }


        #region Actions

        public void Thrust(float level)
        {
            isThrusting         = true;
            this.Accel.RawVal   = this.Accel.Max * level;
        }


        public void StopThrust()
        {
            isThrusting         = false;
            this.Accel.RawVal   = 0;
        }


        public void Turn(ShipTurnDirection direction)
        {
            this.turnDirection = direction;
        }


        public void FirePrimaryWeapon()
        {
        }


        public void FireSecondaryWeapon()
        {
        }


        public void Damage(float amount)
        {
        }

        #endregion


    }
}
