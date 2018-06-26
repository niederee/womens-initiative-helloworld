using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace HelloWorld
{
    public class DatabaseCopyService: IDisposable
    {
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        private IDataService _dataService;
        public DatabaseCopyService(IDataService dataService)
        {
             _config = ConfigService.GetConfig();
            _connection = new NpgsqlConnection(_config["ConnectionStrings:FootLooseConnection"]);
             _dataService = dataService;
        }

        private void createTables()
        {
             Sql.CreatePersonTable.ExecuteCommands(_connection);
             Sql.CreateShoeTable.ExecuteCommands(_connection);
             Sql.CreateShoePersonTable.ExecuteCommands(_connection);
        }

        private void changeOwnership()
        {
            Sql.TableOwnership.ExecuteCommands(_connection);
        }
        
        public void Copy()
        {
            createTables();
            changeOwnership();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        private static class Sql
        {
            public static string TableOwnership =@"ALTER TABLE public.person OWNER to ""Kevin.Bacon"";
            ALTER TABLE public.shoe OWNER to ""Kevin.Bacon"";
            ALTER TABLE public.shoeperson OWNER to ""Kevin.Bacon"";";
            public static string TablePermissions =@"
GRANT ALL ON TABLE public.person TO ""Kevin.Bacon"";
GRANT ALL ON TABLE public.person TO postgres;
GRANT ALL ON TABLE public.shoe TO ""Kevin.Bacon"";
GRANT ALL ON TABLE public.shoe TO postgres;
GRANT ALL ON TABLE public.shoeperson TO ""Kevin.Bacon"";
GRANT ALL ON TABLE public.shoeperson TO postgres;
";


        public static string CreateShoePersonTable = @"Drop TABLE IF EXISTS public.shoeperson;
        create table public.shoePerson
        (
            ShoePersonId integer not null,
            pairid integer not null,
            personid integer not null,
            PRIMARY KEY (""shoepersonid"")
            )
            WITH (
    OIDS = FALSE
);";

            public static string CreateShoeTable = @"DROP TABLE IF EXISTS public.shoe;
            CREATE TABLE public.shoe
(
    PairId integer NOT NULL,
    Color varchar(20),
    ""size"" numeric(4,1) not null,
    shoeorientation varchar(100),
    brand varchar(255),
    shoestyle varchar(100),
    gender varchar(100),
    PRIMARY KEY (""pairid"")
)
WITH (
    OIDS = FALSE
);";
            public static string CreatePersonTable =@"DROP TABLE IF EXISTS public.person;
            CREATE TABLE public.person
(
    personid integer NOT NULL,
    firstname character varying(255) COLLATE pg_catalog.""default"",
    lastname character varying(255) COLLATE pg_catalog.""default"",
    dateofbirth date NOT NULL,
    dateofdeath date,
    gender character varying(100) COLLATE pg_catalog.""default"",
    CONSTRAINT person_pkey PRIMARY KEY (personid)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;";

        }
    }
}