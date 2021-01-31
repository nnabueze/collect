using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ErcasCollect.Helpers
{
    public class JsonXmlObjectConverter
    {
        public static string SerializeObject<T>(T dataObject)
        {
            if (dataObject == null)
            {
                return string.Empty;
            }
            try
            {
                using (StringWriter stringWriter = new System.IO.StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stringWriter, dataObject);
                    string x = stringWriter.ToString();
                    string y = x.Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                    string z = y.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                    return z;
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static T DeserializeObject<T>(string xml)
             where T : new()
        {
            if (string.IsNullOrEmpty(xml))
            {
                return new T();
            }
            try
            {
                using (var stringReader = new StringReader(xml))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(stringReader);
                }
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }

        public static T XmlToObject<T>(string xmlString)
        {
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlString);

            if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)

                doc.RemoveChild(doc.FirstChild);


            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);

            var request = Deserialize<T>(json);

            return request;
        }
    }       
}
