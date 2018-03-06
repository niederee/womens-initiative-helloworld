using System;

namespace HelloWorld
{
    public class AccountPerson
    {
        public int AccountPersonId { get; set; }
        public int AccountId { get; set; }
        public int PersonId { get; set; }
        public AccountPersonType AccountPersonType { get; set; }
        public DateTime DateAdded { get; set; }
    }

}