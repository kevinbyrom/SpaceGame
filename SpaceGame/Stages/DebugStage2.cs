using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class DebugStage2 : Stage
    {
        protected DebugView view;
        protected DebugWorld world;
        protected int currFPS = 0;
        protected int lastFPS = 0;
        protected float totalFPS = 0;
        protected DateTime timeFPS = DateTime.Now;


        #region Initialize()

        public override void Initialize()
        {
            Random rnd = new Random();

            
            // Prepare the world

            this.World = new DebugWorld(1280 * 3, 720 * 3);
            this.World.Camera.Initialize();
            this.World.Camera.ViewWidth = 1440;//1280;
            this.World.Camera.ViewHeight = 900;//720

            // Prepare the view

            this.view = new DebugView(this.World, 1280, 720);
            this.view.Initialize();
            this.view.ScreenParams.Position.X = 0;
            this.view.ScreenParams.Position.Y = ((1024 - 720) / 2);


            // Add and prepare the stars

            for (int i = 0; i < 200; i++)
            {
                float distance = ((float)rnd.Next(100) / 100f) + .1f;

                Star star = new Star(this.World);
                star.Initialize();

                star.WorldParams.Position.X     = rnd.Next((int)this.World.Width);
                star.WorldParams.Position.Y     = rnd.Next((int)this.World.Height);
                star.WorldParams.MaxSpeed.Val   = distance * 10;
                star.WorldParams.Normal         = TrigHelper.RotateVector2(new Vector2(1,0), (float)rnd.Next((int)(MathHelper.Pi * 200)) / 100);
                star.WorldParams.Scale          = distance * .5f;                
                star.ScreenParams.Tint          = new Color(new Vector4(1f, 1f, 1f, distance));//new Color(new Vector3(.8f + ((float)rnd.Next(30) / 100f), .8f + ((float)rnd.Next(30) / 100f), .8f + ((float)rnd.Next(30) / 100f)));
 
                this.World.Stars.Add(star);
            }

            // Add and prepare the ships

            DebugShip ship = new DebugShip(this.World);
            ship.Initialize();
            this.World.Ships.Add(ship);
            //ship.WorldParams.UseCamera = false;

            DebugShip ship2 = new DebugShip(this.World);
            ship2.Initialize();
            ship2.AITarget.Add(ship);
            ship2.SetAIState((int)ShipAIStates.Chase);
            /*ship2.ScreenModifiers.Add(new CompoundModifier<ScreenObjParams>( new Automator<ScreenObjParams>[] {
                                                                                                                             new ChainAutomator<ScreenObjParams>(new TintAutomator[] { TintAutomator.ToColor( new Vector4(.5f,.5f,1,TintAutomator.IgnoreColor), 200), TintAutomator.ToColor(new Vector4(1,1,1,TintAutomator.IgnoreColor), 200) }, ChainAutomatorRepeatMode.Repeat, 0f),
                                                                                                                             TintAutomator.FadeOutIn(.5f, 1f, 1000, ChainAutomatorRepeatMode.Repeat)
                                                                                                                        }, ChainAutomatorRepeatMode.Repeat, 0));*/
                                                                                                                      
            this.World.Ships.Add(ship2);

            // Prepare the planet
                  
            this.World.Planet.Initialize();
            this.World.Planet.WorldParams.Position.X = this.World.Width / 2;//rnd.Next(this.World.Bounds.Width);
            this.World.Planet.WorldParams.Position.Y = this.World.Height / 2;//rnd.Next(this.World.Bounds.Height);
   
            // Track the ships

            this.World.Camera.Targets.Clear();

            //foreach (Ship tship in this.World.Ships)
                this.World.Camera.Targets.Add(ship);

        }

        #endregion


        #region Update(gameTime)

        public override void Update(GameTime gameTime)
        {
            GamePadState padState = GamePad.GetState(PlayerIndex.One);


            // Update the objects

            this.World.Planet.Update(gameTime);
            this.World.Planet.ProcessInput(gameTime, padState);

            foreach (Star star in this.World.Stars)
            {
                star.Update(gametime);
            }

              
            this.World.Ships[0].Update(gameTime);
            this.World.Ships[0].ProcessInput(gameTime, padState);

            this.World.Ships[1].Update(gameTime);
            this.World.Ships[1].ProcessAI(gameTime);

            //foreach (Ship ship in this.World.Ships)
            //{
              //  ship.Update(gametime);

                // Process the input
                
                //ship.ProcessInput(gametime, padstate);
            //}

            this.World.Camera.Update(gameTime);


            // Get the FPS

            GetFPS(gameTime);
          

            // Check for debug input

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.C))
                this.World.Ships[1].SetAIState((int)ShipAIStates.Chase);
            if (keyState.IsKeyDown(Keys.E))
                this.World.Ships[1].SetAIState((int)ShipAIStates.Evade);
         }

        #endregion


        #region Draw(gameTime)

        public override void Draw(GameTime gameTime)
        {
            GraphicsDeviceManager graphics = GameManager.Graphics;

            graphics.GraphicsDevice.Clear(new Color(new Vector4(0,0,.25f,1)));

            
            // Draw the view

            this.view.Draw(null, gameTime);


            // Draw the FPS

            SpriteBatch batch = new SpriteBatch(graphics.GraphicsDevice);

            batch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            
            DrawFPS(batch);           
            
            batch.End();
        }


        #endregion


        #region FPS Routines

        private void GetFPS(GameTime gameTime)
        {
            TimeSpan elapsedTime    = DateTime.Now - this.timeFPS;
            float elapsed           = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.totalFPS += elapsed;

            if (this.totalFPS >= 1)
            {
                this.lastFPS   = this.currFPS;
                this.currFPS       = 0;
                this.totalFPS  = 0;
                this.currFPSTime   = DateTime.Now;
            }

            this.currFPS += 1;
        }


        private void DrawFPS(SpriteBatch spriteBatch)
        {
 
            spriteBatch.DrawString(GameManager.DebugFont, String.Format("FPS = {0}", this.lastFPS), new Vector2(0, 0), Color.White);

        }

        #endregion

    }
}
