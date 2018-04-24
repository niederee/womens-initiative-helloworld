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
            var people = loopService.PeopleWithShoesOfColor(searchColor);

            PeopleService peopleService = new PeopleService(mk);
            Person person = peopleService.GetPerson("Bruce Hammes");
            person = peopleService.GetPerson(94);

        }
    }
}
