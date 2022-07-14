using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.MoneyTransactions
{
    public class BankAccount
    {
        public int Number { get; set; }

        public double Balance { get; set; }

        public BankAccount(int number, double balance)
        {
            Number = number;
            Balance = balance;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> bankAccountsInput = Console.ReadLine().Split(",").ToList();

            List<BankAccount> bankAccounts = new List<BankAccount>();

            foreach (var bankAcc in bankAccountsInput)
            {
                string[] tokens = bankAcc.Split("-");
                int accountNumber = int.Parse(tokens[0]);
                double accountBalance = double.Parse(tokens[1]);

                BankAccount bankAccount = new BankAccount(accountNumber, accountBalance);
                bankAccounts.Add(bankAccount);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string action = command.Split()[0];
                int currAccountNumber = int.Parse(command.Split()[1]);
                double sum = double.Parse(command.Split()[2]);

                try
                {
                    BankAccount currBankAcc = bankAccounts.FirstOrDefault(x => x.Number == currAccountNumber);
                    if (currBankAcc == null)
                    {
                        throw new FormatException("Invalid account!");
                    }

                    if (action == "Deposit")
                    {
                        currBankAcc.Balance += sum;
                    }
                    else if (action == "Withdraw")
                    {
                        if (sum > currBankAcc.Balance)
                        {
                            throw new FormatException("Insufficient balance!");
                        }
                        else
                        {
                            currBankAcc.Balance -= sum;
                        }
                    }
                    else
                    {
                        throw new FormatException("Invalid command!");
                    }

                    Console.WriteLine($"Account {currBankAcc.Number} has new balance: {currBankAcc.Balance:f2}");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command"); 
                }

            }

        }
    }
}
