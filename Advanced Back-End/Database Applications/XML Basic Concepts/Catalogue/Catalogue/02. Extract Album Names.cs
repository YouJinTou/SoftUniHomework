using System;
using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("../../../xml/catalogue.xml");

        XmlNode root = xml.DocumentElement;

        foreach (XmlNode child in root.ChildNodes)
        {
            if (child.ChildNodes.Count != 0)
            {
                foreach (XmlNode node in child.ChildNodes)
                {
                    if (node.Name == "name")
                    {
                        Console.WriteLine("Album name: " + node.InnerText);
                    }
                }
            }
        }
    }
}