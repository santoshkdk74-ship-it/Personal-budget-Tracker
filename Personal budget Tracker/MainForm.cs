using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Personal_budget_Tracker.Models;

namespace Personal_budget_Tracker
{
    public partial class MainForm : Form
    {
        private BudgetManager _budgetManager;
        private JsonHelper _jsonHelper;
        private List<Category> _categories;

        public MainForm()
        {
            InitializeComponent();
            _budgetManager = new BudgetManager();
            _jsonHelper = new JsonHelper();
            _categories = new List<Category>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var transactions = _jsonHelper.LoadTransactions();
                _budgetManager.SetTransactions(transactions);
                _categories = _jsonHelper.LoadCategories();

                if (_categories.Count == 0)
                {
                    _categories.Add(new Category("Salary", "Income"));
                    _categories.Add(new Category("Freelance", "Income"));
                    _categories.Add(new Category("Food", "Expense"));
                    _categories.Add(new Category("Rent", "Expense"));
                    _categories.Add(new Category("Transport", "Expense"));
                    _categories.Add(new Category("Entertainment", "Expense"));
                    _jsonHelper.SaveCategories(_categories);
                }
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDashboard()
        {
            try
            {
                lblTotalIncome.Text = "$" + _budgetManager.GetTotalIncome().ToString("F2");
                lblTotalExpenses.Text = "$" + _budgetManager.GetTotalExpenses().ToString("F2");
                lblBalance.Text = "$" + _budgetManager.GetBalance().ToString("F2");
                lblBalance.ForeColor = _budgetManager.GetBalance() >= 0
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;

                lstTransactions.Items.Clear();
                foreach (var t in _budgetManager.GetAllTransactions())
                    lstTransactions.Items.Add(t.GetSummary());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new AddTransactionForm(_categories);
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    _budgetManager.AddTransaction(addForm.NewTransaction);
                    _jsonHelper.SaveTransactions(_budgetManager.GetAllTransactions());
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTransactions.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a transaction to delete.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Delete this transaction?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var all = _budgetManager.GetAllTransactions();
                    all.RemoveAt(lstTransactions.SelectedIndex);
                    _budgetManager.SetTransactions(all);
                    _jsonHelper.SaveTransactions(all);
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                var catForm = new CategoryForm(_categories);
                catForm.ShowDialog();
                _categories = catForm.UpdatedCategories;
                _jsonHelper.SaveCategories(_categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                var reportForm = new ReportForm(_budgetManager);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}