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
    public partial class addexp : Form
    {
        public addexp()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static int id;
        private void addexp_Load(object sender, EventArgs e)
        {
            getid();
            getpurpose();
            getp();
        }

        public void getp()
        {
            comboBox2.Items.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT Purpose FROM expcate ORDER BY Purpose ASC";
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
                comboBox2.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(ID) From expenses";
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

        public void getpurpose()
        {
            comboBox1.Items.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT Purpose FROM expcate ORDER BY Purpose ASC";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && Convert.ToInt32(textBox2.Text)!=0)
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO expenses ([ID],[Date],[Purpose],[Amount],[reason]) VALUES (@id,@date,@cname,@re,@reas)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", textBox3.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@cname", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@re", textBox2.Text);
                        cmd.Parameters.AddWithValue("@reas", textBox1.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Expense Added Successfully...");
                comboBox1.Text = textBox2.Text =textBox1.Text= "";
                getid();
            }
            else
                MessageBox.Show("Please Enter Expense Details..!!");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                string qry = "";
                qry = "SELECT * FROM expenses WHERE Purpose LIKE '%" + comboBox2.Text + "%' ORDER BY ID DESC";


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
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data1.Rows.Add();
                        data1.Rows[i].Cells[0].Value = dt.Rows[i][0];
                        data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        data1.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                        data1.Rows[i].Cells[3].Value = dt.Rows[i][4].ToString();
                    }
                    gettotal();
                }
                else
                {
                    MessageBox.Show("No Data Found..!!");
                    gettotal();
                }

            }
            else
                MessageBox.Show("Please select expense purpose to search !!");
        }

        public void gettotal()
        {
            int netbill = 0;
            if (data1.Rows.Count > 0)
            {
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    netbill += Convert.ToInt32(data1.Rows[i].Cells[4].Value);
                }
                textBox4.Text = netbill.ToString();
            }
            else
                textBox4.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            DataTable dt2 = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM expenses WHERE date>='" + dateTimePicker3.Text + "' AND date<='" + dateTimePicker2.Text + "' ORDER BY date DESC ";
                using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                {
                    con.Open();

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt2.Load(dr);
                    con.Close();
                }
            }
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    data1.Rows.Add();
                    data1.Rows[i].Cells[0].Value = dt2.Rows[i][0].ToString();
                    data1.Rows[i].Cells[1].Value = dt2.Rows[i][1].ToString();
                    data1.Rows[i].Cells[2].Value = dt2.Rows[i][2].ToString();
                    data1.Rows[i].Cells[4].Value = dt2.Rows[i][3].ToString();
                    data1.Rows[i].Cells[3].Value = dt2.Rows[i][4].ToString();
                }
                gettotal();
            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                gettotal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                string reas="";
                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                int am = Convert.ToInt32(data1.Rows[row].Cells[4].Value);
                if(data1.Rows[row].Cells[3].Value!=null)
                reas = data1.Rows[row].Cells[3].Value.ToString();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE expenses SET Amount='" + am + "', reason='"+reas+"' WHERE ID = '" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Updated Successfully.");
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
                    String query = "DELETE FROM expenses WHERE ID = '" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                data1.Rows.RemoveAt(row);
                MessageBox.Show("Deleted Successfully.");
            }
        }

        private void data1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(column3_keypress);
            if (data1.CurrentCell.ColumnIndex == 4)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }
    }
}
