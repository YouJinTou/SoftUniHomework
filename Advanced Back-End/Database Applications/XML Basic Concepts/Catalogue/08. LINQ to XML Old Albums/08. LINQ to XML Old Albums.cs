using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument xml = XDocument.Load("../../../xml/catalogue.xml");

        var albums = xml.Descendants("album")
            .Where(d => int.Parse(d.Element("year").Value) <= 2012)
            .Select(a => new
            {
                Title = a.Element("name").Value,
                Price = a.Element("price").Value
            });

        foreach (var a in albums)
        {
            Console.WriteLine("{0}, ${1}", a.Title, a.Price);
        }

    }
}