/*using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace SpaceGame
{
    public class BattleWorld : World
    {
        public static int MAX_STARS = 100;

        public int NumPlayers { get; set; }
        public List<Ship> Ships { get; set; }
        public Star[,] Stars { get; set; }
        public Planet Planet { get; set; }
        public Vector2 Friction { get; set; }


        #region Constructors

        public BattleWorld(float width, float height) : base(width, height) { }
        
        #endregion


        #region override Initialize()

        public override void Initialize()
        {
            base.Initialize();


            // Set the friction

            Friction = new Vector2(.01f,.01f);


            // Initialize the ships

            NumPlayers = 2;

            Ships = new List<Ship>();
            
            for (int i = 0; i < NumPlayers; i++)
            {
                Ship ship = new Ship(this);

                ship.Initialize();
                ship.WorldPos.X = this.Width / 2;
                ship.WorldPos.Y = this.Height / 2;

                Ships.Add(ship);
            }


            // Initialize the stars

            Stars = new Star[2,1000];
            
            for (int l = 0; l < 2; l++)
            {
                for (int i = 0; i < MAX_STARS; i++)
                {
                    Stars[l,i] = new Star();

                    Stars[l,i].Initialize();
                    Stars[l,i].WorldPos.X   = GameEngine2D.Randomizer.Next((int)this.Width);
                    Stars[l,i].WorldPos.Y   = GameEngine2D.Randomizer.Next((int)this.Height);
                    Stars[l, i].WorldPos.Z = l;// l + 1;
                    Stars[l,i].Sprite.Tint  = new Vector3(1,1,1);
                    Stars[l,i].Sprite.Scale = MathHelper.Lerp(.5f, .25f, l / 1);
                }
            }


            // Initialize the planet

            Planet = new Planet(20, 450);
            Planet.Initialize();
            Planet.WorldPos.X = GameEngine2D.Randomizer.Next((int)this.Width);
            Planet.WorldPos.Y = GameEngine2D.Randomizer.Next((int)this.Height);

        }

        #endregion

    }
}
*/