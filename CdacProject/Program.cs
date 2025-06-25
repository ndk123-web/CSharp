using System;

namespace BankApp
{
    public abstract class Account
    {
        private static int _idCounter = 1000;
        public int Id { get; } // it is read-only after initialization 
        public string Name { get; set; }

        // only child classes can access this property 
        protected double Balance { get; set; }

        public Account(string name, double initialBalance)
        {
            Id = ++_idCounter;
            Name = name;
            Balance = initialBalance;
        }

        public void Deposit(double amt)
        {
            Balance += amt;
            Console.WriteLine($"Deposited: {amt}. New Balance: {Balance}");
        }

        public abstract void Withdraw(double amt);

        public virtual void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Balance: {Balance}");
        }
    }

    class SavingAccount : Account
    {
        private const double minbal = 1000;

        public SavingAccount(string name, double initialBalance)
            : base(name, initialBalance)
        {
            if (initialBalance < minbal)
                throw new Exception($"Initial balance must be at least {minbal}");
        }

        public override void Withdraw(double amt)
        {
            if (Balance - amt < minbal)
                throw new Exception($"Cannot withdraw. Minimum balance of {minbal} must be maintained.");
            Balance -= amt;
            Console.WriteLine($"Withdrawn: {amt}. Remaining Balance: {Balance}");
        }
    }

    class CurrentAccount : Account
    {
        public CurrentAccount(string name, double initialBalance)
            : base(name, initialBalance) { }

        public override void Withdraw(double amt)
        {
            Balance -= amt;
            Console.WriteLine($"Withdrawn: {amt}. Remaining Balance: {Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🏦 Welcome to NDK Bank 🏦\n");

            Account[] accounts = new Account[3];
            int created = 0;

            try
            {
                while (true)
                {
                    if (created >= 3)
                        throw new Exception("You can create only 3 accounts.");

                    Console.WriteLine("Choose Account Type: 1. Saving  2. Current");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Initial Balance: ");
                    double balance = double.Parse(Console.ReadLine());

                    if (choice == 1)
                        accounts[created] = new SavingAccount(name, balance);
                    else if (choice == 2)
                        accounts[created] = new CurrentAccount(name, balance);
                    else
                        Console.WriteLine("Invalid choice.");

                    Console.WriteLine("Account created successfully!");
                    accounts[created].Display();

                    created++;

                    Console.Write("Create another account? (y/n): ");
                    string cont = Console.ReadLine();
                    if (cont.ToLower() != "y")
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            Console.WriteLine("\n📦 Final Accounts:");
            foreach (var acc in accounts)
            {
                if (acc != null) acc.Display();
            }
        }
    }
}
