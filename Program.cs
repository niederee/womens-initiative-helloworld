using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            String baseBath = System.AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileToMake = new FileInfo(Path.Combine(baseBath,"data\\","myFile.txt"));
            FileFactory factory = new FileFactory();
            factory.MakeFile(fileToMake);
            Console.WriteLine("Hello World!");
        }
    }
}
