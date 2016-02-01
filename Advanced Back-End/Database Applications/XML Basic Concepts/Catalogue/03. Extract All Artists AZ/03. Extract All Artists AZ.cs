using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
        SortedSet<string> artists = new SortedSet<string>();
        XmlDocument xml = new XmlDocument();
        xml.Load("../../../xml/catalogue.xml");

        XmlNode root = xml.DocumentElement;

        foreach (XmlNode child in root.ChildNodes)
        {
            if (child.ChildNodes.Count != 0)
            {
                foreach (XmlNode node in child.ChildNodes)
                {
                    if (node.Name == "artist")
                    {
                        artists.Add(node.InnerText);
                    }
                }
            }
        }

        foreach (var artist in artists)
        {
            Console.WriteLine("Artist: " + artist);
        }
    }
}
