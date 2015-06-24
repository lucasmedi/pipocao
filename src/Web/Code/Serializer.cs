using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Web.Code
{
    public static class Serializer
    {
        private static XmlSerializerNamespaces _serializerNamespaces;

        static Serializer()
        {
            _serializerNamespaces = new XmlSerializerNamespaces();
            _serializerNamespaces.Add("", "");
        }

        /// <summary>
        /// Serialize an object to an XMLDocument using the built-in xml serializer.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <param name="alternateNamespaces"> </param>
        /// <returns>XmlDocument containing the serialized data</returns>
        public static XmlDocument Serialize<T>(T obj, XmlSerializerNamespaces alternateNamespaces = null)
        {
            var s = new XmlSerializer(obj.GetType());

            using (var stream = new MemoryStream())
            using (var sw = new StreamWriter(stream))
            {
                s.Serialize(sw, obj, alternateNamespaces ?? _serializerNamespaces);
                stream.Position = 0;
                stream.Flush();

                var doc = new XmlDocument();
                doc.Load(stream);

                return doc;
            }
        }

        /// <summary>
        /// Deserialize the XmlDocument given, into an object of type T.
        /// T must have a parameterless constructor.
        /// </summary>
        /// <typeparam name="T">Type of the object to deserialize</typeparam>
        /// <param name="doc">The document to deserialize</param>
        /// <returns>A fresh object containing the information from the document</returns>
        public static T Deserialize<T>(XmlDocument doc)
        {
            // Use awesomeness of Activator
            var tmp = Activator.CreateInstance<T>();
            var serializer = new XmlSerializer(tmp.GetType());
            T objectToSerialize = (T)serializer.Deserialize(new XmlNodeReader(doc.DocumentElement));

            return objectToSerialize;
        }
    }
}