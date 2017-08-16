using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceGame
{
    public interface IGameState : IUpdateable, IDrawable 
    {
        event EventHandler Entered;
        event EventHandler Exiting;

        void Initialize();
        void Enter();
        void Exit();
    }
}
