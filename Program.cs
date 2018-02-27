using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            ForLoopService forLoopService = new ForLoopService();
            var results = forLoopService.CountNumbers(50);
        }
    }
}
