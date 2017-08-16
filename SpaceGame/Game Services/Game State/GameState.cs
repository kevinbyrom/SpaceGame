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
    public abstract class GameState : DrawableGameComponent, IGameState
    {

        public GameState(Game game) : base(game)
        {
        }


        public virtual void Initialize()
        {
        }


        public virtual void Enter()
        {
        }


        public virtual void Exit()
        {
        }
    }
}
