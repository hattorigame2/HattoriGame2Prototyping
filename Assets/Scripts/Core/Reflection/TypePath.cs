using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace HattoriGame2.Core.Reflection
{
    [Serializable]
    public class TypePath
    {
        public static Type ParseType(string typePath)
        {
            return string.IsNullOrEmpty(typePath) ? null : Type.GetType(typePath);
        }

        [SerializeField]
        private string path = typeof(object).AssemblyQualifiedName;

        public string Path
        {
            get
            {
                return path;
            }

            private set
            {
                path = value;
            }
        }
        
        public Type Type
        {
            get
            {
                return ParseType(Path);
            }

            set
            {
                Path = value.AssemblyQualifiedName;
            }
        } 
    }
}