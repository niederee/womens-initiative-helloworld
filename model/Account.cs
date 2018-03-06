using System;

namespace HelloWorld
{
    public class Account 
    {
        public int AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}