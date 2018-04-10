using System.Collections.Generic;

namespace HelloWorld
{
    public interface IDataService
    {

        List<Account> Accounts { get;  }
        List<Person> People { get;  }
        List<AccountPerson> AccountPersons { get;  }
        List<ShoePerson> ShoePersons { get;  }
        List<Shoe> Shoes { get; set; }



    }
}