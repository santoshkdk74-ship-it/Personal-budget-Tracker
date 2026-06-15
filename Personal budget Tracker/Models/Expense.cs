using System;

namespace Personal_budget_Tracker.Models
{
    public class Expense : BaseTransaction
    {
        public bool IsRecurring { get; set; }

        public Expense() { }

        public Expense(decimal amount, string description, DateTime date, string category, bool isRecurring)
            : base(amount, description, date, category)
        {
            IsRecurring = isRecurring;
        }

        public override string GetTransactionType()
        {
            return "Expense";
        }

        public override string GetSummary()
        {
            string recurring = IsRecurring ? " [Recurring]" : "";
            return $"[EXPENSE] {Category} | ${Amount:F2} | {Date:dd/MM/yyyy} | {Description}{recurring}";
        }
    }
}