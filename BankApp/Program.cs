using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //int j = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("$ Welcome to Buutting banking CLI");
            Console.WriteLine("$ Hint: You can get help with the commands by typing \"help\"");


            Help help = new Help();
            BankAcc bank = new BankAcc();


            /*if (Console.ReadLine() == "help")
            {
                    help.HelpMe();
                
            }*/
            while (true)
            {
                string c = Console.ReadLine();

                switch (c)
                {
                    case "help":
                        help.HelpMe();
                        break;
                    case "quit":
                        System.Environment.Exit(0);
                        break;
                    case "create_account":
                        bank.CreateAccount();

                        break;
                    case "does_account_exist":
                       /* Console.WriteLine("$ Checking if an account exists!");
                        Console.WriteLine("$ Enter the account ID whose existence you want to verify");
                        Console.Write("> ");
                        string s = Console.ReadLine();*/

                        bank.CheckMyUser();


                        break;
                    case "account_balance":
                        bank.Balance();
                        break;
                    case "withdraw_funds":
                        bank.MakeWithdrawal();

                        break;
                    case "deposit_funds":
                        bank.MakeDeposit();
                        break;
                    case "transfer_funds":
                        bank.Transfer();
                        break;
                    default:
                        break;

                }
            }

        }
    }
}
