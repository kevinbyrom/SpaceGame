using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class Star : WorldEntity
    {

        #region Constructors

        public Star() : base() { }

        #endregion


        public override void Initialize()
        {
            base.Initialize();

            Load("star.xml");
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            // Make sure the object is within bounds

            float halfWidth   = this.Size.X / 2;
            float halfHeight  = this.Size.Y / 2;

            if (WorldPos.X >= Globals.CurrWorld.Width + halfWidth)      WorldPos.X = -halfWidth;
            if (WorldPos.X < -halfWidth)                                WorldPos.X = Globals.CurrWorld.Width + halfWidth;
            if (WorldPos.Y >= Globals.CurrWorld.Height + halfHeight)    WorldPos.Y = -halfHeight;
            if (WorldPos.Y < -halfHeight)                               WorldPos.Y = Globals.CurrWorld.Height + halfHeight;
        }
    }
}