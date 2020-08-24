using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Help
    {
        public void HelpMe()
        {

            Console.WriteLine("Here’s a list of commands you can use!");
            Console.WriteLine("");
            Console.WriteLine("help                Opens this dialog.");
            Console.WriteLine("quit                Quits the program.");
            Console.WriteLine("");
            Console.WriteLine("Account actions");
            Console.WriteLine("create_account      Opens a dialog for creating an account.");
            Console.WriteLine("does_account_exist  Opens a dialog for checking if an account exists.");
            Console.WriteLine("account_balance     Opens a dialog for logging in and prints the account balance.");
            Console.WriteLine("");
            Console.WriteLine("Fund actions");
            Console.WriteLine("withdraw_funds      Opens a dialog for withdrawing funds.");
            Console.WriteLine("deposit_funds       Opens a dialog for depositing funds.");
            Console.WriteLine("transfer_funds      Opens a dialog for transferring funds to another account.");
        }
    }
}
