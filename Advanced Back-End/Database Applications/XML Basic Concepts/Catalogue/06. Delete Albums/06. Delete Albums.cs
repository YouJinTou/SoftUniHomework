using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xml = new XmlDocument();        
        xml.Load("../../../xml/catalogue.xml");
        XmlNode root = xml.DocumentElement;

        foreach (XmlNode node in root.ChildNodes)
        {
            foreach (XmlNode element in node)
            {
                if (element.Name == "price")
                {
                    decimal price = decimal.Parse(element.InnerText);

                    if (price > 20)
                    {
                        root.RemoveChild(node);
                    }
                }
            }
        }

        xml.Save("../../../xml/cheap-albums-catalogue.xml");
    }
}