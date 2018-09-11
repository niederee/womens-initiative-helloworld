using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {     
            // DataService ds = new DataService();
            // DatabaseCopyService databaseCopyService = new DatabaseCopyService(ds);
            // databaseCopyService.Copy();
            DogService service = new DogService();
            Dog snoop = service.CreateDog(1, "SnoopDogg");
            Dog pitbull = service.CreateDog(2, "PitBull");
            List<Dog> dogs = new List<Dog>();
            dogs.Add(snoop);
            dogs.Add(pitbull);
            dogs.Add(snoop);
            var people = service.getPeople();
            var dbDogs = service.GetDogs();
        }
    }
}
