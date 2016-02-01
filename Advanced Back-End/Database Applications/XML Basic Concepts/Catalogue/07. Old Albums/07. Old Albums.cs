using System;
using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("../../../xml/catalogue.xml");

        string oldAlbumsQuery = "/albums/album";

        XmlNodeList albums = xml.SelectNodes(oldAlbumsQuery);

       
        foreach (XmlNode album in albums)
        {
            bool flag = false;
            string name = "";
            decimal price = 0;
            foreach (XmlNode element in album)
            {                
                if (element.Name == "name")
                {
                    name = element.InnerText;
                }
                if (element.Name == "year")
                {
                    var year = int.Parse(element.InnerText);

                    if (year <= 2012)
                    {
                        flag = true;                        
                    }
                }
                if (element.Name == "price")
                {
                    price = decimal.Parse(element.InnerText);

                    if (flag)
                    {
                        flag = false;
                        Console.WriteLine("{0}, ${1}", name, price);                        
                    }
                }
            }
        }

    }
}