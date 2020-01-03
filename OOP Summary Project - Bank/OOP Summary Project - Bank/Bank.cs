using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    public class Bank : IBank
    {
        private List<Account> accList = new List<Account>();
        private List<Customer> cusList = new List<Customer>();
        private Dictionary<int, Customer> mapCustomerIDToCustomer = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> mapCustomerNumberToCustomer = new Dictionary<int, Customer>();
        private Dictionary<int, Account> mapAccountNumberToAccount = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> mapCustomerToAccountList = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private int profits;
        public string Name { get; }
        public string Address { get; }
        public int CustomerCount { get; private set; }

        public Bank(string name, string address)
        {
            Name = name;
            Address = address;
            CustomerCount = 0;
        }

        internal Customer GetCustomerById(int customerId)
        {
            //try
            //{
            if (mapCustomerIDToCustomer.TryGetValue(customerId, out Customer foundCustomer))
                return foundCustomer;
            throw new CustomerNotFoundException($"no customer with the id of {customerId} was found!");
            //}
            //catch(CustomerNotFoundException cnfe)
            //{
            //    Console.WriteLine(cnfe.Message);
            //    return null;
            //}
        }

        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (mapCustomerNumberToCustomer.TryGetValue(customerNumber, out Customer foundCustomer))
                return foundCustomer;
            throw new CustomerNotFoundException($"no customer with a customer number of {customerNumber} was found!");
        }

        internal Account GetAccountByNumber(int accountNumber)
        {
            if (mapAccountNumberToAccount.TryGetValue(accountNumber, out Account foundAccount))
                return foundAccount;
            throw new AccountNotFoundException($"no account with an account number of {accountNumber} was found!");
        }

        internal List<Account> GetAccountsByCustomer(Customer customer)
        {
            if (mapCustomerToAccountList.TryGetValue(customer, out List<Account> foundAccountList))
            {
                return foundAccountList;
            }
            else
            {
                throw new CustomerNotFoundException($"customer [{customer}] was not found!");
            }
        }

        internal void AddNewCustomer(Customer customer)
        {
            if (customer is null)
                throw new NullCustomerException("cannot add null customers!");
            if (cusList.Contains(customer))
                throw new CustomerAlreadyExistsException($"customer [{customer}] already exists on the customer list!");
            if (mapCustomerIDToCustomer.ContainsKey(customer.CustomerID))
                throw new CustomerAlreadyExistsException($"there is already a customer on the list with a customer number of {customer.CustomerID}");
            cusList.Add(customer);
            mapCustomerIDToCustomer.Add(customer.CustomerID, customer);
            mapCustomerNumberToCustomer.Add(customer.CustomerNumber, customer);
            mapCustomerToAccountList.Add(customer, customer.accounts);
            CustomerCount++;
        }

        internal void OpenNewAccount(Account account)
        {
            if (account is null)
                throw new NullAccountException("cannot add null accounts!");
            if (account.AccountOwner is null)
                throw new NullCustomerException("cannot assign an account to a null customer!");
            if (cusList.Contains(account.AccountOwner) == false)
                throw new CustomerNotFoundException($"customer [{account.AccountOwner}] was not found in the customer list!");
            if (accList.Contains(account))
                throw new AccountAlreadyExistsException($"account [{account}] already exists on the account list!");
            accList.Add(account);
            mapAccountNumberToAccount.Add(account.AccountNumber, account);
            account.AccountOwner.accounts.Add(account);
        }

        /*int */ //why was it returning int?
        internal void Deposit(Account account, int amount)
        {
            if (account is null)
                throw new NullAccountException($"cannot deposit with null accounts!");
            if (accList.Contains(account) == false)
                throw new AccountNotFoundException($"account [{account}] was not found in the account list!");
            if (amount <= 0)
                throw new UnpositiveAmountException($"cannot deposit amounts of 0 or lower! [{amount}]");
            account.Add(amount);
            totalMoneyInBank += amount;
        }

        /*int */ //why was it returning int?
        internal void Withdraw(Account account, int amount)
        {
            if (account is null)
                throw new NullAccountException($"cannot withdraw with null accounts!");
            if (accList.Contains(account) == false)
                throw new AccountNotFoundException($"account [{account}] was not found in the account list!");
            if (amount <= 0)
                throw new UnpositiveAmountException($"cannot withdraw amounts of 0 or lower! [{amount}]");
            if (account.Balance - amount < account.MaxMinusAllowed)
                throw new BalanceException($"cannot withdraw {amount} with account [{account}] as it will put the account below its maximum debt limit!");
            account.Subtract(amount);
            totalMoneyInBank -= amount;
        }

        internal int GetCustomerTotalBalance(Customer customer)
        {
            if (customer is null)
                throw new NullCustomerException("cannot get total balance of null customers!");
            if (cusList.Contains(customer) == false)
                throw new CustomerNotFoundException($"customer [{customer}] was not found in the customer list!");
            int totalBalance = 0;
            customer.accounts.ForEach(a => totalBalance += a.Balance);
            return totalBalance;
        }

        private void CloseAccount(Account account) //for JoinAccounts method purposes only
        {
            if (accList.Contains(account) == false)
                throw new AccountNotFoundException($"cannot delete account {account} as it is not found!");
            accList.Remove(account);
            account.AccountOwner.accounts.Remove(account);
            mapAccountNumberToAccount.Remove(account.AccountNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage">must be between 0 - 100</param>
        internal void ChargeAnnualCommision(float percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new PercentageOutOfRangeException($"percentage {percentage} was not within the accepted range! [0 - 100]");
            }
            float decimalPercentage = percentage / 100.0f;
            foreach (Account acc in accList)
            {
                if (acc.Balance >= 0)
                {
                    float commission = acc.MaxMinusAllowed * decimalPercentage / -3;
                    acc.Subtract((int)commission);
                    profits += (int)commission;
                }
                else
                {
                    float doubleCommission = acc.MaxMinusAllowed * decimalPercentage / -3 * 2;
                    acc.Subtract((int)doubleCommission);
                    profits += (int)doubleCommission;
                }
            }
        }

        internal void JoinAccounts(Account account1, Account account2)
        {
            if (account1 is null)
                throw new NullAccountException("the first account you tried to combine is null!");
            if (account2 is null)
                throw new NullAccountException("the second account you tried to combine is null!");
            if (accList.Contains(account1) == false)
                throw new AccountNotFoundException($"failed to join accounts [{account1}] and [{account2}] - the first account does is not in the account list!");
            if (accList.Contains(account2) == false)
                throw new AccountNotFoundException($"failed to join accounts [{account1}] and [{account2}] - the second account does is not in the account list!");
            if (account1.AccountOwner != account2.AccountOwner)
                throw new NotSameCustomerException($"failed to join accounts [{account1}] and [{account2}], the accounts do not share the same customer!");
            if (account1 == account2)
                throw new SameAccountException($"failed to join accounts, you are trying to combine the same account with itself! [{account1}]");
            Account joinedAccount = account1 + account2;
            OpenNewAccount(joinedAccount);
            CloseAccount(account1);
            CloseAccount(account2);
        }

        public override string ToString()
        {
            return $"Bank --- Name: {Name}, Address: {Address}, Number of Customers: {CustomerCount}, Total Money: {totalMoneyInBank}, Profits: {profits}";
        }
    }
}
