using System.Xml.Xsl;

class Program
{
    static void Main()
    {
        string originPathXslt = "../../../xml/catalogue.xslt";
        string originPathXml = "../../../xml/catalogue.xml";
        string destinationPath = "../../../xml/catalogue.html";

        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(originPathXslt);
        xslt.Transform(originPathXml, destinationPath);
    }
}
