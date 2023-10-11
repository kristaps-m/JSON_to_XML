using System.Xml.Linq;
using XmlToJsonConverter;

namespace JsonToXmlTests
{
    public class ConvertTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void JsonToXmlConvert_JsonDataPassedInConvertMethod_ShouldReturnTrue_Case1()
        {
            // Arrange
            IJsonToXml jsonToXmlConverter = new JsonToXml();
            string jsonContent = "{ \"Name\": \"John\", \"Age\": 30 }"; 
            string expectedXmlContent = "<data><Name>John</Name><Age>30</Age></data>"; 

            // Act
            var xmlData = jsonToXmlConverter.Convert(jsonContent);

            // Assert
            Assert.IsTrue(XNode.DeepEquals(XElement.Parse(expectedXmlContent), xmlData));
        }

        [Test]
        public void JsonToXmlConvert_JsonDataPassedInConvertMethod_ShouldReturnTrue_Case2()
        {
            // Arrange
            IJsonToXml jsonToXmlConverter = new JsonToXml();
            string jsonContent =
                @"{
                    ""person"": {
                        ""name"": ""Alice"",
                        ""age"": 25,
                        ""address"": {
                            ""street"": ""123 Main St"",
                            ""city"": ""Anytown"",
                            ""zipcode"": ""12345""
                        }
                    }
                }";

            string expectedXmlContent =
                @"<data>
                    <person>
                        <name>Alice</name>
                        <age>25</age>
                        <address>
                            <street>123 Main St</street>
                            <city>Anytown</city>
                            <zipcode>12345</zipcode>
                        </address>
                    </person>
                </data>";


            // Act
            var xmlData = jsonToXmlConverter.Convert(jsonContent);

            // Option 2: Check for Valid XML
            XElement expectedXml = XElement.Parse(expectedXmlContent);
            Assert.IsTrue(XNode.DeepEquals(expectedXml, xmlData));
        }

        [Test]
        public void JsonToXmlConvert_JsonDataPassedInConvertMethod_ShouldReturnTrue_Case3()
        {
            // Arrange
            IJsonToXml jsonToXmlConverter = new JsonToXml();
            string jsonContent =
                @"{
                    ""book"": {
                        ""title"": ""The Catcher in the Rye"",
                        ""author"": ""J.D. Salinger"",
                        ""published_year"": 1951,
                        ""genre"": ""Fiction""
                    }
                }";

            string expectedXmlContent =
                @"<data>
                    <book>
                        <title>The Catcher in the Rye</title>
                        <author>J.D. Salinger</author>
                        <published_year>1951</published_year>
                        <genre>Fiction</genre>
                    </book>
                </data>";

            // Act
            var xmlData = jsonToXmlConverter.Convert(jsonContent);

            // Option 2: Check for Valid XML
            XElement expectedXml = XElement.Parse(expectedXmlContent);
            Assert.IsTrue(XNode.DeepEquals(expectedXml, xmlData));
        }

        [Test]
        public void JsonToXmlConvert_JsonDataPassedInConvertMethod_ShouldReturnTrue_Case4()
        {
            // Arrange
            IJsonToXml jsonToXmlConverter = new JsonToXml();
            string jsonContent =
                @"{
                    ""order"": {
                        ""status"": ""packed"",
                        ""total_grams"": 500,
                        ""client_id"": ""1111CT11111"",
                        ""items"": [
                            {
                                ""product_id"": ""334123QW56TY5"",
                                ""quantity"": 4,
                                ""sku"": ""SKU-1""
                            },
                            {
                                ""product_id"": ""5425PT1734220"",
                                ""quantity"": 1,
                                ""sku"": ""SKU-6""
                            }
                        ]
                    }
                }";

            string expectedXmlContent =
                @"<data>
                    <order>
                        <status>packed</status>
                        <total_grams>500</total_grams>
                        <client_id>1111CT11111</client_id>
                        <items>
                            <item>
                                <product_id>334123QW56TY5</product_id>
                                <quantity>4</quantity>
                                <sku>SKU-1</sku>
                            </item>
                            <item>
                                <product_id>5425PT1734220</product_id>
                                <quantity>1</quantity>
                                <sku>SKU-6</sku>
                            </item>
                        </items>
                    </order>
                </data>";

            // Act
            XElement xmlData = jsonToXmlConverter.Convert(jsonContent);

            // Assert
            Assert.IsTrue(XNode.DeepEquals(XElement.Parse(expectedXmlContent), xmlData));
        }
    }
}