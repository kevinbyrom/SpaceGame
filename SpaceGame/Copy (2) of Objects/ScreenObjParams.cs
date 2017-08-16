using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class ScreenObjParams : ICloneable 
    {
        public bool IsVisible;
        public Vector2 Origin;
        public Vector2 Position;
        public float Rotation;
        public float Scale;
        public float Depth;
        public Color Tint;
        public Rectangle SpriteRect;
        public Texture2D Texture;


        #region Constructors

        public ScreenObjParams() : this(Vector2.Zero, Color.White, 0, 1, 1) { }
        
        public ScreenObjParams(Vector2 position, Color tint, float rotation, float scale, float depth) : this(position, tint, rotation, scale, depth, true, Vector2.Zero, Rectangle.Empty, null) { }
        
        public ScreenObjParams(Vector2 position, Color tint, float rotation, float scale, float depth, bool isVisible, Vector2 origin, Rectangle spriterect, Texture2D texture)
        {
            this.Position   = position;
            this.Tint       = tint;
            this.Rotation   = rotation;
            this.Scale      = scale;
            this.Depth      = depth;
            this.IsVisible  = isVisible;
            this.Origin     = origin;
            this.SpriteRect = spriterect;
            this.Texture    = texture;
        }

        #endregion


        #region Clone()

        public object Clone()
        {
            return new ScreenObjParams(Position, Tint, Rotation, Scale, Depth, IsVisible, Origin, SpriteRect, Texture);
        }

        #endregion

    }
}
