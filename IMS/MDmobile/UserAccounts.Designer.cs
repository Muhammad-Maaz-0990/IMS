namespace MDmobile
{
    partial class UserAccounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccounts));
            this.txt_username = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.Product = new System.Windows.Forms.CheckBox();
            this.Supplier = new System.Windows.Forms.CheckBox();
            this.Customer = new System.Windows.Forms.CheckBox();
            this.Reports = new System.Windows.Forms.CheckBox();
            this.Billing = new System.Windows.Forms.CheckBox();
            this.Expenses = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(115, 32);
            this.txt_username.Margin = new System.Windows.Forms.Padding(2);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(122, 20);
            this.txt_username.TabIndex = 0;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(49, 34);
            this.lbl_username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(63, 13);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "Username";
            // 
            // btn_add_user
            // 
            this.btn_add_user.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_add_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_user.ForeColor = System.Drawing.Color.White;
            this.btn_add_user.Location = new System.Drawing.Point(92, 200);
            this.btn_add_user.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(103, 32);
            this.btn_add_user.TabIndex = 2;
            this.btn_add_user.Text = "Add User";
            this.btn_add_user.UseVisualStyleBackColor = false;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(49, 68);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(37, 13);
            this.lbl_Email.TabIndex = 4;
            this.lbl_Email.Text = "Email";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(115, 65);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(122, 20);
            this.txt_email.TabIndex = 3;
            // 
            // Product
            // 
            this.Product.AutoSize = true;
            this.Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product.Location = new System.Drawing.Point(27, 17);
            this.Product.Margin = new System.Windows.Forms.Padding(2);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(63, 17);
            this.Product.TabIndex = 5;
            this.Product.Text = "Product";
            this.Product.UseVisualStyleBackColor = true;
            this.Product.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Supplier
            // 
            this.Supplier.AutoSize = true;
            this.Supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier.Location = new System.Drawing.Point(27, 38);
            this.Supplier.Margin = new System.Windows.Forms.Padding(2);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(64, 17);
            this.Supplier.TabIndex = 6;
            this.Supplier.Text = "Supplier";
            this.Supplier.UseVisualStyleBackColor = true;
            // 
            // Customer
            // 
            this.Customer.AutoSize = true;
            this.Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.Location = new System.Drawing.Point(27, 59);
            this.Customer.Margin = new System.Windows.Forms.Padding(2);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(70, 17);
            this.Customer.TabIndex = 7;
            this.Customer.Text = "Customer";
            this.Customer.UseVisualStyleBackColor = true;
            // 
            // Reports
            // 
            this.Reports.AutoSize = true;
            this.Reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports.Location = new System.Drawing.Point(112, 59);
            this.Reports.Margin = new System.Windows.Forms.Padding(2);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(63, 17);
            this.Reports.TabIndex = 10;
            this.Reports.Text = "Reports";
            this.Reports.UseVisualStyleBackColor = true;
            // 
            // Billing
            // 
            this.Billing.AutoSize = true;
            this.Billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Billing.Location = new System.Drawing.Point(112, 38);
            this.Billing.Margin = new System.Windows.Forms.Padding(2);
            this.Billing.Name = "Billing";
            this.Billing.Size = new System.Drawing.Size(53, 17);
            this.Billing.TabIndex = 9;
            this.Billing.Text = "Billing";
            this.Billing.UseVisualStyleBackColor = true;
            // 
            // Expenses
            // 
            this.Expenses.AutoSize = true;
            this.Expenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Expenses.Location = new System.Drawing.Point(112, 17);
            this.Expenses.Margin = new System.Windows.Forms.Padding(2);
            this.Expenses.Name = "Expenses";
            this.Expenses.Size = new System.Drawing.Size(72, 17);
            this.Expenses.TabIndex = 8;
            this.Expenses.Text = "Expenses";
            this.Expenses.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Product);
            this.groupBox1.Controls.Add(this.Reports);
            this.groupBox1.Controls.Add(this.Supplier);
            this.groupBox1.Controls.Add(this.Billing);
            this.groupBox1.Controls.Add(this.Customer);
            this.groupBox1.Controls.Add(this.Expenses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(51, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(184, 81);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissions";
            // 
            // btn_update
            // 
            this.btn_update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_update.BackColor = System.Drawing.Color.Firebrick;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_update.Location = new System.Drawing.Point(93, 200);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(102, 29);
            this.btn_update.TabIndex = 13;
            this.btn_update.Text = "Update";
            this.btn_update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // UserAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 255);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.btn_add_user);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txt_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "UserAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserAccounts";
            this.Load += new System.EventHandler(this.UserAccounts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Button btn_add_user;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.CheckBox Product;
        private System.Windows.Forms.CheckBox Supplier;
        private System.Windows.Forms.CheckBox Customer;
        private System.Windows.Forms.CheckBox Reports;
        private System.Windows.Forms.CheckBox Billing;
        private System.Windows.Forms.CheckBox Expenses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_update;
    }
}