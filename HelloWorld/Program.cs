using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {     
            DataService ds = new DataService();
            DatabaseCopyService databaseCopyService = new DatabaseCopyService(ds);
            databaseCopyService.Copy();
            Console.WriteLine("Hello World");

        }
    }
}
