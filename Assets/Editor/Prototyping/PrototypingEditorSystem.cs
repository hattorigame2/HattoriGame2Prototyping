using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using HattoriGame2.Core;

namespace HattoriGame2.Prototyping
{
    public static class PrototypingEditorSystem 
    {
        // Strings
        private const string filePath = "/Resources/Prototyping/Defaults/DefaultPrototypingData.xml";

        private static PrototypingData assetMemento;
        public static PrototypingData AssetMemento
        {
            get
            {
                if (assetMemento == null)
                {
                    assetMemento = new PrototypingData();
                }

                return assetMemento;
            }

            private set
            {
                assetMemento = value;
            }
        }

        private static PrototypingData asset;
        public static PrototypingData Asset
        {
            get
            {
                if (asset == null)
                {
                    asset = new PrototypingData();
                    Load();
                }

                return asset;
            }

            private set 
            {
                asset = value;
            }
        }
        
        public static bool IsDirty
        {
            get { return AssetMemento.Equals(Asset); }
        }

        public static void Save()
        {
            Directory.CreateDirectory(Application.dataPath + Path.GetDirectoryName(filePath));
            File.WriteAllText(Application.dataPath + filePath, XMLSerialization<PrototypingData>.Serialize(Asset));

            AssetMemento = Asset.DeepClone<PrototypingData>();

            AssetDatabase.Refresh();
        }

        public static bool Load()
        {
            var result = File.Exists(Application.dataPath + filePath) && 
                XMLSerialization<PrototypingData>.TryDeserialize(File.ReadAllText(Application.dataPath + filePath), out asset);

            if (result)
            {
                AssetMemento = Asset.DeepClone<PrototypingData>();
            }

            return result;
        }
    }
}
