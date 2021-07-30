using System;
using System.Collections.Generic;

namespace BankProject
{
    class Program
    {
        private const int AccountOffset = 1001;
        static List<Account> AccountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Bye!");
        }

        private static void Clear()
        {
            throw new NotImplementedException();
        }

        private static void Deposit()
        {
            Console.Write("Enter account number: ");
			int accNumber = int.Parse(Console.ReadLine()) - AccountOffset;

			Console.Write("Enter the value to be deposited: ");
			double deposit = double.Parse(Console.ReadLine());

            AccountList[accNumber].Deposit(deposit);
        }

        private static void Withdraw()
        {
            Console.Write("Enter account number: ");
            int accNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the withdraw value: ");
            double withdraw = double.Parse(Console.ReadLine());

            AccountList[accNumber - AccountOffset].Withdraw(withdraw);
        }

        private static void Transfer()
        {
            Console.Write("Enter the giver's account number: ");
            int giver = int.Parse(Console.ReadLine()) - AccountOffset;

            Console.Write("Enter the receiver's account number: ");
            int receiver = int.Parse(Console.ReadLine()) - AccountOffset;

            Console.Write("Enter the transfer value: ");
            double transfer = double.Parse(Console.ReadLine());

            AccountList[giver].Transfer(transfer, AccountList[receiver]);
        }

        private static void InsertAccount()
        {
            
            Console.WriteLine("Inserting new account:");

            Console.Write("Type 1 for Personal Account, 2 for Business Account: ");
            int userType = int.Parse(Console.ReadLine());

            Console.Write("Client name: ");
            string userName = Console.ReadLine();

            Console.Write("Starting balance: ");
            double userBalance = double.Parse(Console.ReadLine());

            Console.Write("Starting Credit: ");
            double userCredit = double.Parse(Console.ReadLine());

            int generatedId = AccountList.Count + AccountOffset;

            Account acc = new Account(  
                (AccountType)userType, 
                userBalance, 
                userCredit, 
                userName,
                generatedId);
                                        
            AccountList.Add(acc);

            Console.WriteLine();
            Console.WriteLine("---ACCOUNT ADDED. YOUR ACCOUNT NUMBER IS {0}.---", generatedId);
            Console.WriteLine();
            
        }

        private static void ListAccounts()
        {
            Console.WriteLine("Listing accounts...");

            if (AccountList.Count == 0)
            {
                Console.WriteLine("---NO ACCOUNTS FOUND.---");
                return;
            }
                foreach (Account a in AccountList)
                {
                    Console.WriteLine(a);
                }
        }

        private static string GetUserOption()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Welcome to FakeBank!");
            Console.WriteLine("Choose from the following options:");
            
            Console.WriteLine("1. List Accounts");
            Console.WriteLine("2. Insert New Account");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Deposit");
            Console.WriteLine("C. Clean Console");
            Console.WriteLine("X. Exit");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
