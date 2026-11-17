using System;
using System.Xml.Xsl;

class Program
{
    static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("myroot.xsl");
        xslt.Transform("myroot.xml", "myroot.html");
        Console.WriteLine("Готово: myroot.html");
        Console.ReadKey();
    }
}