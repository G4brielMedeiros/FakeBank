using System.Globalization;
using System;
namespace BankProject
{
    public class Account
    {
        private AccountType AccountType { get; set;}

        private double Balance { get; set;}

        private double Credit { get; set; }

        private string Name { get; set;}

        public int Id { get; private set; }

        public Account(AccountType accountType, double balance, double credit, string name, int id)
        {
            AccountType = accountType;
            Balance = balance;
            Credit = credit;
            Name = name;
            Id = id;
        }

        public bool Withdraw(double withdraw)
        {
            if (this.Balance - withdraw < (-1*this.Credit)) {
                Console.WriteLine();
                Console.WriteLine("---NOPE. INSUFFICIENT FUNDS.---");
                Console.WriteLine();
                return false;
            }

            this.Balance -= withdraw;
            Console.WriteLine();
            Console.WriteLine("---CURRENT BALANCE OF {0}'S ACCOUNT IS NOW ${1}.---", this.Name, this.Balance);
            Console.WriteLine();
            return true;
        }

        public void Deposit(double deposit) {

            this.Balance += deposit;
            Console.WriteLine();
            Console.WriteLine("---CURRENT BALANCE OF {0}'S ACCOUNT IS NOW ${1}.---", this.Name, this.Balance);
            Console.WriteLine();
        }

        public void Transfer(double transfer, Account receiver)
        {
            if (this.Withdraw(transfer))
            {
                receiver.Deposit(transfer);
            }
        }

        public override string ToString()
        {
            return "#" + this.Id + ": " + this.AccountType + " " + this.Name + " [ " + "Balance: $" + this.Balance +  " | Credit: $" + this.Credit + " ]";
        }
    }
}