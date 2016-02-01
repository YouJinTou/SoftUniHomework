using System;
using System.Text;
using System.IO;
using System.Xml;

class Program
{
    static XmlTextWriter xtw;

    static void Main()
    {
        string path = "../../../xml/directory-tree-xmlwriter.xml";
        Encoding encoding = Encoding.GetEncoding("utf-8");   

        string rootPath = "C:\\Program Files\\Microsoft Office";
        DirectoryInfo root = new DirectoryInfo(rootPath);
        
        using (xtw = new XmlTextWriter(path, encoding))
        {
            xtw.WriteStartDocument();
            xtw.WriteStartElement("root-path");
            xtw.WriteAttributeString("dir", rootPath);

            TraverseDir(root);

            xtw.WriteEndElement();
            xtw.WriteEndDocument();
        }       
    }

    static void TraverseDir(DirectoryInfo root)
    {
        DirectoryInfo[] dirs = null;
        FileInfo[] files = null;

        try
        {
            files = root.GetFiles("*.*");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthorized access.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found.");
        }

        if (files != null)
        {
            xtw.Formatting = Formatting.Indented;
            xtw.IndentChar = '\t';
            xtw.Indentation = 1;

            AddElementToXml(root, files);

            dirs = root.GetDirectories();

            foreach (var dir in dirs)
            {
                TraverseDir(dir);
            }
        }
    }

    static void AddElementToXml(DirectoryInfo root, FileInfo[] files)
    {
        xtw.WriteStartElement("dir");
        xtw.WriteAttributeString("name", root.FullName);

        foreach (FileInfo file in files)
        {
            xtw.WriteStartElement("file");
            xtw.WriteAttributeString("name", file.Name);
            xtw.WriteEndElement();
        }

        xtw.WriteEndElement();
    }
}
