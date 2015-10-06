using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HattoriGame2.Core
{
    /// <summary>
    /// Статичный интрефейс глубокой сериализации объекта в XML
    /// </summary>
    /// <remarks>
    /// <para>Класс, к которому применяются статичный интерфейс, а также все вложенные структуры, должны быть помечены аттрибутом <c>Serializable</c>. Сериализуемые поля объекта также должны быть помечены аттрибутом <c>SerializeField</c></para>
    /// </remarks>
    /// <example>
    /// <para>Вот пример объявления класса, который можно сериализовать</para>
    /// <code>
    /// using UnityEngine;
    /// 
    /// [Serializable]
    /// public class SomeClass
    /// {
    ///     [SerializeField]
    ///     public int FirstField;
    ///     
    ///     [SerializeField]
    ///     public float SecondField;
    ///     
    ///     [SerializeField]
    ///     public OtherClass ThirdField;
    /// }
    /// 
    /// [Serializable]
    /// public class OtherClass
    /// {
    ///     [SerializeField]
    ///     public string SomeField;
    /// }
    /// </code>
    /// </example>
    public static class XMLSerialization<T>
    {
        public static string Serialize( T serializableObject ) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, IndentChars = "  ", NewLineChars = "\r\n", NewLineHandling = NewLineHandling.Replace });

            serializer.Serialize(xmlWriter, serializableObject);

            return stringWriter.ToString();
        }

        public static T Deserialize ( string xml )
        {
            StringReader stringReader = new StringReader(xml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(xmlReader);
        }

        public static bool TryDeserialize( string xml, out T deserializedObject )
        {
            StringReader stringReader = new StringReader(xml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            if( !serializer.CanDeserialize(xmlReader) )
            {
                deserializedObject = default(T);
                return false;
            }

            deserializedObject = (T)serializer.Deserialize(xmlReader);
            return true;
        }
    }
}
