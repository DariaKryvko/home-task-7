using System;
using System.Xml;

class Program
{
    static string path = "myroot.xml";

    static void Main()
    {
        CreateDocument();

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        PrintNode(doc.DocumentElement, 0);

        Console.Write("\nВведіть ID: ");
        FindById(doc, Console.ReadLine());
        Console.ReadKey();
    }

    static void CreateDocument()
    {
        XmlDocument doc = new XmlDocument();
        doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));

        XmlElement root = doc.CreateElement("MyRoot");
        doc.AppendChild(root);

        for (int i = 1; i <= 3; i++)
        {
            XmlElement child = doc.CreateElement("MyChild");
            child.SetAttribute("ID", i.ToString());

            for (int j = 1; j <= 2; j++)
            {
                XmlElement gc = doc.CreateElement("MyGrandChild");
                gc.SetAttribute("NAME", i + " " + j);
                child.AppendChild(gc);
            }
            root.AppendChild(child);
        }
        doc.Save(path);
    }

    static void PrintNode(XmlNode node, int level)
    {
        if (node.NodeType != XmlNodeType.Element) return;

        string attrs = "";
        foreach (XmlAttribute a in node.Attributes)
            attrs += $" {a.Name}=\"{a.Value}\"";

        Console.WriteLine(new string(' ', level * 2) + node.Name + attrs);

        foreach (XmlNode child in node.ChildNodes)
            PrintNode(child, level + 1);
    }

    static void FindById(XmlDocument doc, string id)
    {
        foreach (XmlNode child in doc.SelectNodes("/MyRoot/MyChild"))
        {
            if (child.Attributes["ID"].Value == id)
            {
                Console.WriteLine("Знайдено:");
                PrintNode(child, 0);
                return;
            }
        }
        Console.WriteLine("Елемент з таким ID не знайдено.");
    }
}