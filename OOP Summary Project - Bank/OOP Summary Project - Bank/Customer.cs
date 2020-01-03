using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    public class Customer
    {
        private static int numberOfCust;
        //private readonly int customerID;
        //private readonly int customerNumber; don't really need these, right?
        public string Name { get; private set; }
        public string PhNumber { get; private set; }
        public int CustomerID { get; }
        public int CustomerNumber { get; }
        //added because i think it's necessary:
        public List<Account> accounts = new List<Account>();

        public Customer(int id, string name, string phone)
        {
            CustomerID = id;
            Name = name;
            PhNumber = phone;
            CustomerNumber = numberOfCust;
            numberOfCust++;
        }

        public static bool operator == (Customer cus1, Customer cus2)
        {
            if(cus1 is null && cus2 is null)
                return true;
            if (cus1 is null || cus2 is null)
                return false;
            if(cus1.CustomerNumber == cus2.CustomerNumber)
                return true;
            return false;
        }

        public static bool operator != (Customer cus1, Customer cus2)
        {
            return !(cus1 == cus2);
        }

        public override bool Equals(object obj)
        {
            Customer other = (Customer)obj;
            return this == other;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"Customer --- ID: {CustomerID}, Name: {Name}, Phone Number: {PhNumber}, Customer Number: {CustomerNumber}";
        }
    }
}
