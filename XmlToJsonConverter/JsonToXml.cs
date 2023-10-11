using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace XmlToJsonConverter
{
    public class JsonToXml: IJsonToXml
    {
        public XElement Convert(string jsonContent)
        {
            dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(jsonContent);
            XElement xmlData = new XElement("data");

            ConvertJsonToXml(jsonData, xmlData);

            return xmlData;
        }

        private void ConvertJsonToXml(JToken token, XElement parentElement)
        {
            if (token is JValue value)
            {
                parentElement.Value = value.ToString();
            }
            else if (token is JObject obj)
            {
                foreach (var property in obj.Properties())
                {
                    XElement childElement = new XElement(property.Name);
                    parentElement.Add(childElement);
                    ConvertJsonToXml(property.Value, childElement);
                }
            }
            else if (token is JArray array)
            {
                foreach (var item in array)
                {
                    XElement childElement = new XElement("item");
                    parentElement.Add(childElement);
                    ConvertJsonToXml(item, childElement);
                }
            }
        }
    }
}
