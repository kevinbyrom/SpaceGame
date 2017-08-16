using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class ScreenObject
    {
        protected ScreenObjParams m_ScreenParams;
        

        #region Public Properties

        public ScreenObjParams ScreenParams
        {
            get
            {
                return m_ScreenParams;
            }
        }

        #endregion


        public ScreenObject()
        {
            m_ScreenParams = new ScreenObjParams();
        }


        #region Initialize(graphics)

        public virtual void Initialize(GraphicsDeviceManager graphics)
        {
            m_ScreenParams.Position.X = 100;
            m_ScreenParams.Position.Y = 100;
        }

        #endregion


        #region Update(gametime)

        public virtual void Update(GameTime gametime)
        {
        }

        #endregion


        #region ProcessInput(gametime, padstate)

        public virtual void ProcessInput(GameTime gametime, GamePadState padstate)
        {
        }

        #endregion


        #region Draw(spritebatch)

        public virtual void Draw(SpriteBatch spritebatch)
        {
            Draw(spritebatch, m_ScreenParams);
        }

        public virtual void Draw(SpriteBatch spritebatch, ScreenObjParams screenparams)
        {
            if (screenparams.IsVisible)
                spritebatch.Draw(screenparams.Texture, screenparams.Position, screenparams.SpriteRect, screenparams.Tint, screenparams.Rotation, screenparams.Origin, screenparams.Scale, SpriteEffects.None, screenparams.Depth);
        }

        #endregion

    }
}
