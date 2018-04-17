using System;
using System.IO;
using System.Drawing;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {     

            MockDataService mk = new MockDataService();
            ShoeColorLoopService loopService = new ShoeColorLoopService(mk);
            Color searchColor = Color.FromName("ff008000");
            int foreachCount = loopService.ForEachShoeCount(searchColor);
            int forCount = loopService.ForShoeCount(searchColor);
            int linqCount = loopService.LinqShoeCount(searchColor);
            var people = loopService.PeopleWithShoesOfColor(searchColor);

        }
    }
}
