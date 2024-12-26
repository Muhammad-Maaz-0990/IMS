using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MDmobile
{
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";

        private void change_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.Username;
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    try
                    {
                        String query = "UPDATE login SET password = '" + textBox2.Text + "' WHERE username = '" + textBox1.Text + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();

                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Password updated Successfully...");
                                textBox2.Clear();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Occur");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                
               
            }
            else
            {
                MessageBox.Show("Enter Your New Password","Input Required");
                textBox2.Focus();
            }
        }
    }
}
