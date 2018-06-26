using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class UnitTest1
    {
        MockDataService mk = new MockDataService();



        [TestMethod]
        public void PersonNameTest()
        {

            ShoeColorLoopService loopService = new ShoeColorLoopService(mk);
            Color searchColor = Color.FromName("ff008000");
            var people = loopService.PeopleWithShoesOfColor(searchColor);

            PeopleService peopleService = new PeopleService(mk);
            Person person = peopleService.GetPerson("Bruce Hammes");
            person = peopleService.GetPerson(94);


            var shoes = peopleService.GetShoes(person);

            Assert.AreEqual(person.FirstName, "Bruce");
            Assert.AreEqual(person.LastName, "Hammes");
        }

        [TestMethod]
        public void FailureDemoTest()
        {
            HelloWorld.Program program = new HelloWorld.Program();

        }

        [TestMethod]
        public void MostOccuringColor()
        {
            HelloWorld.ShoeService service = new HelloWorld.ShoeService();
            var data = service.GetMostOccuringColor(mk);
            Assert.IsTrue(data.Value == 10);
        }


        [TestMethod]
        public void FindPeople()
        {
            HelloWorld.PeopleService service = new HelloWorld.PeopleService(mk);
            var ben = service.GetPeople("Ben");
            Assert.IsTrue(ben.Count == 1);
        }


    }
}
