using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class Planet : MassObject
    {

        #region Constructors

        public Planet(World world) : base(world) { }

        #endregion


        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            m_Params.Texture = TextureManager.LoadTexture(graphics, "Planet", Path.Combine(Game1.AssetsPath, "Planet_1.png"));
            m_Params.SpriteRect = new Rectangle(0, 0, 200, 200);
            m_Params.Origin.X = 100;
            m_Params.Origin.Y = 100;
            m_Params.IsVisible = true;
        }
    }
}
