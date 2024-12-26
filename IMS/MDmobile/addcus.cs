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
    public partial class addcus : Form
    {
        public addcus()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static int id;
        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(ID) From customer";
                using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                {
                    con.Open();

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    con.Close();
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                    textBox3.Text = (Convert.ToInt32(dt.Rows[0][0]) + 1).ToString();
                else
                    textBox3.Text = "1";
            }
            else
                textBox3.Text = "1";
        }

        public void get()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM customer ORDER BY ID ASC";
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
                data1.Rows.Add();
                data1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
            }
        }

        private void addcus_Load(object sender, EventArgs e)
        {
            get();
            getid();
            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox1.Text!="")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO customer ([ID],[name],[remain]) VALUES (@id,@cname,@re)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", textBox3.Text);
                        cmd.Parameters.AddWithValue("@cname", textBox5.Text);
                        cmd.Parameters.AddWithValue("@re", textBox1.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Customer Added Successfully...");
                textBox5.Text =textBox1.Text= "";
                getid();
            }
            else
                MessageBox.Show("Please Enter Customer Details..!!");
            get();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                String cname = data1.Rows[row].Cells[1].Value.ToString();


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM customer WHERE ID='" + id + "' and name = '" + cname + "' ";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                data1.Rows.RemoveAt(row);
                MessageBox.Show(cname + " has been deleted from your record.");
                get();
            }
            else
                MessageBox.Show("Please add a customer first...!!");
        
        }

        

        

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                float pp = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                String name = data1.Rows[row].Cells[1].Value.ToString();
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query = "UPDATE customer SET remain='" + pp + "' WHERE ID = '" + id + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    MessageBox.Show(name + " has been updated in your record.\nRemaining Balance is " + pp);
                    get();


            }
        }

        private void data1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(column3_keypress);
            if(data1.CurrentCell.ColumnIndex==2)
            {
                TextBox tb = e.Control as TextBox;
                if(tb!=null)
                {
                    tb.KeyPress += new KeyPressEventHandler(column3_keypress);
                }
            }
        }

        private void column3_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (textBox4.Text != "")
            {
                qry = "SELECT * FROM customer WHERE name LIKE '%" + textBox4.Text + "%' ORDER BY name ASC";
            }
            if (qry != "")
            {
                data1.Rows.Clear();
                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
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
                    data1.Rows.Add();
                    data1.Rows[i].Cells[0].Value = dt.Rows[i][0];
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                }
            }
            else
                MessageBox.Show("Please Enter Customer name to search !!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            get();
        }

    }
}
