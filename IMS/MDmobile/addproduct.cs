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
    public partial class addproduct : Form
    {
        public addproduct()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && comboBox1.Text!="")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO product ([cname],[name],[purchaseprice],[saleprice],[total],[remaining]) VALUES (@cname,@name,@pprice,@sprice,@total,@remain)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@cname", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pprice", textBox2.Text);
                        cmd.Parameters.AddWithValue("@sprice", textBox3.Text);
                        cmd.Parameters.AddWithValue("@total", textBox4.Text);
                        cmd.Parameters.AddWithValue("@remain", textBox4.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Product Added Successfully...");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                comboBox1.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Please enter all Details..!!");
        }

        private void addproduct_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT cname FROM company ORDER BY cname ASC";
                using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                {
                    con.Open();

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    con.Close();
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

    }
}
