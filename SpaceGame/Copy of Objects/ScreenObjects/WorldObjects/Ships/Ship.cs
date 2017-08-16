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
    public class Ship : MassObject
    {

        #region Constructors

        public Ship(World world) : base(world) { }

        #endregion


        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            
            // Setup the speed of the ship

            m_Speed_Units_Sec = new WOAttribute(1000, 0, 2000);
            m_Speed_Rotate_Sec = new WOAttribute((float)(Math.PI * 2), 0, (float)(Math.PI * 2));

            
            // Setup the sprite

            m_Params.Texture = TextureManager.LoadTexture(graphics, "Ship", Path.Combine(Game1.AssetsPath, "ship.png"));
            m_Params.SpriteRect = new Rectangle(0, 0, 100, 100);
            m_Params.Origin.X = 50;
            m_Params.Origin.Y = 50;
            m_Params.IsVisible  = true;
        }


        public override void ProcessInput(GameTime gametime, GamePadState padstate)
        {
            float elapsed = ((float)gametime.ElapsedGameTime.Milliseconds / 1000);


            // Calculate the thrust (0.0 to 1.0) and use it to determine the dest velocity

            m_Accel.Val = padstate.ThumbSticks.Left.Y * m_Accel.Max;

            m_Speed_Units_Sec.SetModifier(padstate.Buttons.A == ButtonState.Pressed ? 2f : 1f, ModifierType.Multiply);


            // Adjust the scale and rotation

            m_World.Camera.WOParams.Scale       += elapsed * (padstate.ThumbSticks.Right.Y * 1);
            m_World.Camera.WOParams.Scale = MathHelper.Clamp(m_World.Camera.WOParams.Scale, .5f, 2f);
            
            m_Params.Rotation    += elapsed * (padstate.ThumbSticks.Left.X * m_Speed_Rotate_Sec.Val);

           
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);


            // Make sure the object is within bounds

            int halfwidth   = (int)(m_Params.SpriteRect.Width * m_Params.Scale) / 2;
            int halfheight  = (int)(m_Params.SpriteRect.Height * m_Params.Scale) / 2;

            if (m_Params.Position.X >= m_World.Bounds.Width + halfwidth)    m_Params.Position.X = -halfwidth;
            if (m_Params.Position.X < -halfwidth)                           m_Params.Position.X = m_World.Bounds.Width  + halfwidth;
            if (m_Params.Position.Y >= m_World.Bounds.Height + halfheight)  m_Params.Position.Y = -halfheight;
            if (m_Params.Position.Y < -halfheight)                          m_Params.Position.Y = m_World.Bounds.Height + halfheight;
        }


        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
