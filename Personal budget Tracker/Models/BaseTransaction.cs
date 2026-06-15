using System;

namespace Personal_budget_Tracker.Models
{
    public abstract class BaseTransaction
    {
        private int _id;
        private decimal _amount;
        private string _description;
        private DateTime _date;
        private string _category;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Amount must be greater than zero.");
                _amount = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public BaseTransaction() { }

        public BaseTransaction(decimal amount, string description, DateTime date, string category)
        {
            Amount = amount;
            Description = description;
            Date = date;
            Category = category;
        }

        // Abstract method - must be overridden (Polymorphism)
        public abstract string GetTransactionType();

        public virtual string GetSummary()
        {
            return $"{GetTransactionType()} | {Category} | ${Amount:F2} | {Date:dd/MM/yyyy} | {Description}";
        }
    }
}