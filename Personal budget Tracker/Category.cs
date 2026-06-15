using System;

namespace Personal_budget_Tracker.Models
{
    public class Category
    {
        private int _id;
        private string _name;
        private string _type;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Category name cannot be empty.");
                _name = value.Trim();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (value != "Income" && value != "Expense")
                    throw new ArgumentException("Type must be Income or Expense.");
                _type = value;
            }
        }

        public Category() { }

        public Category(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name} ({Type})";
        }
    }
}