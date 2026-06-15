using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Personal_budget_Tracker.Models;

namespace Personal_budget_Tracker
{
    public partial class AddTransactionForm : Form
    {
        private List<Category> _categories;
        public BaseTransaction NewTransaction { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public AddTransactionForm(List<Category> categories)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            InitializeComponent();
            _categories = categories;
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.Add("Income");
            cmbType.Items.Add("Expense");
            cmbType.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isIncome = cmbType.SelectedItem?.ToString() == "Income";
            lblExtra.Text = isIncome ? "Source:" : "Recurring:";
            txtSource.Visible = isIncome;
            chkRecurring.Visible = !isIncome;

            cmbCategory.Items.Clear();
            string selectedType = cmbType.SelectedItem?.ToString();
            foreach (var cat in _categories)
                if (cat.Type == selectedType)
                    cmbCategory.Items.Add(cat.Name);

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedIndex == -1)
                    throw new Exception("Please select a transaction type.");

                if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
                    throw new Exception("Please enter a valid amount greater than zero.");

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    throw new Exception("Please enter a description.");

                if (cmbCategory.SelectedIndex == -1)
                    throw new Exception("Please select a category.");

                string type = cmbType.SelectedItem.ToString();
                string description = txtDescription.Text.Trim();
                string category = cmbCategory.SelectedItem.ToString();
                DateTime date = dtpDate.Value;

                if (type == "Income")
                {
                    string source = txtSource.Text.Trim();
                    if (string.IsNullOrWhiteSpace(source)) source = "Unknown";
                    NewTransaction = new Income(amount, description, date, category, source);
                }
                else
                {
                    bool isRecurring = chkRecurring.Checked;
                    NewTransaction = new Expense(amount, description, date, category, isRecurring);
                }

                NewTransaction.Id = new Random().Next(1000, 9999);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
