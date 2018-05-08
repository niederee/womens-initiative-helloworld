using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;

namespace HelloWorld.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PersonNameTest()
        {
            MockDataService mk = new MockDataService();
            ShoeColorLoopService loopService = new ShoeColorLoopService(mk);
            Color searchColor = Color.FromName("ff008000");
            var people = loopService.PeopleWithShoesOfColor(searchColor);

            PeopleService peopleService = new PeopleService(mk);
            Person person = peopleService.GetPerson("Bruce Hammes");
            person = peopleService.GetPerson(94);

            var shoes = peopleService.GetShoes(person);
            Assert.AreEqual(person.FirstName,"Bruce");
            Assert.AreEqual(person.LastName,"Hammes");
        }
    }
}
