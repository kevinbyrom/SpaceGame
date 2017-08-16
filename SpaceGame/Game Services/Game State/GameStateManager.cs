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
    public class GameStateManager : DrawableGameComponent, IGameStateManager 
    {
        private Stack<IGameState> gameStates;
        private object syncLock = new object();
        
        public event EventHandler<StateChangedEventArgs> StateChanged;


        public IGameState CurrentState 
        { 
            get
            {
                return this.gameStates.Peek();
            }
        }


        public GameStateManager(Game game)   : base(game)
        {
            this.gameStates = new Stack<IGameState>();
        }


        #region Update Routines

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            lock(this.syncLock)
            {
                foreach (IGameState state in this.gameStates)
                    state.Update(gameTime);
            }
        }

        #endregion


        #region Draw Routines

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            lock(this.syncLock)
            {
                foreach (IGameState state in this.gameStates)
                    state.Draw(gameTime);
            }
        }

        #endregion


        #region Push Routines

        /// <summary>
        /// Pushes a new state onto the stack
        /// </summary>
        /// <param name="state">State to push</param>
        
        public void PushState(IGameState state)
        {
            PushState(state, false);
        }


        /// <summary>
        /// Pushes a new state onto the stack
        /// </summary>
        /// <param name="state">State to push</param>
        
        public void PushState(IGameState state, bool force)
        {
            IGameState oldState = null;
            

            lock(syncLock)
            {
                oldState = this.gameStates.Peek();

                if (OnStateChanging(state, oldState))
                {
                    this.gameStates.Push(state);
                    OnStateChanged(state);
                }
            }
        }

        #endregion


        #region Pop Routines

        /// <summary>
        /// Pops the current state from the stack
        /// </summary>
        
        public void PopState()
        {
            PopState(false);
        }


        /// <summary>
        /// Pops the current state from the stack
        /// </summary>
        
        public void PopState(bool force)
        {
            IGameState oldState = null;
            IGameState newState = null;


            lock(syncLock)
            {
                int count = this.gameStates.Count();

                oldState = this.gameStates.Peek();

                if (count > 1)
                    newState = this.gameStates.ElementAt(count - 2);

                if (OnStateChanging(newState, oldState))
                {
                    this.gameStates.Pop();
                    OnStateChanged(newState);
                }
            }
        }

        #endregion


        #region Set State Routines

        /// <summary>
        /// Sets the current state
        /// </summary>
        /// <param name="state"></param>
        
        public void SetState(IGameState state)
        {
            SetState(state, false);
        }


        /// <summary>
        /// Sets the current state
        /// </summary>
        /// <param name="state"></param>
        
        public void SetState(IGameState state, bool force)
        {
            IGameState oldState = null;
            
            lock(this.syncLock)
            {
                oldState = this.gameStates.Peek();

                if (OnStateChanging(state, oldState, force))
                {
                    this.gameStates.Clear();
                    this.gameStates.Push(state);

                    OnStateChanged(state);
                }
            }
        }

        #endregion


        #region Remove All States Routines

        /// <summary>
        /// Removes all states
        /// </summary>
        
        public void RemoveAllStates()
        {
            RemoveAllStates(force);
        }


        /// <summary>
        /// Removes all states
        /// </summary>
        
        public void RemoveAllStates(bool force)
        {
            IGameState oldState = null;
            
            lock(this.syncLock)
            {
                oldState = this.gameStates.Peek();

                if (OnStateChanging(null, oldState, force))
                {
                    this.gameStates.Clear();
                    
                    OnStateChanged(null);
                }
            }
        }

        #endregion


        /// <summary>
        /// Checks whether or not the stack contains the given state
        /// </summary>
        /// <param name="state">State to check for</param>
        /// <returns>Returns true if the stack contains the state</returns>
        
        public bool ContainsState(IGameState state)
        {
            bool contains = false;

            lock(this.syncLock)
            {
                contains = this.gameStates.Contains(state);
            }

            return contains;
        }


        #region State Changing / Changed Routines
        
        /// <summary>
        /// Virtual handler for state changing
        /// </summary>
        /// <param name="newState"></param>
        /// <param name="oldState"></param>
        
        protected virtual bool OnStateChanging(IGameState newState, IGameState oldState, bool force)
        {
            bool allowChange = true;


            // If there is a changed handler, call it now

            EventHandler<StateChangingEventArgs> handler = this.StateChanging;

            if (handler != null)
            {
                StateChangingEventArgs args = new StateChangingEventArgs(newState, oldState);

                this.StateChanging(this, args);

                // If cancel was set, revert back to previous state

                if (!force && args.Cancel)
                    allowChange = false;               
            }


            // If we have changed states, call the states' enter and exit methods

            if (allowChange)
            {
                if (oldState != null)
                    oldState.Exit();

                if (newState != null)
                    newState.Enter();
            } 

            return allowChange;
        }


        /// <summary>
        /// Virtual handler for state changes
        /// </summary>
        /// <param name="newState"></param>
        
        protected virtual void OnStateChanged(IGameState newState)
        {
            
            // If there is a changed handler, call it now

            EventHandler<StateChangedEventArgs> handler = this.StateChanged;

            if (handler != null)
            {
                StateChangedEventArgs args = new StateChangedEventArgs(newState);

                this.StateChanged(this, args);
            }
        }

        #endregion

    }
}
