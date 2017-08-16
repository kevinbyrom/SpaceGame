using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;



namespace WindowsGame1
{
    class StarParticle : WorldEntity
    {
        protected TintAutomator tintAutomator;

        public StarParticle(IWorld world) : base(world)
        {
            Random rnd = new Random();

            
            // Load the graphics

            Load("star.xml");


            // Setup the modifiers

            tintModifier = new TintAutomator(new Vector4(1,1,1,1), new Vector4(1,0,0,0), 1000);
            ScreenAutomators.Add(tintModifier);
            WorldAutomators.Add(new ScaleAutomator(-1f, 1, 1000));
            

            // Set the initial values

            WorldParams.Normal        = TrigHelper.RadiansToVector2(MathHelper.ToRadians(rnd.Next(360)));
            WorldParams.Velocity.X    = rnd.Next(100) - 50; 
            WorldParams.Velocity.Y    = rnd.Next(100) - 50;
            WorldParams.Mass          = new GameAttribute(.01f, 0, .01f);
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            this.IsAlive = !tintModifier.IsDone;
        }
    }
}
