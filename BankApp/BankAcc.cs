using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace BankApp
{
    class BankAcc
    {
        //private List<BankAcc> allUsers = new List<BankAcc>();


        //Random rng = new Random();


        private static int accountNumberSeed = 1234567890;
        private List<User> allUsers = new List<User>
        {
            new User{Username = "testi", Password = "tonttu", AccountId = 1234567891, Balance = 450}
        };

        private List<Transaction> allTransactions = new List<Transaction>();

        /*public BankAcc (string name, double balance)
        {
            Username = name;
            //this.balance = balance;
            //int i = rng.Next(999);
            this.AccoundId = accountNumberSeed.ToString();
            accountNumberSeed++;
            //allUsers.Add(new BankAcc(username, balance));            
            MakeDeposit(balance, DateTime.Now);
            var user = new User(Username, Password, AccoundId, Balance);
            allUsers.Add(user);
        }*/



        public void CreateAccount()
        {
            Console.WriteLine("$ Creating a new user account!");
            Console.WriteLine("$ Insert your name.");
            Console.Write("> ");
            string myName = Console.ReadLine();
            Console.WriteLine($"$ Hello {myName}! It's great to have you as a client.");
            Console.WriteLine("$ How much is your initial deposit? (The minimum is 10€)");
            Console.Write("> ");
            double.TryParse(Console.ReadLine(), out double i);
            while (i < 10)
            {
                Console.WriteLine("$ Unfortunately we can’t open an account for such a small account. Do you have any more cash with you?");
                double.TryParse(Console.ReadLine(), out i);
                continue;
            }

            //user.balance = user.balance + i;
            double myBalance = i;
            Console.WriteLine($"$ Great, {myName}! You now have an account with a balance of {myName} €.");
            Console.WriteLine($"$ We’re happy to have you as a customer, and we want to ensure that your money is safe with us. ");

            Console.WriteLine($"$ Give us a password, which gives only you the access to your account.");
            Console.Write("> ");
            string myPassword = Console.ReadLine();
            int id = accountNumberSeed++;
            Console.WriteLine("$ Your Account is now created");
            Console.WriteLine($"$ Account id: {id}");
            Console.WriteLine("$ Store your account id in a safe place.");

            User user = new User { Username = myName, Password = myPassword, AccountId = id, Balance = myBalance };
            allUsers.Add(user);
        }

        public void Balance()
        {
            Console.WriteLine("Checking your account balance!");

            User user = CheckMyUser();

            Console.WriteLine($"Your account balance is {user.Balance}€.");
        }



        public void MakeDeposit()
        {

            User user = CheckMyUser();
            /*double amount = ReadDouble();
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }*/
            //var deposit = new Transaction(amount, date);
            //allTransactions.Add(deposit);
            Console.WriteLine($"How much money do you want to deposit? (Current balance: {user.Balance}€)");

            double depositAmount = ReadDouble();
            user.Balance += depositAmount;

            Console.WriteLine($"Depositing {depositAmount}€. Your account balance is now {user.Balance}€.");

        }
        /*public void MakeWithdrawal(double amount, DateTime date)
        {

            User user = CheckMyUser();
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (user.Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date);
            allTransactions.Add(withdrawal);
        }*/

        public void MakeWithdrawal()
        {
            Console.WriteLine("Withdrawing cash!");

            User user = CheckMyUser();

            Console.WriteLine($"How much money do you want to withdraw? (Current balance: {user.Balance}€)");

            double withdrawAmount;
            do
            {
                withdrawAmount = ReadDouble();
                if (withdrawAmount > user.Balance)
                {
                    Console.WriteLine("Unfortunately you don’t have the balance for that. Try a smaller amount.");
                }
                else
                {
                    user.Balance -= withdrawAmount;
                    Console.WriteLine($"Withdrawing a cash sum of {withdrawAmount}€. Your account balance is now {user.Balance}€.");
                    break;
                }
            } while (withdrawAmount > user.Balance);
        }

        public void Transfer()
        {
            Console.WriteLine("Transferring funds!");

            User user = CheckMyUser();

            Console.WriteLine($"How much money do you want to transfer? (Current balance: {user.Balance}€)");

            double transferAmount;
            do
            {
                transferAmount = ReadDouble();
                if (transferAmount > user.Balance)
                {
                    Console.WriteLine("Unfortunately you don’t have the balance for that. Try a smaller amount.");
                }
            } while (transferAmount > user.Balance);

            Console.WriteLine("Which account ID do you want to transfer these funds to?");

            User recipient;
            do
            {
                int recipientId = ReadInt();
                recipient = GetUserById(recipientId);

                if (recipient == null)
                {
                    Console.WriteLine("An account with that ID does not exist. Try again.");
                }
                else
                {
                    recipient.Balance += transferAmount;
                    Console.WriteLine($"Sending {transferAmount}€ from account ID {user.AccountId} to account ID {recipientId}.");
                    break;
                }
            } while (recipient == null);
        }


        private double ReadDouble()
        {
            bool success = false;
            double input = 0;

            while (!success)
            {
                success = double.TryParse(Console.ReadLine(), out input);
                if (!success || input < 0)
                {
                    Console.WriteLine("Please enter a valid value.");
                    success = false;
                }
            }

            return input;
        }



        private int ReadInt()
        {
            bool success = false;
            int input = 0;

            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out input);
                if (!success)
                {
                    Console.WriteLine("Please enter a valid value.");
                }
            }

            return input;
        }

        public User GetUserById(int id)
        {
            User foundUser = null;
            foreach (User user in allUsers)
            {
                if (user.AccountId == id)
                {
                    foundUser = user;
                }
            }
            return foundUser;
        }



        public User CheckMyUser()
        {
            Console.WriteLine("What is your account ID?");

            User user;
            do
            {
                int id = ReadInt();

                user = GetUserById(id);
                if (user == null)
                {
                    Console.WriteLine("An account with that ID does not exist. Try again.");
                }
            } while (user == null);

            Console.WriteLine("Account found! Insert your password.");

            CheckMyPassword(user);
            return user;
        }

        private void CheckMyPassword(User user)
        {
            string password;
            do
            {
                password = Console.ReadLine();
                if (user.Password != password)
                {
                    Console.WriteLine("Wrong password, try again.");
                }
                else
                {
                    Console.WriteLine($"Password Correct {user.Username}.");
                    break;
                }
            } while (user.Password != password);
        }
    }


    /*public void addAccount(string name, string password, string accountId, double balance)
    {

    }*/
    /*public string IdExists(string id)
    {
        var element = allUsers.Find(x => x.AccountId == id);


        if (element == null)
        {
            //Console.WriteLine("ID exists");
            //return;
        }
        else
        {

        }
        return id;
    }*/



}

