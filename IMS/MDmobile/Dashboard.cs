using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDmobile
{
    public partial class Dashboard : Form
    {
        string u_permission;
        public Dashboard(string permission)
        {
            InitializeComponent();
            u_permission = permission;
            openform(new Home());
        }
        private Form activeform = null;
        private void openform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            childpanel.Controls.Add(childform);
            childpanel.Tag = childform;
            childform.BringToFront();
            childform.Show();

            if(u_permission != "Admin")
            {
                addProductToolStripMenuItem.Enabled = false;
                customerToolStripMenuItem.Enabled = false;
                expensesToolStripMenuItem.Enabled = false;
                billingToolStripMenuItem.Enabled = false;
                reportsToolStripMenuItem.Enabled = false;
                userAccountsToolStripMenuItem.Enabled = false;
                supplierToolStripMenuItem.Enabled = false;


                foreach(var item in u_permission)
                {
                    if(item =='1')
                    {
                        addProductToolStripMenuItem.Enabled = true;
                    }
                    else if (item == '2')
                    {
                        supplierToolStripMenuItem.Enabled = true;
                    }
                    else if (item == '3')
                    {
                        customerToolStripMenuItem.Enabled = true;
                    }
                    else if (item == '4')
                    {
                        expensesToolStripMenuItem.Enabled = true;
                    }
                    else if (item == '5')
                    {
                        billingToolStripMenuItem.Enabled = true;
                    }
                    else if (item == '6')
                    {
                        reportsToolStripMenuItem.Enabled = true;
                    }
                }


            }

            

        }
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openform(new addproduct());
        }

        private void remainingProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new allproducts());
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.f1.Show();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //openform(new Home());
            menuStrip1.Focus();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Program.f1.Visible)
                Application.Exit();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new change());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new Home());
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addcompany ob = new addcompany();
            ob.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new salereport());
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void paidBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new Billing());
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new cusbill());
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new cusledgercs());
        }

        private void addExpensesPurposeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addpurpose ob = new addpurpose();
            ob.ShowDialog();
        }

        private void addNewExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new addexp());
        }


        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void supplierBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new addpitems());
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void receivedCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new cuscash());
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new addcus());
        }

        private void allSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new addsup());
        }

        private void paidCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new supcash());
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new supledger());
        }

        private void cashVsExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new salevsexp());
        }

        private void editBillPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new editbill());
        }

        private void deleteBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new DeleteBill());
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void childpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openform(new Main_User_Accounts());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }
    }
}
