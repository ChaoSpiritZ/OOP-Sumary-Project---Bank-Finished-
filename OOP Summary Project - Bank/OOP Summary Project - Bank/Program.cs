using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bank poalim = new Bank("hapoalim", "idk");

                //poalim.AddNewCustomer(null);
                Customer cus1 = new Customer(300, "george", "050-0000000");
                Customer cus2 = cus1;
                Customer cus3 = new Customer(300, "george", "050-0000000");
                poalim.AddNewCustomer(cus1);
                //poalim.AddNewCustomer(cus2);
                //poalim.AddNewCustomer(cus3);

                poalim.GetCustomerById(300);
                poalim.GetCustomerByNumber(0);

                //poalim.OpenNewAccount(new Account(null, 300));
                Account acc1 = new Account(poalim.GetCustomerById(300), 500);
                Account acc2 = acc1;
                poalim.OpenNewAccount(acc1);
                //poalim.OpenNewAccount(acc2);

                poalim.GetAccountByNumber(0);

                //poalim.GetAccountsByCustomer(new Customer(300, "m8", "051-1111111"));
                //List<Account> accounts = poalim.GetAccountsByCustomer(poalim.GetCustomerById(300));
                //accounts.ForEach(a => Console.WriteLine(a));

                poalim.Deposit(acc2, 10000); //i'm guessing you can't really fix this, i don't even think it's a problem now that i think about it...
                //poalim.Deposit(null, 61);
                //poalim.Deposit(new Account(cus1, 700), 5000);
                //poalim.Deposit(acc1, 0);

                //poalim.Withdraw(null, 27398);
                //poalim.Withdraw(new Account(cus1, 800), 100);
                //poalim.Withdraw(acc1,100000);
                //poalim.Withdraw(acc1, -3);
                poalim.Withdraw(acc1, 400);
                poalim.Withdraw(acc2, 500); //yeah it's the same account, just checking if it still works

                //poalim.GetCustomerTotalBalance(null);
                //poalim.GetCustomerTotalBalance(new Customer(777, "shmuel", "052-P40N3"));
                //poalim.GetCustomerTotalBalance(cus3);
                poalim.GetCustomerTotalBalance(cus1);
                poalim.GetCustomerTotalBalance(cus2);

                //poalim.ChargeAnnualCommision(-268);
                //poalim.ChargeAnnualCommision(200);
                //poalim.ChargeAnnualCommision(100.1f);
                poalim.ChargeAnnualCommision(100);

                Account acc22 = new Account(poalim.GetCustomerById(300), 500);
                poalim.OpenNewAccount(acc22);
                poalim.Withdraw(acc22, 1000);
                poalim.ChargeAnnualCommision(100);

                Customer cus33 = new Customer(33, "john", "053-3333333");
                poalim.AddNewCustomer(cus33);
                Account acc33 = new Account(cus33, 800);
                poalim.OpenNewAccount(acc33);
                //poalim.JoinAccounts(null, null);
                //poalim.JoinAccounts(new Account(null, 300), null);
                //poalim.JoinAccounts(new Account(null, 300), new Account(null, 700));
                //poalim.JoinAccounts(acc1, new Account(null, 700));
                //poalim.JoinAccounts(acc1, acc33);
                //poalim.JoinAccounts(acc1, acc1);
                //poalim.JoinAccounts(acc1, acc2); kinda expected...
                poalim.JoinAccounts(acc1, acc22);

                Console.WriteLine(acc1);
                Console.WriteLine(acc22);
                Console.WriteLine(poalim);
                Console.WriteLine("===========================");

                List<Account> accounts = poalim.GetAccountsByCustomer(cus1);
                accounts.ForEach(a => Console.WriteLine(a));

                Console.WriteLine("GOODBYE");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("GOODBYE WITH ERRORS!");
            }
        }
    }
}
