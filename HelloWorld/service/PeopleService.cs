using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    public class PeopleService 
    {
        private List<Person> _people;
        private List<Shoe> _shoes;
        private List<ShoePerson> _shoePersons;

        public PeopleService(IDataService dataService)
        {
            
            _people = dataService.People;
            _shoes = dataService.Shoes;
            _shoePersons = dataService.ShoePersons;
        }

        public List<Shoe> GetShoes(Person person)
        {
            List<Shoe> tempShoes = null;
            foreach(ShoePerson sp in _shoePersons)
            {
                if(sp.PersonId == person.PersonId)
                {
                    if(tempShoes == null){ tempShoes = new List<Shoe>();}
                    tempShoes.Add(GetShoes(sp));
                }
            }


            return tempShoes;

        }

        private Shoe GetShoes(ShoePerson shoePerson)
        {
              return _shoes.Where(a => a.PairId == shoePerson.PairId).DefaultIfEmpty(null).FirstOrDefault();
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

        public List<Person> GetPeople(string firstName)
        {
            List<Person> people = new List<Person>();
            foreach(Person peep in _people)
            {
                if(peep.FirstName.ToUpper() == firstName.ToUpper())
                {
                    people.Add(peep);
                }
            }
            return people;
        }
    }
}