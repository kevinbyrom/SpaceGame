using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;



namespace SpaceGame
{
    public enum ShipTurnDirection
    {
        None,
        Left,
        Right
    }


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


    public interface IShip : IDrawable, IUpdateable 
    {
        bool IsThrusting { get; }
        bool IsTurning { get; }

        void Thrust();
        void StopThrust();
        void Turn(ShipTurnDirection direction);
        
        void Damage(float amount);
    }
}
