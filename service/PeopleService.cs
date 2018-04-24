using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    public class PeopleService 
    {
        private List<Person> _people;
        public PeopleService(List<Person> people)
        {
            _people = people;
        }
        public PeopleService(IDataService dataService)
        {
            
            _people = dataService.People;
        }

        

        public Person GetPerson(string fullName)
        {
            string[] name = fullName.Split(" ");
            return GetPerson(name[0], name[1]);
        }

        public Person GetPerson(string firstName, string lastName)
        {
            foreach(Person p in _people)
            {
                if(p.FirstName == firstName && p.LastName == lastName )
                {
                    return p; 
                }
            }

            return null;
        }

        public Person GetPerson(int personId)
        {
            return _people.Where(a => a.PersonId == personId).DefaultIfEmpty(null).First();
        }

        public Person GetPerson(ShoePerson shoePerson)
        {
            return GetPerson(shoePerson.PersonId);
        }
    }
}