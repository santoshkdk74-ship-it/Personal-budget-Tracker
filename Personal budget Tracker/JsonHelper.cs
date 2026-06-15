using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Personal_budget_Tracker.Models;

namespace Personal_budget_Tracker
{
    public class JsonHelper
    {
        private string _transactionsFile = "transactions.json";
        private string _categoriesFile = "categories.json";

        public void SaveTransactions(List<BaseTransaction> transactions)
        {
            try
            {
                var dataList = new List<TransactionData>();
                foreach (var t in transactions)
                {
                    var data = new TransactionData
                    {
                        Id = t.Id,
                        Type = t.GetTransactionType(),
                        Amount = t.Amount,
                        Description = t.Description,
                        Date = t.Date,
                        Category = t.Category
                    };
                    if (t is Income inc) data.Extra = inc.Source;
                    if (t is Expense exp) data.Extra = exp.IsRecurring.ToString();
                    dataList.Add(data);
                }
                string json = JsonSerializer.Serialize(dataList,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_transactionsFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save transactions: " + ex.Message);
            }
        }

        public List<BaseTransaction> LoadTransactions()
        {
            var list = new List<BaseTransaction>();
            try
            {
                if (!File.Exists(_transactionsFile)) return list;
                string json = File.ReadAllText(_transactionsFile);
                var dataList = JsonSerializer.Deserialize<List<TransactionData>>(json);
                if (dataList == null) return list;

                foreach (var data in dataList)
                {
                    BaseTransaction t;
                    if (data.Type == "Income")
                        t = new Income(data.Amount, data.Description, data.Date, data.Category, data.Extra ?? "");
                    else
                        t = new Expense(data.Amount, data.Description, data.Date, data.Category,
                            bool.Parse(string.IsNullOrEmpty(data.Extra) ? "False" : data.Extra));
                    t.Id = data.Id;
                    list.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load transactions: " + ex.Message);
            }
            return list;
        }

        public void SaveCategories(List<Category> categories)
        {
            try
            {
                string json = JsonSerializer.Serialize(categories,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_categoriesFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save categories: " + ex.Message);
            }
        }

        public List<Category> LoadCategories()
        {
            var list = new List<Category>();
            try
            {
                if (!File.Exists(_categoriesFile)) return list;
                string json = File.ReadAllText(_categoriesFile);
                list = JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load categories: " + ex.Message);
            }
            return list;
        }
    }

    public class TransactionData
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Extra { get; set; }
    }
}