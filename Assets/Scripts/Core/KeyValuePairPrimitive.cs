using UnityEngine;
using System;

namespace HattoriGame2.Core
{
    [Serializable]
    public struct KeyValuePairPrimitive
    {
        public enum ValueType : byte
        {
            Bool = 0,
            Int = 1,
            Float = 2,
            String = 3,
            Color = 4
        }

        public string Key;
        public string Value;
        public ValueType Type;

        public override bool Equals(object obj)
        {
            if (!(obj is KeyValuePairPrimitive))
            {
                return false;
            }

            var other = (KeyValuePairPrimitive)obj;

            return 
                other.Key == this.Key &&  
                other.Type == this.Type && 
                other.Value == this.Value;
        }
    }
}