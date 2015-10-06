using System;
using System.Collections.Generic;
using UnityEngine;
using HattoriGame2.Core.Components;

namespace HattoriGame2.Core
{
    public enum IdentificatorType : byte
    {
        Name = 0,
        Tag = 1,
        Layer = 2,
        GUID = 3,
        Component = 4       
    }

    public struct GameObjectIdentificator 
    {
        public string Identificator;
        public IdentificatorType Type;

        public List<GameObject> SearchFor()
        {
            var result = new List<GameObject>();

            return result;
        }

        public bool IsMatch( GameObject gameObject )
        {
            if(Type == IdentificatorType.Name)
            {
                return gameObject.name == Identificator;
            }
            else if(Type == IdentificatorType.Tag)
            {
                return gameObject.tag == Identificator;
            }
            else if(Type == IdentificatorType.Layer)
            {
                int identificatorAsInt = 0;
                if(int.TryParse(Identificator, out identificatorAsInt))
                {
                    return gameObject.layer == identificatorAsInt;
                }
                else
                {
                    return false;
                }
            }
            else if(Type == IdentificatorType.GUID)
            {
                /*var guidComponent = gameObject.GetComponent<>();

                if (guidComponent != null)
                {
                    var guid = new GUID(Identificator);
                    return guid == guidComponent.GUID;
                }
                else
                {
                    return false;
                }*/

                return false;

            }
            else if(Type == IdentificatorType.Component)
            {
                if(System.Type.GetType(Identificator) == null)
                {
                    Debug.LogErrorFormat("Game Object Identificator - Is Match - {0} doesn't exist", Identificator);
                    return false;
                }
                else
                {
                    return gameObject.GetComponent(Identificator) != null;
                }
            }
            else
            {
                Debug.LogWarningFormat("Game Object Identificator - Is Match - Behaviour for {0} is not defined", Type);
                return false;
            }
        }
    }
}