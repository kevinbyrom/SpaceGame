using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class WorldObjParams : ICloneable 
    {
        public Vector3 Position;
        public Vector2 Normal;
        public Vector2 Velocity;
        public WOAttribute Accel;
        public WOAttribute Friction;
        public WOAttribute MaxSpeed;
        public WOAttribute MaxRotateSpeed;


        #region Constructors

        public WorldObjParams() : this(Vector3.Zero, Vector2.Zero, Vector2.Zero, new WOAttribute(), new WOAttribute(), new WOAttribute(), new WOAttribute()) { }
        
        public WorldObjParams(Vector3 position, Vector2 normal, Vector2 velocity, WOAttribute accel, WOAttribute friction, WOAttribute maxspeed, WOAttribute maxrotatespeed)
        {
            this.Position       = position;
            this.Normal         = normal;
            this.Velocity       = velocity;
            this.Accel          = (WOAttribute)accel.Clone();
            this.Friction       = (WOAttribute)friction.Clone();
            this.MaxSpeed       = (WOAttribute)maxspeed.Clone();
            this.MaxRotateSpeed = (WOAttribute)maxrotatespeed.Clone();
        }

        #endregion


        #region Clone()

        public object Clone()
        {
            return new WorldObjParams(Position, Normal, Velocity, Accel, Friction, MaxSpeed, MaxRotateSpeed);
        }

        #endregion

    }
}
