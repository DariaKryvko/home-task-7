using System;
using System.Linq;
using System.Xml.Linq;

class LinqToXml
{
    static void Main()
    {
        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("MyRoot",
                Enumerable.Range(1, 3).Select(i =>
                    new XElement("MyChild",
                        new XAttribute("ID", i),
                        Enumerable.Range(1, 2).Select(j =>
                            new XElement("MyGrandChild",
                                new XAttribute("NAME", $"{i} {j}")))))));
        doc.Save("myroot_linq.xml");

        PrintElement(doc.Root, 0);

        Console.Write("\nВведіть ID: ");
        string id = Console.ReadLine();

        var found = doc.Root.Elements("MyChild")
                            .FirstOrDefault(c => (string)c.Attribute("ID") == id);

        if (found != null)
        {
            Console.WriteLine("Знайдено:");
            PrintElement(found, 0);
        }
        else
            Console.WriteLine("Елемент з таким ID не знайдено.");

        Console.ReadKey();
    }

    static void PrintElement(XElement e, int level)
    {
        string attrs = string.Concat(e.Attributes()
                          .Select(a => $" {a.Name}=\"{a.Value}\""));
        Console.WriteLine(new string(' ', level * 2) + e.Name + attrs);

        foreach (var child in e.Elements())
            PrintElement(child, level + 1);
    }
}