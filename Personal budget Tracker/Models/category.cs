using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Personal_budget_Tracker.Models;

namespace Personal_budget_Tracker
{
    public class CategoryForm : Form
    {
        private List<Category> _categories;
        public List<Category> UpdatedCategories { get { return _categories; } }
        private ListBox lstCategories;
        private TextBox txtName;
        private ComboBox cmbType;
        private Button btnAdd, btnDelete, btnClose;

        public CategoryForm(List<Category> categories)
        {
            _categories = new List<Category>(categories);
            InitializeForm();
            RefreshList();
        }

        private void InitializeForm()
        {
            this.Text = "Manage Categories";
            this.ClientSize = new System.Drawing.Size(380, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            var lblName = new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 25) };
            var lblType = new Label { Text = "Type:", Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(80, 25) };
            txtName = new TextBox { Location = new System.Drawing.Point(110, 17), Size = new System.Drawing.Size(200, 25) };
            cmbType = new ComboBox { Location = new System.Drawing.Point(110, 57), Size = new System.Drawing.Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new string[] { "Income", "Expense" });
            cmbType.SelectedIndex = 0;
            btnAdd = new Button { Text = "Add Category", Location = new System.Drawing.Point(110, 100), Size = new System.Drawing.Size(120, 30), BackColor = System.Drawing.Color.SteelBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += BtnAdd_Click;
            lstCategories = new ListBox { Location = new System.Drawing.Point(20, 145), Size = new System.Drawing.Size(340, 180) };
            btnDelete = new Button { Text = "Delete Selected", Location = new System.Drawing.Point(20, 340), Size = new System.Drawing.Size(130, 30), BackColor = System.Drawing.Color.Crimson, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;
            btnClose = new Button { Text = "Close", Location = new System.Drawing.Point(230, 340), Size = new System.Drawing.Size(90, 30), BackColor = System.Drawing.Color.Gray, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(lblName); this.Controls.Add(lblType); this.Controls.Add(txtName);
            this.Controls.Add(cmbType); this.Controls.Add(btnAdd); this.Controls.Add(lstCategories);
            this.Controls.Add(btnDelete); this.Controls.Add(btnClose);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text)) throw new Exception("Please enter a category name.");
                _categories.Add(new Category(txtName.Text.Trim(), cmbType.SelectedItem.ToString()));
                txtName.Clear();
                RefreshList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex == -1) { MessageBox.Show("Please select a category.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { _categories.RemoveAt(lstCategories.SelectedIndex); RefreshList(); }
        }

        private void RefreshList()
        {
            lstCategories.Items.Clear();
            foreach (var cat in _categories) lstCategories.Items.Add(cat.ToString());
        }
    }
}
