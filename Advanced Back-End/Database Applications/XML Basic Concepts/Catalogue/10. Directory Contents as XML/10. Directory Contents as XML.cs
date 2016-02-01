using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

class Program
{
    static XElement root;

    static void Main()
    {
        string path = "../../../xml/directory-tree-xdocument.xml";

        string rootPath = "C:\\Program Files\\Microsoft Office";
        DirectoryInfo rootDir = new DirectoryInfo(rootPath);
                
        root = new XElement("root");
        XDocument xml = new XDocument(root);
        TraverseDir(rootDir);
        xml.Save(path);
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
            AddElementToXml(root, files);

            dirs = root.GetDirectories();

            foreach (var dir in dirs)
            {
                TraverseDir(dir);
            }
        }
    }

    static void AddElementToXml(DirectoryInfo rootDir, FileInfo[] files)
    {
        XElement nextDir = new XElement("dir");
        nextDir.Add(new XAttribute("name", rootDir.FullName));
        root.AddFirst(nextDir);        

        foreach (FileInfo file in files)
        {
            XElement nextFile = new XElement("file");
            nextFile.Add(new XAttribute("name", file.Name));
            nextDir.AddFirst(nextFile);
        }
    }
}
