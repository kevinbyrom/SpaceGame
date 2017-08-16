using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNAGameLib2D;


namespace SpaceGame
{
    public class BattleState : GameState
    {
        private List<IShip> ships;
        //public BattleWorld World;
        //public BattleView View;


        public BattleState(Game game) : base(game)
        {
        }


        #region Initialize()

        public override void Initialize()
        {
            IShip ship = new Ship(this.Game);

            this.ships.Add(ship);
        }

        #endregion


        #region Update(gametime)

        public override void Update(GameTime gameTime)
        {
            KeyboardState keys      = Keyboard.GetState();
            GamePadState padState   = GamePad.GetState(PlayerIndex.One);


            // Update the planet

            // Update the ships
            
            foreach (IShip ship in this.ships)
                ship.Update(gameTime);
            
            // Update the camera

         }

        #endregion


        #region Draw Routines

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            // Set the viewport from camera
            // Draw the world
            // Draw the planet
            // Draw the ships

            foreach (IShip ship in this.ships)
                ship.Draw(gameTime);

            
            // Restore viewport
        }

        #endregion

    }
}
