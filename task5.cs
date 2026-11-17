using System;
using System.Xml;

class SaxLike
{
    static void Main()
    {
        using (XmlReader reader = XmlReader.Create("myroot.xml"))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                    PrintElement(reader);
            }
        }

        Console.Write("\nВведіть ID: ");
        string id = Console.ReadLine();
        bool found = false;

        using (XmlReader reader = XmlReader.Create("myroot.xml"))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element &&
                    reader.Name == "MyChild" &&
                    reader.GetAttribute("ID") == id)
                {
                    found = true;
                    Console.WriteLine("Знайдено:");
                    PrintElement(reader);

                    using (XmlReader sub = reader.ReadSubtree())
                    {
                        sub.Read(); 
                        while (sub.Read())
                            if (sub.NodeType == XmlNodeType.Element)
                                PrintElement(sub, 1);
                    }
                    break;
                }
            }
        }
        if (!found) Console.WriteLine("Елемент з таким ID не знайдено.");
        Console.ReadKey();
    }

    static void PrintElement(XmlReader r, int extra = 0)
    {
        string attrs = "";
        while (r.MoveToNextAttribute())
            attrs += $" {r.Name}=\"{r.Value}\"";
        r.MoveToElement();

        Console.WriteLine(new string(' ', (r.Depth + extra) * 2) + r.Name + attrs);
    }
}