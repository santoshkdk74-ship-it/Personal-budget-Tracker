using System;
using System.Collections.Generic;

namespace Personal_budget_Tracker.Models
{
    public class BudgetManager
    {
        private List<BaseTransaction> _transactions;

        public BudgetManager()
        {
            _transactions = new List<BaseTransaction>();
        }

        public void AddTransaction(BaseTransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void SetTransactions(List<BaseTransaction> transactions)
        {
            _transactions = transactions;
        }

        public List<BaseTransaction> GetAllTransactions()
        {
            return _transactions;
        }

        public decimal GetTotalIncome()
        {
            decimal total = 0;
            foreach (var t in _transactions)
                if (t.GetTransactionType() == "Income")
                    total += t.Amount;
            return total;
        }

        public decimal GetTotalExpenses()
        {
            decimal total = 0;
            foreach (var t in _transactions)
                if (t.GetTransactionType() == "Expense")
                    total += t.Amount;
            return total;
        }

        public decimal GetBalance()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }

        public List<BaseTransaction> GetByCategory(string category)
        {
            return _transactions.FindAll(t => t.Category == category);
        }
    }
}