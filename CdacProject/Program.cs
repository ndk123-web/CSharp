using System;

namespace BankApp
{
    // Abstract base class for all account types (kind of like a blueprint)
    public abstract class Account
    {
        // Static counter for unique account IDs (auto-increments for each new account)
        private static int _idCounter = 1000;

        // Property: Each account gets a unique ID, can't change after creation
        public int Id { get; }

        // Name of the account holder (can be changed if needed)
        public string Name { get; set; }

        // Account balance, only subclasses can directly use/modify this
        protected double Balance { get; set; }

        // Constructor: Sets name and starting balance, auto-generates ID
        public Account(string name, double initialBalance)
        {
            Id = ++_idCounter; // Increase counter and assign as ID
            Name = name;
            Balance = initialBalance;
        }

        // Any account can deposit money (simple add to balance)
        public void Deposit(double amt)
        {
            Balance += amt;
            Console.WriteLine($"Deposited: {amt}. New Balance: {Balance}");
        }

        // Withdraw must be defined differently for each account type
        public abstract void Withdraw(double amt);

        // Show account info (can be further customized in derived classes)
        public virtual void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Balance: {Balance}");
        }
    }

    // Savings account: must always keep a minimum amount
    class SavingAccount : Account
    {
        private const double minbal = 1000; // Minimum balance rule

        // Constructor: checks if starting balance is enough
        public SavingAccount(string name, double initialBalance)
            : base(name, initialBalance)
        {
            if (initialBalance < minbal)
                throw new Exception($"Initial balance must be at least {minbal}");
        }

        // Withdraw: Make sure minimum balance is maintained
        public override void Withdraw(double amt)
        {
            if (Balance - amt < minbal)
                throw new Exception($"Cannot withdraw. Minimum balance of {minbal} must be maintained.");
            Balance -= amt;
            Console.WriteLine($"Withdrawn: {amt}. Remaining Balance: {Balance}");
        }
    }

    // Current account: no minimum balance restriction
    class CurrentAccount : Account
    {
        public CurrentAccount(string name, double initialBalance)
            : base(name, initialBalance) { }

        // Withdraw: no minimum balance check here!
        public override void Withdraw(double amt)
        {
            Balance -= amt;
            Console.WriteLine($"Withdrawn: {amt}. Remaining Balance: {Balance}");
        }
    }

    // The main entry point of the program
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message (my personal touch with emojis)
            Console.WriteLine("🏦 Welcome to NDK Bank 🏦\n");

            Account[] accounts = new Account[3]; // Can hold up to 3 accounts (as per assignment rule)
            int created = 0; // Track how many have been created

            try
            {
                while (true)
                {
                    if (created >= 3)
                        throw new Exception("You can create only 3 accounts."); // Limit reached

                    Console.WriteLine("Choose Account Type: 1. Saving  2. Current");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Initial Balance: ");
                    double balance = double.Parse(Console.ReadLine());

                    // Instantiating the chosen account type
                    if (choice == 1)
                        accounts[created] = new SavingAccount(name, balance);
                    else if (choice == 2)
                        accounts[created] = new CurrentAccount(name, balance);
                    else
                        Console.WriteLine("Invalid choice."); // Wrong input!

                    Console.WriteLine("Account created successfully!");
                    accounts[created].Display(); // Show details right away

                    created++; // Move to next slot

                    Console.Write("Create another account? (y/n): ");
                    string cont = Console.ReadLine();
                    if (cont.ToLower() != "y")
                        break; // Exit if user says no
                }
            }
            catch (Exception ex)
            {
                // Catch and display any error (like less than min balance, or too many accounts)
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            // Final output: show all accounts that were created
            Console.WriteLine("\n📦 Final Accounts:");
            foreach (var acc in accounts)
            {
                if (acc != null) acc.Display();
            }
        }
    }
}
