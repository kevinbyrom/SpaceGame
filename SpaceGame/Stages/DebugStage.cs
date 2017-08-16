using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNAGameLib2D;


namespace WindowsGame1
{
   /* public class DebugStage : Stage
    {
        protected DebugView2 m_View;
        protected DebugWorld2 m_World;
        
        protected int m_FPS = 0;
        protected int m_LastFPS = 0;
        protected float m_FPSTotal = 0;
        protected DateTime m_FPSTime = DateTime.Now;


        #region Initialize()

        public override void Initialize()
        {
            int width = GameManager.Graphics.PreferredBackBufferWidth;
            int height = GameManager.Graphics.PreferredBackBufferHeight;
            Random rnd = new Random();

            
            // Prepare the world

            m_World = new DebugWorld2(width, height);
            m_World.Camera.Initialize();
            m_World.Camera.ViewWidth = width;
            m_World.Camera.ViewHeight = height;


            // Prepare the view

            m_View = new DebugView2(m_World, width, height);
            m_View.Initialize();
            m_View.ScreenParams.Position.X = 0;//width / 2;
            m_View.ScreenParams.Position.Y = 0;//height / 2;

        }

        #endregion


        #region Update(gametime)

        public override void Update(GameTime gametime)
        {
            KeyboardState keys = Keyboard.GetState();
            GamePadState padstate = GamePad.GetState(PlayerIndex.One);


            // Update the objects

            m_World.Emitter.Update(gametime);

            if (keys.IsKeyDown(Keys.A))
                m_World.Emitter.Emit();


            // Move the emitter 
                
            if (keys.IsKeyDown(Keys.Left))      m_World.Emitter.WorldParams.Position.X -= 1;
            if (keys.IsKeyDown(Keys.Right))     m_World.Emitter.WorldParams.Position.X += 1;
            if (keys.IsKeyDown(Keys.Up))        m_World.Emitter.WorldParams.Position.Y -= 1;
            if (keys.IsKeyDown(Keys.Down))      m_World.Emitter.WorldParams.Position.Y += 1;


            // Get the FPS

            GetFPS(gametime);
         }

        #endregion


        #region Draw(gametime)

        public override void Draw(GameTime gametime)
        {
            GraphicsDeviceManager graphics = GameManager.Graphics;

            graphics.GraphicsDevice.Clear(new Color(new Vector4(0,0,0,1)));

            
            // Draw the view

            m_View.Draw(null, gametime);


            // Draw the FPS

            SpriteBatch batch = new SpriteBatch(graphics.GraphicsDevice);

            batch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            
            DrawFPS(batch);           
            
            batch.End();
        }


        #endregion


        #region FPS Routines

        private void GetFPS(GameTime gametime)
        {
            TimeSpan elapsedtime = DateTime.Now - m_FPSTime;
            float elapsed = (float)gametime.ElapsedGameTime.TotalSeconds;

            m_FPSTotal += elapsed;

            if (m_FPSTotal >= 1)
            {
                m_LastFPS   = m_FPS;
                m_FPS       = 0;
                m_FPSTotal  = 0;
                m_FPSTime   = DateTime.Now;
            }

            m_FPS += 1;
        }


        private void DrawFPS(SpriteBatch batch)
        {
 
            batch.DrawString(GameManager.DebugFont, String.Format("FPS = {0}", m_LastFPS), new Vector2(0, 0), Color.White);

        }

        #endregion

    }*/
}
