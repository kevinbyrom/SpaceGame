using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


namespace WindowsGame1
{
    public class Ship : WorldObject
    {

        #region Constructors

        public Ship(World world) : base(world) { }

        #endregion


        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            
            // Setup the speed of the ship

            m_WorldParams.Friction          = new WOAttribute(World.DefaultFriction, 0, World.DefaultFriction);
            m_WorldParams.MaxSpeed          = new WOAttribute(1000, 0, 2000);
            m_WorldParams.MaxRotateSpeed    = new WOAttribute((float)(Math.PI * 2), 0, (float)(Math.PI * 2));

            
            // Setup the sprite

            m_ScreenParams.Texture      = TextureManager.LoadTexture(graphics, "Ship", Path.Combine(Game1.AssetsPath, "ship.png"));
            m_ScreenParams.SpriteRect   = new Rectangle(0, 0, 100, 100);
            m_ScreenParams.Origin.X     = 50;
            m_ScreenParams.Origin.Y     = 50;
            m_ScreenParams.IsVisible    = true;
        }


        public override void ProcessInput(GameTime gametime, GamePadState padstate)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);


            // Calculate the thrust (0.0 to 1.0) and use it to determine the dest velocity

            m_WorldParams.Accel.Val = padstate.ThumbSticks.Left.Y * m_WorldParams.Accel.Max;
            m_WorldParams.MaxSpeed.SetModifier(padstate.Buttons.A == ButtonState.Pressed ? 2f : 1f, ModifierType.Multiply);


            // Adjust the scale and rotation

            m_World.Camera.ScreenParams.Scale    += elapsed * (padstate.ThumbSticks.Right.Y * 1);
            m_World.Camera.ScreenParams.Scale    = MathHelper.Clamp(m_World.Camera.ScreenParams.Scale, .5f, 2f);
            
            m_ScreenParams.Rotation += elapsed * (padstate.ThumbSticks.Left.X * m_WorldParams.MaxRotateSpeed.Val);

        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Make sure the object is within bounds

            int halfwidth   = (int)(m_ScreenParams.SpriteRect.Width * m_ScreenParams.Scale) / 2;
            int halfheight  = (int)(m_ScreenParams.SpriteRect.Height * m_ScreenParams.Scale) / 2;

            if (m_WorldParams.Position.X >= m_World.Bounds.Width + halfwidth)    m_WorldParams.Position.X = -halfwidth;
            if (m_WorldParams.Position.X < -halfwidth)                           m_WorldParams.Position.X = m_World.Bounds.Width + halfwidth;
            if (m_WorldParams.Position.Y >= m_World.Bounds.Height + halfheight)  m_WorldParams.Position.Y = -halfheight;
            if (m_WorldParams.Position.Y < -halfheight)                          m_WorldParams.Position.Y = m_World.Bounds.Height + halfheight;
        }
    }
}
