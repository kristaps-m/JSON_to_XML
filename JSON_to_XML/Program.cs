using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
string MAIN_PATH = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net6.0", "");

Console.WriteLine("Welcome to 'from json to xml file converter and saver'");

// Read JSON data from file 
string jsonFileName = "A_JSON_dati.json";
string jsonFilePath = Path.Combine(MAIN_PATH, "json_files", jsonFileName);
string jsonContent = File.ReadAllText(jsonFilePath);

// Deserialize JSON to dynamic object
dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(jsonContent);

Console.WriteLine(jsonData);

// Convert dynamic object to XML
XElement xmlData = JsonToXml(jsonData);
Console.WriteLine(xmlData);

// Save XML data to a file
string xmlFileName = "B_XML_dati.xml";
string xmlFilePath = Path.Combine(MAIN_PATH, "xml_files", xmlFileName);
xmlData.Save(xmlFilePath);

Console.WriteLine("JSON data has been converted and saved to an XML file.");

static XElement JsonToXml(dynamic jsonData)
{
    XElement xmlData = new XElement("data");

    ConvertJsonToXml(jsonData, xmlData);

    return xmlData;
}

static void ConvertJsonToXml(JToken token, XElement parentElement)
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

