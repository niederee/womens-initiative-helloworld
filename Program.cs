using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {            
            ShoeService svc = new ShoeService();
            MockDataService mk = new MockDataService();
        }
    }
}
