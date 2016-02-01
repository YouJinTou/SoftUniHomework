using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
        var artists = new Dictionary<string, int>();
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
                        var name = node.InnerText;

                        if (!artists.ContainsKey(name))
                        {
                            artists.Add(name, 1);
                        }
                        else
                        {
                            artists[name]++;
                        }                        
                    }
                }
            }
        }

        foreach (var artist in artists)
        {
            Console.WriteLine("{0} --> {1}", artist.Key, artist.Value);
        }
    }
}
