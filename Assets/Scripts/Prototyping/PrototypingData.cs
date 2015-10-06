using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

using HattoriGame2.Core;


namespace HattoriGame2.Prototyping
{
    /// <summary>
    /// Контейнер для хранения взаимосвязи между ключем, идентификатором объекта и полем компоненты, в виде индексов списков <c>Keys</c>, <c>Objects</c> и <c>Fields</c> класса <see cref="PrototypeData"/>.
    /// </summary>
    [Serializable]
    public struct PrototypeRelation
    {
        /// <summary>
        /// Индекс списка <c>Keys</c> класса <see cref="PrototypeData"/>
        /// </summary>
        [SerializeField]
        public int KeysIndex;

        /// <summary>
        /// Индекс списка <c>Objects</c> класса <see cref="PrototypeData"/>
        /// </summary>
        [SerializeField]
        public int ObjectsIndex;

        /// <summary>
        /// Индекс списка <c>Fields</c> класса <see cref="PrototypeData"/>
        /// </summary>
        [SerializeField]
        public int FieldsIndex;

        public PrototypeRelation( int ObjectsIndex, int KeysIndex, int FieldsIndex )
        {
            this.ObjectsIndex = ObjectsIndex;
            this.KeysIndex = KeysIndex;
            this.FieldsIndex = FieldsIndex;
        }
    }

    [Serializable]
    public class PrototypeData
    {
        /// <summary>
        /// Отображаемое имя прототипа
        /// </summary>
        [SerializeField]
        public string Name = "New Test";

        /// <summary>
        /// Детальное описание прототипа
        /// </summary>
        [SerializeField]
        public string Description = "";

        /// <summary>
        /// Доступен ли прототип для использования?
        /// </summary>
        [SerializeField]
        public bool IsEnabled = true;

        [SerializeField]
        private List<KeyValuePairPrimitive> keys;

        /// <summary>
        /// Список изменяемых параметров (ключей) прототипа
        /// </summary>
        /// <remarks>
        /// <para>Ключ прототипа - это контейнерный параметр прототипа, изменение хранимого значения которого ведут к измению параметров объектов в сцене. Кроме того он имеет упрощеное описание типа (как перечисление), что позволяет упростить выбор интерфейса для редактирования.</para> 
        /// </remarks>
        public List<KeyValuePairPrimitive> Keys
        {
            get
            {
                if (keys == null)
                {
                    keys = new List<KeyValuePairPrimitive>();
                }

                return keys;
            }

            private set
            {
                keys = value;
            }
        }

        [SerializeField]
        private List<GameObjectIdentificator> objects;

        /// <summary>
        /// Список идентификаторов игровых объектов, для которых применяются изменения.
        /// </summary>
        public List<GameObjectIdentificator> Objects
        {
            get
            {
                if (objects == null)
                {
                    objects = new List<GameObjectIdentificator>();
                }

                return objects;
            }

            private set
            {
                objects = value;
            }
        }

       /* [SerializeField]
        private List<RTTIVariablePath> fields;

        /// <summary>
        /// Список полей (включая компоненты), которые следует связать с изменяемыми параметрами.
        /// </summary>
        public List<RTTIVariablePath> Fields
        {
            get
            {
                if (fields == null)
                {
                    fields = new List<RTTIVariablePath>();
                }

                return fields;
            }

            private set
            {
                fields = value;
            }
        }
        */
        [SerializeField]
        private List<PrototypeRelation> relations;

        public List<PrototypeRelation> Relations
        {
            get
            {
                if (relations == null)
                {
                    relations = new List<PrototypeRelation>();
                }

                return relations;
            }

            private set
            {
                relations = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PrototypeData))
            {
                return false;
            }

            var other = obj as PrototypeData;

            return
                this.Name == other.Name &&
                this.Description == other.Description &&
                this.IsEnabled == other.IsEnabled &&
                this.Keys.SequenceEqual(other.Keys) &&
                this.Objects.SequenceEqual(other.Objects) &&
              //  this.Fields.SequenceEqual(other.Fields) &&
                this.Relations.SequenceEqual(other.Relations);
        }
    }

    [Serializable]
    public class PrototypingData
    {  
        [SerializeField]
        private List<PrototypeData> prototypes;

        public List<PrototypeData> Prototypes
        {
            get 
            { 
                if(prototypes == null)
                {
                    prototypes = new List<PrototypeData>();
                }

                return prototypes; 
            }

            private set 
            { 
                prototypes = value; 
            }
        }

        public override bool Equals(object obj)
        {
            if( obj == null || !(obj is PrototypingData))
            {
                return false;
            }

            var other = obj as PrototypingData;

            return this.Prototypes.SequenceEqual(other.Prototypes);
        }
    }
}