using System.Xml.Linq;
using XmlToJsonConverter;

string MAIN_PATH = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net6.0", "");
IJsonToXml jsonToXmlConverter = new JsonToXml();


Console.WriteLine("Welcome to 'from json to xml file converter and saver'");

// Read JSON data from file 
string jsonFileName = "A_JSON_dati.json";
string jsonFilePath = Path.Combine(MAIN_PATH, "json_files", jsonFileName);
string jsonContent = File.ReadAllText(jsonFilePath);

// Convert dynamic object to XML
XElement xmlData = jsonToXmlConverter.Convert(jsonContent); 
Console.WriteLine(xmlData);

// Save XML data to a file
string xmlFileName = "B_XML_dati.xml";
string xmlFilePath = Path.Combine(MAIN_PATH, "xml_files", xmlFileName);
xmlData.Save(xmlFilePath);

Console.WriteLine("JSON data has been converted and saved to an XML file.");
