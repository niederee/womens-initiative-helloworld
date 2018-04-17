using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorld
{
    public class ShoeColorLoopService
    {
        private IDataService _data;
        public ShoeColorLoopService(IDataService data)
        {
            _data = data;
        }

        public List<Person> PeopleWithShoesOfColor(Color color)
        {
            List<Person> people = new List<Person>();
            foreach(var shoe in _data.Shoes)
            {
                if(shoe.Color == color)
                {
                    ShoePerson shoePerson = getShoePerson(shoe);
                    people.Add(getPerson(shoePerson));
                }
            }

            return people;
        } 

        private Person getPerson(ShoePerson shoePerson)
        {
            return _data.People.Where(a => a.PersonId == shoePerson.PersonId).DefaultIfEmpty(null).FirstOrDefault();
        }


        private ShoePerson getShoePerson(Shoe shoe)
        {
            for(int i =0; i < _data.ShoePersons.Count; i++)
            {
                ShoePerson shoePerson = _data.ShoePersons[i];
                if(shoePerson.PairId == shoe.PairId)
                {
                    return shoePerson; 
                }
            }

            return null;
        }

        public int ForEachShoeCount(Color color)
        {
            int ii = 0;
            foreach(var shoe in _data.Shoes)
            {
                if (shoe.Color == color)
                {
                    ii += 1;
                }
            }
            return ii;

        }


        public int ForShoeCount(Color color)
        {
            int ii = 0;
            for (int i = 0; i < _data.Shoes.Count; i++)
            {
                var shoe = _data.Shoes[i];
                if (shoe.Color == color)
                {
                    ii += 1;
                }
            }
            return ii;

        }

        public int LinqShoeCount(Color color)
        {
            return _data.Shoes.Where(a => a.Color == color).Count();
        }

    }

}