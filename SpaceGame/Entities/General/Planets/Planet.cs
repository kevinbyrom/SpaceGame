/*using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;
using XNAGameLib2D.Utilities;


namespace SpaceGame
{
    public class Planet : BattleWorldEntity
    {
        private float gravity;
        private float gravityRange;


        #region Public Properties

        public float Gravity
        {
            get
            {
                return gravity;
            }
        }

        public float GravityRange
        {
            get
            {
                return gravityRange;
            }
        }

        #endregion


        #region Constructors

        public Planet(float gravity, float gravityRange) : base() 
        {
            this.AffectedByGravity  = false;
            this.gravity            = gravity;
            this.gravityRange       = gravityRange;
        }

        #endregion


        #region override Initialize()

        public override void Initialize()
        {
            base.Initialize();

            Load("Entities.xml", "planet");
        }

        #endregion


        #region Update(gameTime)

        public override void Update(GameTime gameTime)
        {
            float elapsed = ((float)gameTime.ElapsedGameTime.Milliseconds / 1000);

            base.Update(gameTime);
            
            foreach (WorldEntityBound bound in Bounds)
            {
                bound.WorldPos.X = this.WorldPos.X + bound.LocalPos.X;
                bound.WorldPos.Y = this.WorldPos.Y + bound.LocalPos.Y;
                bound.WorldPos.Z = this.WorldPos.Z + bound.LocalPos.Z;
                bound.Update(gameTime);
            }

           // this.Normal = TrigHelper.RotateVector2(this.Normal, elapsed * (-this.MaxRotateSpeed.CurrVal));
        }

        #endregion


        #region GetGravityPull(pos, mass)

        public Vector3 GetGravityPull(Vector3 pos, float mass)
        {
            Vector3 pull = Vector3.Zero;
            
            float xDist = WorldPos.X - pos.X;
            float yDist = WorldPos.Y - pos.Y;
            float angle = TrigHelper.Vector3ToRadians(new Vector3(xDist, yDist, 0));

            
            // Get the distance to the planet

            float dist  = TrigHelper.Pythagorean(xDist, yDist);
            
            if (dist > 0f)
            {
                float hyp = ((this.gravityRange - Math.Abs(dist)) / this.gravityRange) * (this.gravity * mass) * (dist / Math.Abs(dist));
            
                pull = TrigHelper.RadiansToVector3(angle);
                pull.X *= hyp;
                pull.Y *= hyp;
            }   

            return pull;
        }

        #endregion

    }
}
*/