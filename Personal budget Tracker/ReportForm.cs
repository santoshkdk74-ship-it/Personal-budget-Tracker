using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Personal_budget_Tracker.Models;

namespace Personal_budget_Tracker
{
    public partial class ReportForm : Form
    {
        private BudgetManager _budgetManager;

        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ListBox lstReport;
        private System.Windows.Forms.Button btnClose;

        public ReportForm(BudgetManager budgetManager)
        {
            _budgetManager = budgetManager;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lstReport = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTotalIncome.Location = new System.Drawing.Point(20, 20);
            this.lblTotalIncome.Size = new System.Drawing.Size(400, 30);
            this.lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalIncome.ForeColor = System.Drawing.Color.Green;
            this.lblTotalIncome.Text = "Total Income: $0.00";

            this.lblTotalExpenses.Location = new System.Drawing.Point(20, 55);
            this.lblTotalExpenses.Size = new System.Drawing.Size(400, 30);
            this.lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExpenses.Text = "Total Expenses: $0.00";

            this.lblBalance.Location = new System.Drawing.Point(20, 90);
            this.lblBalance.Size = new System.Drawing.Size(400, 30);
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Text = "Balance: $0.00";

            this.lstReport.Location = new System.Drawing.Point(20, 130);
            this.lstReport.Size = new System.Drawing.Size(540, 320);
            this.lstReport.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.btnClose.Text = "Close";
            this.btnClose.Location = new System.Drawing.Point(230, 465);
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new System.Drawing.Size(580, 520);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.lblTotalExpenses);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lstReport);
            this.Controls.Add(this.btnClose);
            this.Text = "Budget Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                decimal income = _budgetManager.GetTotalIncome();
                decimal expenses = _budgetManager.GetTotalExpenses();
                decimal balance = _budgetManager.GetBalance();

                lblTotalIncome.Text = "Total Income: $" + income.ToString("F2");
                lblTotalExpenses.Text = "Total Expenses: $" + expenses.ToString("F2");
                lblBalance.Text = "Balance: $" + balance.ToString("F2");
                lblBalance.ForeColor = balance >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                lstReport.Items.Clear();
                lstReport.Items.Add("=== ALL TRANSACTIONS ===");
                foreach (var t in _budgetManager.GetAllTransactions())
                    lstReport.Items.Add(t.GetSummary());

                lstReport.Items.Add("");
                lstReport.Items.Add("=== SUMMARY BY CATEGORY ===");
                var categories = new Dictionary<string, decimal>();
                foreach (var t in _budgetManager.GetAllTransactions())
                {
                    if (!categories.ContainsKey(t.Category))
                        categories[t.Category] = 0;
                    categories[t.Category] += t.GetTransactionType() == "Income" ? t.Amount : -t.Amount;
                }
                foreach (var kvp in categories)
                    lstReport.Items.Add(kvp.Key + ": $" + kvp.Value.ToString("F2"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}