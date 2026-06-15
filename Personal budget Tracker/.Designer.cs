namespace Personal_budget_Tracker
{
    partial class AddTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkRecurring = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExtra = new System.Windows.Forms.Label();
            this.SuspendLayout();

            var lblType = new System.Windows.Forms.Label();
            lblType.Text = "Type:";
            lblType.Location = new System.Drawing.Point(20, 20);
            lblType.Size = new System.Drawing.Size(100, 25);

            var lblAmount = new System.Windows.Forms.Label();
            lblAmount.Text = "Amount ($):";
            lblAmount.Location = new System.Drawing.Point(20, 60);
            lblAmount.Size = new System.Drawing.Size(100, 25);

            var lblDesc = new System.Windows.Forms.Label();
            lblDesc.Text = "Description:";
            lblDesc.Location = new System.Drawing.Point(20, 100);
            lblDesc.Size = new System.Drawing.Size(100, 25);

            var lblDate = new System.Windows.Forms.Label();
            lblDate.Text = "Date:";
            lblDate.Location = new System.Drawing.Point(20, 140);
            lblDate.Size = new System.Drawing.Size(100, 25);

            var lblCat = new System.Windows.Forms.Label();
            lblCat.Text = "Category:";
            lblCat.Location = new System.Drawing.Point(20, 180);
            lblCat.Size = new System.Drawing.Size(100, 25);

            this.lblExtra.Text = "Source:";
            this.lblExtra.Location = new System.Drawing.Point(20, 220);
            this.lblExtra.Size = new System.Drawing.Size(100, 25);

            this.cmbType.Location = new System.Drawing.Point(140, 17);
            this.cmbType.Size = new System.Drawing.Size(200, 25);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);

            this.txtAmount.Location = new System.Drawing.Point(140, 57);
            this.txtAmount.Size = new System.Drawing.Size(200, 25);

            this.txtDescription.Location = new System.Drawing.Point(140, 97);
            this.txtDescription.Size = new System.Drawing.Size(200, 25);

            this.dtpDate.Location = new System.Drawing.Point(140, 137);
            this.dtpDate.Size = new System.Drawing.Size(200, 25);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.cmbCategory.Location = new System.Drawing.Point(140, 177);
            this.cmbCategory.Size = new System.Drawing.Size(200, 25);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.txtSource.Location = new System.Drawing.Point(140, 217);
            this.txtSource.Size = new System.Drawing.Size(200, 25);
            this.txtSource.Visible = true;

            this.chkRecurring.Text = "Yes";
            this.chkRecurring.Location = new System.Drawing.Point(140, 217);
            this.chkRecurring.Size = new System.Drawing.Size(60, 25);
            this.chkRecurring.Visible = false;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(140, 270);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(250, 270);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(380, 330);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblType, lblAmount, lblDesc, lblDate, lblCat, this.lblExtra,
                this.cmbType, this.txtAmount, this.txtDescription,
                this.dtpDate, this.cmbCategory, this.txtSource,
                this.chkRecurring, this.btnSave, this.btnCancel
            });
            this.Text = "Add Transaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddTransactionForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkRecurring;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExtra;
    }
}