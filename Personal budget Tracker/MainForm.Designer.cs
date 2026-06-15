namespace Personal_budget_Tracker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lstTransactions = new System.Windows.Forms.ListBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();

            var lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "Personal Budget Tracker";
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Size = new System.Drawing.Size(560, 35);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            var lblIncomeHeader = new System.Windows.Forms.Label();
            lblIncomeHeader.Text = "Total Income:";
            lblIncomeHeader.Location = new System.Drawing.Point(20, 65);
            lblIncomeHeader.Size = new System.Drawing.Size(120, 25);
            lblIncomeHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblTotalIncome.Text = "$0.00";
            this.lblTotalIncome.Location = new System.Drawing.Point(150, 65);
            this.lblTotalIncome.Size = new System.Drawing.Size(120, 25);
            this.lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalIncome.ForeColor = System.Drawing.Color.Green;

            var lblExpensesHeader = new System.Windows.Forms.Label();
            lblExpensesHeader.Text = "Total Expenses:";
            lblExpensesHeader.Location = new System.Drawing.Point(300, 65);
            lblExpensesHeader.Size = new System.Drawing.Size(130, 25);
            lblExpensesHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblTotalExpenses.Text = "$0.00";
            this.lblTotalExpenses.Location = new System.Drawing.Point(440, 65);
            this.lblTotalExpenses.Size = new System.Drawing.Size(120, 25);
            this.lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.Red;

            var lblBalanceHeader = new System.Windows.Forms.Label();
            lblBalanceHeader.Text = "Balance:";
            lblBalanceHeader.Location = new System.Drawing.Point(20, 100);
            lblBalanceHeader.Size = new System.Drawing.Size(120, 25);
            lblBalanceHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblBalance.Text = "$0.00";
            this.lblBalance.Location = new System.Drawing.Point(150, 100);
            this.lblBalance.Size = new System.Drawing.Size(200, 25);
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Green;

            var lblTransHeader = new System.Windows.Forms.Label();
            lblTransHeader.Text = "Transactions:";
            lblTransHeader.Location = new System.Drawing.Point(20, 140);
            lblTransHeader.Size = new System.Drawing.Size(150, 25);
            lblTransHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lstTransactions.Location = new System.Drawing.Point(20, 170);
            this.lstTransactions.Size = new System.Drawing.Size(560, 280);
            this.lstTransactions.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.Location = new System.Drawing.Point(20, 465);
            this.btnAddTransaction.Size = new System.Drawing.Size(130, 35);
            this.btnAddTransaction.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(165, 465);
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnCategories.Text = "Categories";
            this.btnCategories.Location = new System.Drawing.Point(270, 465);
            this.btnCategories.Size = new System.Drawing.Size(100, 35);
            this.btnCategories.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);

            this.btnReport.Text = "View Report";
            this.btnReport.Location = new System.Drawing.Point(385, 465);
            this.btnReport.Size = new System.Drawing.Size(100, 35);
            this.btnReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblIncomeHeader);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(lblExpensesHeader);
            this.Controls.Add(this.lblTotalExpenses);
            this.Controls.Add(lblBalanceHeader);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(lblTransHeader);
            this.Controls.Add(this.lstTransactions);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.btnReport);
            this.Text = "Personal Budget Tracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ListBox lstTransactions;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnReport;
    }
}