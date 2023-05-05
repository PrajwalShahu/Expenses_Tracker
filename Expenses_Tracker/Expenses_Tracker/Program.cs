using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string title, string description, double amount, DateTime date)
        {
            Title = title;
            Description = description;
            Amount = amount;
            Date = date;
        }
    }

    class ExpenseManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction()
        {
            string title = "";
            string description = "";
            try
            {
                Console.Write("Enter Title: ");
                title = Console.ReadLine();                

                Console.Write("Enter Description: ");
                description = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    throw new EmptyException();
                }
            }
            catch(EmptyException)
            {
                Console.WriteLine("Fields should not be empty");
                return;
            }

            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            
            //amount = amount < 0 ? amount : amount;

            Console.Write("Enter Date (dd-MM-yyyy): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            
            transactions.Add(new Transaction(title, description, amount, date));
            Console.WriteLine("Transaction Added Successfully!");              

        }

        public  void ViewExpenses()
        {
            Console.WriteLine("--- Expense Transactions ---");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount < 0)
                {
                    Console.WriteLine($"Title:{transaction.Title}, Description:{transaction.Description}, Amount:{transaction.Amount}, Date:{transaction.Date.ToString("dd-MM-yyyy")})");
                }
            }
        }

        public void ViewIncome()
        {
            Console.WriteLine("--- Income Transactions ---");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount > 0)
                {
                    Console.WriteLine($"Title:{transaction.Title}, Description:{transaction.Description}, Amount:{transaction.Amount}, Date:{transaction.Date.ToString("dd-MM-yyyy")})");
                }
            }
        }      

        public void CheckAvailableBalance()
        {
            double balance = 0;
            foreach (Transaction transaction in transactions)
            {
                balance += transaction.Amount;
            }

            Console.WriteLine($"Available Balance: {balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager expenseManager = new ExpenseManager();
            //int choice = 0;

            while (true)
            {
                Console.WriteLine("1. AddTransaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. Check Available Balance");
                
                
                 Console.Write("Enter your choice (1-4): ");
                 int choice = Convert.ToInt32(Console.ReadLine());                
               
                
                 switch (choice)
                 {
                     case 1:
                         expenseManager.AddTransaction();
                         break;                        
                     case 2:
                         expenseManager.ViewExpenses();
                         break;
                     case 3:
                         expenseManager.ViewIncome();
                         break;
                     case 4:
                         expenseManager.CheckAvailableBalance();
                         break;
                     default:
                         Console.WriteLine("Wrong Choice Entered!");
                         break;
                 }              

                Console.WriteLine();
            }
        }
    }
}
