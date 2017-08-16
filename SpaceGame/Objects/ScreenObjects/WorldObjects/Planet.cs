using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAGameLib2D;


namespace WindowsGame1
{
    public class Planet : WorldEntity
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

        public Planet(World world, float gravity, float gravityRange) : base(world) 
        {
            this.gravity       = gravity;
            this.gravityRange  = gravityRange;
        }

        #endregion


        #region Initialize()

        public override void Initialize()
        {
            base.Initialize();

            Load("planet.xml");
        }

        #endregion


        #region Update(gameTime)

        public override void Update(GameTime gameTime)
        {
            float elapsed = ((float)gameTime.ElapsedGameTime.Milliseconds / 1000);

            base.Update(gameTime);
            
            WorldParams.Normal = TrigHelper.RotateVector2(WorldParams.Normal, elapsed * (-WorldParams.MaxRotateSpeed.Val));
        }

        #endregion


        #region GetGravityPull(pos, mass)

        public Vector2 GetGravityPull(Vector3 pos, float mass)
        {
            Vector2 pull = Vector2.Zero;
            
            float xDist = WorldParams.Position.X - pos.X;
            float yDist = WorldParams.Position.Y - pos.Y;
            float angle = TrigHelper.Vector2ToRadians(new Vector2(xDist, yDist));

            
            // Get the distance to the planet

            float dist  = TrigHelper.Pythagorean(xDist, yDist);
            
            if (dist > 0f)
            {
                float hyp = ((this.gravityRange - Math.Abs(dist)) / this.gravityRange) * (this.gravity * mass) * (dist / Math.Abs(dist));
            
                pull = TrigHelper.RadiansToVector2(angle);
                pull.X *= hyp;
                pull.Y *= hyp;
            }   

            return pull;
        }

        #endregion

    }
}
