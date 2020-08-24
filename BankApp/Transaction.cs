using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }

        public Transaction(double amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
    }
}
