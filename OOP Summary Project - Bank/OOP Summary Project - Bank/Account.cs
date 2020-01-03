using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    public class Account
    {
        private static int numberOfAcc;
        //private readonly int accountNumber; 
        //private readonly Customer accountOwner; 
        //private int maxMinusAllowed;            don't really need these, right?
        public int AccountNumber { get; }
        public int Balance { get; private set; }
        public Customer AccountOwner { get; }
        public int MaxMinusAllowed { get; }

        public Account(Customer customer, int monthlyIncome)
        {
            AccountOwner = customer;
            AccountNumber = numberOfAcc;
            numberOfAcc++;
            MaxMinusAllowed = (monthlyIncome * 3 * -1);
        }

        public void Add(int amount)
        {
            Balance += amount;
        }

        public void Subtract(int amount)
        {
            Balance -= amount;
        }

        public static bool operator == (Account acc1, Account acc2)
        {
            if (acc1 is null && acc2 is null)
                return true;
            if (acc1 is null || acc2 is null)
                return false;
            if (acc1.AccountNumber == acc2.AccountNumber)
                return true;
            return false;
        }

        public static bool operator !=(Account acc1, Account acc2)
        {
            return !(acc1 == acc2);
        }

        public static Account operator +(Account acc1, Account acc2)
        {
            if (acc1 is null || acc2 is null)
                return null;

            Account accNew = new Account(acc1.AccountOwner, (acc1.MaxMinusAllowed + acc2.MaxMinusAllowed) / -3);
            accNew.Balance = acc1.Balance + acc2.Balance;
            return accNew;
        }

        public override bool Equals(object obj)
        {
            Account other = (Account)obj;
            return this == other;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        public override string ToString()
        {
            return $"Account --- Account Number: {AccountNumber}, Account Owner: [{AccountOwner}], Balance: {Balance}, Max Minus Allowed: {MaxMinusAllowed}";
        }
    }
}
