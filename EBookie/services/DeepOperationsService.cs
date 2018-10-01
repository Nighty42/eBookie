using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EBookie.services
{
    class DeepOperationsService
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static bool CompareComplexObjects<T>(T object1, T object2)
        {
            Type type = typeof(T);

            if (object1 == null || object2 == null)
            {
                return false;
            }

            XmlSerializer serializer = new XmlSerializer(type);
            StringWriter stringWriter_o1 = new StringWriter();
            StringWriter stringWriter_o2 = new StringWriter();

            serializer.Serialize(stringWriter_o1, object1);
            serializer.Serialize(stringWriter_o2, object2);

            if (stringWriter_o1.ToString().Equals(stringWriter_o2.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
