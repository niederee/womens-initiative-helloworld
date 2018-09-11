using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NPoco;

namespace HelloWorld
{
    public class DogService
    {
        private NpgsqlConnection _FootLooseConnection;
        private DatabaseFactory _databaseFactory;

        public DogService()
        {
            IConfiguration config = ConfigService.GetConfig();
            string connectionString = config["ConnectionStrings:FootLooseConnection"];
            _FootLooseConnection = new NpgsqlConnection(connectionString);
            _FootLooseConnection.OpenConnection();
            DatabaseFactoryConfigOptions options = new DatabaseFactoryConfigOptions();
            
            options.Database = () => new Database(_FootLooseConnection);
            _databaseFactory = new DatabaseFactory(options);
            
        }

        internal List<Person> getPeople()
        {
     return _databaseFactory.GetDatabase().Fetch<Person>("Select * from public.Person");
        }
        public List<Dog> GetDogs()
        {
            _FootLooseConnection.OpenConnection();
            return _databaseFactory.GetDatabase().Fetch<Dog>("Select * from public.dog");
        }

        public Dog CreateDog(int ownerId, string breed)
        {
            return new Dog()
            {
                Breed = breed,
                Owner_Id = ownerId
            };
        }
    }
}