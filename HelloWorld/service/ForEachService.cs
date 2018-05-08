using System;
using System.Linq;

namespace HelloWorld
{
    public class ForEachService
    {
        public ForEachService(IDataService mock)
        {
            mockData = mock;
        }
        private IDataService mockData { get; set; }

        public int GetPeopleYoungerThan(DateTime date)
        {
            int countValue = 0;
            //Do Code Here
            foreach(Person person in mockData.People)
            {
                if(person.DateOfBirth >= date)
                {
                    countValue += 1;
                }
            }
            return countValue;
        }

     
    }

}