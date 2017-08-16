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

    public class StateChangingEventArgs : EventArgs
    {
        private IGameState newState;
        private IGameState oldState;


        public bool Cancel { get; set; }

        public IGameState NewState
        {
            get
            {
                return this.newState;
            }
        }

        public IGameState OldState
        {
            get
            {
                return this.oldState;
            }
        }
       

        
        public StateChangingEventArgs(IGameState newState, IGameState oldState)
        {
            this.Cancel = false;
            this.newState = newState;
            this.oldState = oldState;
        }
    }


    public class StateChangedEventArgs : EventArgs
    {
        private IGameState newState;

        public IGameState NewState
        {
            get
            {
                return this.newState;
            }
        }
      
        
        public StateChangedEventArgs(IGameState newState)
        {
            this.newState = newState;
        }
    }


    public interface IGameStateManager : IUpdateable, IDrawable 
    {
        event EventHandler<StateChangingEventArgs> StateChanging;
        event EventHandler<StateChangedEventArgs> StateChanged;

        IGameState State { get; }

        void PopState();
        void PushState(IGameState state);
        void SetState(IGameState state);
        bool ContainsState(IGameState state);
        void RemoveAllStates();
    }
}
