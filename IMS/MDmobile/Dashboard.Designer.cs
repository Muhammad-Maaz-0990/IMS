namespace MDmobile
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.remainingProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paidCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivedCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpensesPurposeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewExpenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paidBillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierBillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBillPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashVsExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childpanel = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.addProductToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.expensesToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.eToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.userAccountsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 6, 6, 6);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1039, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCompanyToolStripMenuItem,
            this.addProductToolStripMenuItem1,
            this.remainingProductsToolStripMenuItem});
            this.addProductToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.addProductToolStripMenuItem.Text = "Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // addCompanyToolStripMenuItem
            // 
            this.addCompanyToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCompanyToolStripMenuItem.Name = "addCompanyToolStripMenuItem";
            this.addCompanyToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.addCompanyToolStripMenuItem.Text = "Add Company";
            this.addCompanyToolStripMenuItem.Click += new System.EventHandler(this.addCompanyToolStripMenuItem_Click);
            // 
            // addProductToolStripMenuItem1
            // 
            this.addProductToolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductToolStripMenuItem1.Name = "addProductToolStripMenuItem1";
            this.addProductToolStripMenuItem1.Size = new System.Drawing.Size(221, 24);
            this.addProductToolStripMenuItem1.Text = "Add Product";
            this.addProductToolStripMenuItem1.Click += new System.EventHandler(this.addProductToolStripMenuItem1_Click);
            // 
            // remainingProductsToolStripMenuItem
            // 
            this.remainingProductsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingProductsToolStripMenuItem.Name = "remainingProductsToolStripMenuItem";
            this.remainingProductsToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.remainingProductsToolStripMenuItem.Text = "Remaining Products";
            this.remainingProductsToolStripMenuItem.Click += new System.EventHandler(this.remainingProductsToolStripMenuItem_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allSuppliersToolStripMenuItem,
            this.paidCashToolStripMenuItem});
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.supplierToolStripMenuItem.Text = "Supplier";
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.supplierToolStripMenuItem_Click);
            // 
            // allSuppliersToolStripMenuItem
            // 
            this.allSuppliersToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allSuppliersToolStripMenuItem.Name = "allSuppliersToolStripMenuItem";
            this.allSuppliersToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.allSuppliersToolStripMenuItem.Text = "All Suppliers";
            this.allSuppliersToolStripMenuItem.Click += new System.EventHandler(this.allSuppliersToolStripMenuItem_Click);
            // 
            // paidCashToolStripMenuItem
            // 
            this.paidCashToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidCashToolStripMenuItem.Name = "paidCashToolStripMenuItem";
            this.paidCashToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.paidCashToolStripMenuItem.Text = "Paid Cash";
            this.paidCashToolStripMenuItem.Click += new System.EventHandler(this.paidCashToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allCustomersToolStripMenuItem,
            this.receivedCashToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // allCustomersToolStripMenuItem
            // 
            this.allCustomersToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allCustomersToolStripMenuItem.Name = "allCustomersToolStripMenuItem";
            this.allCustomersToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.allCustomersToolStripMenuItem.Text = "All Customers";
            this.allCustomersToolStripMenuItem.Click += new System.EventHandler(this.allCustomersToolStripMenuItem_Click);
            // 
            // receivedCashToolStripMenuItem
            // 
            this.receivedCashToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedCashToolStripMenuItem.Name = "receivedCashToolStripMenuItem";
            this.receivedCashToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.receivedCashToolStripMenuItem.Text = "Received Cash";
            this.receivedCashToolStripMenuItem.Click += new System.EventHandler(this.receivedCashToolStripMenuItem_Click);
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExpensesPurposeToolStripMenuItem,
            this.addNewExpenseToolStripMenuItem});
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.expensesToolStripMenuItem.Text = "Expenses";
            // 
            // addExpensesPurposeToolStripMenuItem
            // 
            this.addExpensesPurposeToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExpensesPurposeToolStripMenuItem.Name = "addExpensesPurposeToolStripMenuItem";
            this.addExpensesPurposeToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.addExpensesPurposeToolStripMenuItem.Text = "Expense Purpose";
            this.addExpensesPurposeToolStripMenuItem.Click += new System.EventHandler(this.addExpensesPurposeToolStripMenuItem_Click);
            // 
            // addNewExpenseToolStripMenuItem
            // 
            this.addNewExpenseToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewExpenseToolStripMenuItem.Name = "addNewExpenseToolStripMenuItem";
            this.addNewExpenseToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.addNewExpenseToolStripMenuItem.Text = "All Expenses";
            this.addNewExpenseToolStripMenuItem.Click += new System.EventHandler(this.addNewExpenseToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paidBillingToolStripMenuItem,
            this.ledgerToolStripMenuItem,
            this.supplierBillingToolStripMenuItem,
            this.editBillPriceToolStripMenuItem,
            this.deleteBillToolStripMenuItem});
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.billingToolStripMenuItem.Text = "Billing";
            this.billingToolStripMenuItem.Click += new System.EventHandler(this.billingToolStripMenuItem_Click);
            // 
            // paidBillingToolStripMenuItem
            // 
            this.paidBillingToolStripMenuItem.Name = "paidBillingToolStripMenuItem";
            this.paidBillingToolStripMenuItem.ShortcutKeyDisplayString = "    Ctrl+C";
            this.paidBillingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.paidBillingToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.paidBillingToolStripMenuItem.Text = "Cash Billing";
            this.paidBillingToolStripMenuItem.Click += new System.EventHandler(this.paidBillingToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.ShortcutKeyDisplayString = "     Alt+C";
            this.ledgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.ledgerToolStripMenuItem.Text = "Customer Billing";
            this.ledgerToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // supplierBillingToolStripMenuItem
            // 
            this.supplierBillingToolStripMenuItem.Name = "supplierBillingToolStripMenuItem";
            this.supplierBillingToolStripMenuItem.ShortcutKeyDisplayString = "    Ctrl+S";
            this.supplierBillingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.supplierBillingToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.supplierBillingToolStripMenuItem.Text = "Supplier Billing";
            this.supplierBillingToolStripMenuItem.Click += new System.EventHandler(this.supplierBillingToolStripMenuItem_Click);
            // 
            // editBillPriceToolStripMenuItem
            // 
            this.editBillPriceToolStripMenuItem.Name = "editBillPriceToolStripMenuItem";
            this.editBillPriceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editBillPriceToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.editBillPriceToolStripMenuItem.Text = "Edit Bill Price";
            this.editBillPriceToolStripMenuItem.Click += new System.EventHandler(this.editBillPriceToolStripMenuItem_Click);
            // 
            // deleteBillToolStripMenuItem
            // 
            this.deleteBillToolStripMenuItem.Name = "deleteBillToolStripMenuItem";
            this.deleteBillToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteBillToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.deleteBillToolStripMenuItem.Text = "Delete Bill";
            this.deleteBillToolStripMenuItem.Click += new System.EventHandler(this.deleteBillToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleReportToolStripMenuItem,
            this.customerLedgerToolStripMenuItem,
            this.supplierLedgerToolStripMenuItem,
            this.cashVsExpensesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // saleReportToolStripMenuItem
            // 
            this.saleReportToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleReportToolStripMenuItem.Name = "saleReportToolStripMenuItem";
            this.saleReportToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.saleReportToolStripMenuItem.Text = "Sale Report";
            this.saleReportToolStripMenuItem.Click += new System.EventHandler(this.saleReportToolStripMenuItem_Click);
            // 
            // customerLedgerToolStripMenuItem
            // 
            this.customerLedgerToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLedgerToolStripMenuItem.Name = "customerLedgerToolStripMenuItem";
            this.customerLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.customerLedgerToolStripMenuItem.Text = "Customer Ledger";
            this.customerLedgerToolStripMenuItem.Click += new System.EventHandler(this.customerLedgerToolStripMenuItem_Click);
            // 
            // supplierLedgerToolStripMenuItem
            // 
            this.supplierLedgerToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierLedgerToolStripMenuItem.Name = "supplierLedgerToolStripMenuItem";
            this.supplierLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.supplierLedgerToolStripMenuItem.Text = "Supplier Ledger";
            this.supplierLedgerToolStripMenuItem.Click += new System.EventHandler(this.supplierLedgerToolStripMenuItem_Click);
            // 
            // cashVsExpensesToolStripMenuItem
            // 
            this.cashVsExpensesToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashVsExpensesToolStripMenuItem.Name = "cashVsExpensesToolStripMenuItem";
            this.cashVsExpensesToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.cashVsExpensesToolStripMenuItem.Text = "Sale Vs Expenses";
            this.cashVsExpensesToolStripMenuItem.Click += new System.EventHandler(this.cashVsExpensesToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eToolStripMenuItem.Image")));
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.eToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 24);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 24);
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // userAccountsToolStripMenuItem
            // 
            this.userAccountsToolStripMenuItem.Name = "userAccountsToolStripMenuItem";
            this.userAccountsToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.userAccountsToolStripMenuItem.Text = "UserAccounts";
            this.userAccountsToolStripMenuItem.Click += new System.EventHandler(this.userAccountsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // childpanel
            // 
            this.childpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childpanel.Location = new System.Drawing.Point(0, 36);
            this.childpanel.Name = "childpanel";
            this.childpanel.Size = new System.Drawing.Size(1039, 461);
            this.childpanel.TabIndex = 1;
            this.childpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.childpanel_Paint);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1039, 497);
            this.Controls.Add(this.childpanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Madni Traders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem remainingProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel childpanel;
        private System.Windows.Forms.ToolStripMenuItem addCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paidBillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpensesPurposeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewExpenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierBillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivedCashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paidCashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashVsExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBillPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ToolStripMenuItem userAccountsToolStripMenuItem;
    }
}