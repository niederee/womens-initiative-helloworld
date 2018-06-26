using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NPoco;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public class DataService: IDataService
    {
        private DatabaseFactory _databaseFactory;

        public DataService()
        {           
            IConfiguration config = ConfigService.GetConfig();
            string connectionString = config["ConnectionStrings:FootLooseConnection"];
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.OpenConnection();
            DatabaseFactoryConfigOptions options = new DatabaseFactoryConfigOptions();

            options.Database = () => new Database(connection);
            _databaseFactory = new DatabaseFactory(options);
           // People = getPeople();

        }

        public List<Account> Accounts => throw new NotImplementedException();

        internal List<Person> getPeople()
        {
     return _databaseFactory.GetDatabase().Fetch<Person>("Select * from public.Person");
        }

public List<Person> People { get; set; }
        
        
        public List<AccountPerson> AccountPersons => throw new NotImplementedException();

        public List<ShoePerson> ShoePersons => throw new NotImplementedException();

        public List<Shoe> Shoes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


   
}