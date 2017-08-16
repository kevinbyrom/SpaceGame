using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

 
namespace WindowsGame1
{

    public enum ModifierType
    {
        Add         = 0,
        Multiply    = 1
    }


    public class WOAttribute : ICloneable 
    {
        protected float m_Val;
        protected float m_Min;
        protected float m_Max;
        protected float m_Modifier;
        protected ModifierType m_ModifierType;
        protected DateTime m_ModifierTime;


        #region Properties

        public float Val
        {
            get
            {
                switch (m_ModifierType)
                {           
                    case ModifierType.Multiply:
                        return m_Val * m_Modifier;
                
                    case ModifierType.Add:
                    default:
                        return m_Val + m_Modifier;
                }
            }
            set
            {
                m_Val = MathHelper.Clamp(value, m_Min, m_Max);
            }
        }

        public float Min
        {
            get
            {
                return m_Min;
            }
        }

        public float Max
        {
            get
            {
                return m_Max;
            }
        }

        public DateTime ModifierTime
        {
            get
            {
                return m_ModifierTime;
            }
        }

        #endregion


        #region SetModifier(modifier, type)

        public void SetModifier(float modifier, ModifierType type)
        {
            m_Modifier      = modifier;
            m_ModifierType  = type;
            m_ModifierTime  = DateTime.Now;
        }

        #endregion


        #region Constructors

        public WOAttribute()
        {
            m_Val           = 0f;
            m_Min           = 0f;
            m_Max           = 1f;
            m_Modifier      = 0f;
            m_ModifierType  = ModifierType.Add;
            m_ModifierTime  = DateTime.Now;
        }
        
        public WOAttribute(float min, float max)
        {
            m_Val           = 0f;
            m_Min           = min;
            m_Max           = max;
            m_Modifier      = 0f;
            m_ModifierType  = ModifierType.Add;
            m_ModifierTime  = DateTime.Now;
        }

        public WOAttribute(float val, float min, float max)
        {
            m_Val           = val;
            m_Min           = min;
            m_Max           = max;
            m_Modifier      = 0f;
            m_ModifierType  = ModifierType.Add;
            m_ModifierTime  = DateTime.Now;
        }

        protected WOAttribute(float val, float min, float max, float modifier, ModifierType modifiertype, DateTime modifiertime)
        {
            m_Val           = val;
            m_Min           = min;
            m_Max           = max;
            m_Modifier      = modifier;
            m_ModifierType  = modifiertype;
            m_ModifierTime  = modifiertime;
        }

        #endregion


        #region Clone()

        public object Clone()
        {
            return new WOAttribute(m_Val, m_Min, m_Max, m_Modifier, m_ModifierType, m_ModifierTime);
        }

        #endregion

    }
}
