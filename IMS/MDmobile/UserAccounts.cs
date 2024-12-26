using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MDmobile
{
    public partial class UserAccounts : Form
    {

        public string Functionalility;

        public UserAccounts()
        {
            InitializeComponent();
            btn_update.Visible = false;
        }

        public UserAccounts(string username,string email,string permissions)
        {
            InitializeComponent();
            
            txt_username.Text = username;
            txt_username.ReadOnly = true;
            txt_email.Text = email;


            string[] sep_values = permissions.Split(',');

            foreach (var item in sep_values)
            {
                if(item == "Product")
                {
                    Product.CheckState = CheckState.Checked;
                }
                else if (item == "Supplier")
                {
                    Supplier.CheckState = CheckState.Checked;
                }
                else if (item == "Customer")
                {
                    Customer.CheckState = CheckState.Checked;
                }
                else if (item == "Expenses")
                {
                    Expenses.CheckState = CheckState.Checked;
                }
                else if (item == "Billing")
                {
                    Billing.CheckState = CheckState.Checked;
                }
                else if (item == "Reports")
                {
                    Reports.CheckState = CheckState.Checked;
                }
            }

            btn_add_user.Visible = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool check_username(string username)
        {
            string datasource = "Data Source=MDdb.db;Version=3;";
            DataTable userTable = new DataTable();

            // Step 1: Retrieve data from the database
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                try
                {
                    con.Open();
                    // Update the query to check for both username and password
                    string selectQuery = "SELECT * FROM login WHERE username = @user";
                    using (SQLiteCommand selectCmd = new SQLiteCommand(selectQuery, con))
                    {
                        // Use parameters to prevent SQL injection
                        selectCmd.Parameters.AddWithValue("@user", username);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCmd))
                        {
                            adapter.Fill(userTable);
                        }
                    }

                    // Check if any rows were returned
                    return userTable.Rows.Count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false; // Return false in case of an error
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text) || txt_username.Text == "")
            {
                MessageBox.Show("Enter Username", "Input Required");
                return;
            }

            if (check_username(txt_username.Text))
            {
                MessageBox.Show("This username already exist\n         Try Another", "Invalid Input");
                txt_username.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_email.Text) || txt_email.Text == "")
            {
                MessageBox.Show("Enter Email Address", "Input Required");
                return;
            }

            string permissions = "";

            if (Product.Checked)
            {
                permissions += "1";
            }
            if (Supplier.Checked)
            {
                permissions += "2";
            }
            if (Customer.Checked)
            {
                permissions += "3";
            }
            if (Expenses.Checked)
            {
                permissions += "4";
            }
            if (Billing.Checked)
            {
                permissions += "5";
            }
            if (Reports.Checked)
            {
                permissions += "6";
            }

            if (string.IsNullOrEmpty(permissions))
            {
                MessageBox.Show("Select at least one permission", "Input Required");
                return;
            }
            string datasource = "Data Source=MDdb.db;Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                try
                {
                    // Corrected SQL query syntax
                    string query = "INSERT INTO login (username, password, email, permission) VALUES (@uname, @pass, @email, @permission)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open(); // Open the connection before executing the command

                        // Adding parameters
                        cmd.Parameters.AddWithValue("@uname", txt_username.Text);
                        cmd.Parameters.AddWithValue("@pass", "123"); // Default password
                        cmd.Parameters.AddWithValue("@email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@permission", permissions);

                        // Execute the command
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("New User Added Successfully...\n   Default Password : 123", "Successfully");
                            txt_username.Text = "";
                            txt_email.Text = "";
                        }
                    }
                }
                catch (Exception ex) // Catching the exception and providing feedback
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Ensure the connection is closed
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // Here the code for update
            if (string.IsNullOrEmpty(txt_email.Text) || txt_email.Text == "")
            {
                MessageBox.Show("Enter Email Address", "Input Required");
                return;
            }

            string permissions = "";

            if (Product.Checked)
            {
                permissions += "1";
            }
            if (Supplier.Checked)
            {
                permissions += "2";
            }
            if (Customer.Checked)
            {
                permissions += "3";
            }
            if (Expenses.Checked)
            {
                permissions += "4";
            }
            if (Billing.Checked)
            {
                permissions += "5";
            }
            if (Reports.Checked)
            {
                permissions += "6";
            }

            if (string.IsNullOrEmpty(permissions))
            {
                MessageBox.Show("Select at least one permission", "Input Required");
                return;
            }

            string datasource = "Data Source=MDdb.db;Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                try
                {
                    // SQL query for updating email and permission
                    string query = "UPDATE login SET email = @newEmail, permission = @newPermission WHERE username = @uname";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open(); // Open the connection before executing the command

                        // Adding parameters
                        cmd.Parameters.AddWithValue("@newEmail", txt_email.Text); // New email from the text box
                        cmd.Parameters.AddWithValue("@newPermission", permissions); // New permission value
                        cmd.Parameters.AddWithValue("@uname", txt_username.Text); // Username to match

                        // Execute the command
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("User information updated successfully.", "Successfully");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified username.");
                        }
                    }
                }
                catch (Exception ex) // Catching the exception and providing feedback
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Ensure the connection is closed
                }
            }
        }

        private void UserAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
