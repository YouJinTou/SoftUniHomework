using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("../../../xml/catalogue.xml");

        string artistsQuery = "/albums/album/artist";

        XmlNodeList artistList = xml.SelectNodes(artistsQuery);

        var artistMap = new Dictionary<string, int>();

        foreach (XmlNode artist in artistList)
        {
            var name = artist.InnerText;
            if (!artistMap.ContainsKey(name))
            {
                artistMap.Add(name, 1);
            }
            else
            {
                artistMap[name]++;
            }
        }

        foreach (var artist in artistMap)
        {
            Console.WriteLine("{0} --> {1}", artist.Key, artist.Value);
        }
    }
}
