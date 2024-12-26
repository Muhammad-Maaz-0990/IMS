using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDmobile
{
    public partial class Main_User_Accounts : Form
    {
        public Main_User_Accounts()
        {
            InitializeComponent();
            LoadData("Admin");
        }

        private void Main_User_Accounts_Load(object sender, EventArgs e)
        {

        }

        private void LoadData(string pass)
        {
            string datasource = "Data Source=MDdb.db;Version=3;";
            DataTable userTable = new DataTable();

            // Step 1: Retrieve data from the database
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                try
                {
                    con.Open();
                    string selectQuery; // Retrieve all users

                    if(pass == "Admin")
                    {
                        selectQuery = $"SELECT * FROM login where username != '{pass}'";
                        textBox2.Text = "";
                    }
                    else
                    {
                        selectQuery = $"SELECT * FROM login where username = '{pass}'";
                    }

                    using (SQLiteCommand selectCmd = new SQLiteCommand(selectQuery, con))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCmd))
                        {
                            adapter.Fill(userTable);
                        }
                    }

                    // Step 2: Modify the DataTable
                    foreach (DataRow row in userTable.Rows)
                    {
                        string d_permission = row["permission"].ToString();
                        string c_permission = "";
                        int i = 0;
                        foreach (var item in d_permission)
                        {
                            if (i != 0)
                            {
                                c_permission += ",";
                            }
                            if (item == '1')
                            {
                                c_permission += "Product";
                            }
                            else if (item == '2')
                            {
                                c_permission += "Supplier";
                            }
                            else if (item == '3')
                            {
                                c_permission += "Customer";
                            }
                            else if (item == '4')
                            {
                                c_permission += "Expenses";
                            }
                            else if (item == '5')
                            {
                                c_permission += "Billing";
                            }
                            else if (item == '6')
                            {
                                c_permission += "Reports";
                            }
                            i++;
                        }

                        row["permission"] = c_permission; // Set a new permission value
                    }

                    userTable.Columns.Remove("password");

                    user_dtg.DataSource = userTable;
                    user_dtg.Columns["email"].Width = 100;
                    user_dtg.Columns["permission"].Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            UserAccounts newf = new UserAccounts();
            newf.ShowDialog();
            LoadData("Admin");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void user_dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (user_dtg.SelectedRows.Count != 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = user_dtg.SelectedRows[0];

                // Retrieve values from the selected row
                string username = selectedRow.Cells["username"].Value.ToString();

                string datasource = "Data Source=MDdb.db;Version=3;";
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    try
                    {
                        // Corrected SQL query syntax for deletion
                        string query = "DELETE FROM login WHERE username = @uname";

                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open(); // Open the connection before executing the command

                            // Adding parameters
                            cmd.Parameters.AddWithValue("@uname", username);

                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("User  Deleted Successfully.", "Successfully");
                            }
                            else
                            {
                                MessageBox.Show("No user found with the selected username.", "Deletion Failed");
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

                LoadData("Admin");
            }
            else
            {
                MessageBox.Show("Select any Record from list", "Input Required");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user_dtg.SelectedRows.Count != 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = user_dtg.SelectedRows[0];

                // Retrieve values from the selected row
                string username = selectedRow.Cells["username"].Value.ToString(); // Replace "username" with the actual column name
                string email = selectedRow.Cells["email"].Value.ToString(); // Replace "email" with the actual column name
                string permission = selectedRow.Cells["permission"].Value.ToString(); // Replace "permission" with the actual column name

                UserAccounts newf = new UserAccounts(username, email, permission);
                newf.ShowDialog();
                LoadData("Admin");
            }
            else
            {
                MessageBox.Show("Select any Record from list", "Input Required");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("Enetr any Username", "Input Required");
                return;
            }
            LoadData(textBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData("Admin");
        }
    }
}
