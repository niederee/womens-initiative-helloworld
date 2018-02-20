using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            ConditionalService conditionalService = new ConditionalService();
            bool test = conditionalService.ConditionalBool(false);
            bool test2 = conditionalService.ConditionalString("Hello World");

        }
    }
}
