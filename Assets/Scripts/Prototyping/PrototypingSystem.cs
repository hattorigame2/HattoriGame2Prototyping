using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace HattoriGame2.Prototyping
{
    public static class PrototypingSystem 
    {
        private const string resourcePath = "PrototypingData";

        private static PrototypingData asset;
        public static PrototypingData Asset
        {
            get
            {
                if (asset == null)
                {
                    asset = Load();
                }

                return asset;
            }
        }

        public static PrototypingData Load( string filePath = resourcePath )
        {
            return null;
        }
    }
}