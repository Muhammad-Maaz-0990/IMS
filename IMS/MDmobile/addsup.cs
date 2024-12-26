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
    public partial class addsup : Form
    {
        public addsup()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static int id;
        private void addsup_Load(object sender, EventArgs e)
        {
            getid();
            loaddata();
        }
        public void loaddata()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM supplier ORDER BY Name ASC";
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
        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(ID) From supplier";
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO supplier ([ID],[Name],[remain]) VALUES (@id,@cname,@re)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                        cmd.Parameters.AddWithValue("@re", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Supplier Added Successfully...");
                textBox1.Text = textBox2.Text = "";
                getid();
                loaddata();
            }
            else
                MessageBox.Show("Please Enter Supplier Details..!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (textBox4.Text != "")
            {
                qry = "SELECT * FROM supplier WHERE Name LIKE '%" + textBox4.Text + "%' ORDER BY Name ASC";
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
                MessageBox.Show("Please Enter Supplier name to search !!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                float sp = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE supplier SET remain='" + sp + "' WHERE ID='" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Updated Succesfully.");
                loaddata();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM supplier WHERE ID = '" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                data1.Rows.RemoveAt(row);
                MessageBox.Show("Deleted Successfully.");
                loaddata();
            }
        }

        private void data1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(column3_keypress);
            if (data1.CurrentCell.ColumnIndex == 2 || data1.CurrentCell.ColumnIndex == 3 || data1.CurrentCell.ColumnIndex == 4 || data1.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
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
    }
}
