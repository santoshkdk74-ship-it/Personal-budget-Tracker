using System;

namespace Personal_budget_Tracker.Models
{
    public class Income : BaseTransaction
    {
        public string Source { get; set; }

        public Income() { }

        public Income(decimal amount, string description, DateTime date, string category, string source)
            : base(amount, description, date, category)
        {
            Source = source;
        }

        public override string GetTransactionType()
        {
            return "Income";
        }

        public override string GetSummary()
        {
            return $"[INCOME] {Category} | ${Amount:F2} | {Date:dd/MM/yyyy} | {Description} (Source: {Source})";
        }
    }
}