using System.Xml.Linq;

namespace XmlToJsonConverter
{
    public interface IJsonToXml
    {
        public XElement Convert(string jsonContent);
    }
}
