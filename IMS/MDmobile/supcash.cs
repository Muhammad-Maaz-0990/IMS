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
    public partial class supcash : Form
    {
        public static supcash instance;
        public TextBox tb1;
        public TextBox tb2;
        public supcash()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static int sid;
        private void supcash_Load(object sender, EventArgs e)
        {
            get();
        }

        public void get()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * From supcash ORDER BY Date DESC";
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
                data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
            }
            gettotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            supsearch ob = new supsearch(2);
            ob.ShowDialog();
        }

        public void setcusremain()
        {
            /*DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT remain From customer WHERE ID='"+cusid+"'";
                using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                {
                    con.Open();

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    con.Close();
                }
            }*/
            float am, re;
            re = float.Parse(textBox2.Text);
            am = re - float.Parse(textBox4.Text);
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                String query = "UPDATE supplier SET remain='" + am + "' WHERE ID = '" + sid + "'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public void gettotal()
        {
            float netbill = 0;
            if (data1.Rows.Count > 0)
            {
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    netbill += float.Parse(data1.Rows[i].Cells[5].Value.ToString());
                }
                textBox6.Text = netbill.ToString();
            }
            else
                textBox6.Text = "0";
        }

        public int payid;
        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(payid) From supcash";
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
                    payid = Convert.ToInt32(dt.Rows[0][0]) + 1;
                else
                    payid = 1;
            }
            else
                payid = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getid();
            if (textBox1.Text != "")
            {
                if ( textBox4.Text != "" && textBox4.Text!="0")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query = "INSERT INTO supcash ([payid],[ID],[name],[Date],[Purpose],[Amount]) VALUES (@pid,@id,@cname,@date,@pur,@am)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@pid", payid);
                            cmd.Parameters.AddWithValue("@id", sid);
                            cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                            cmd.Parameters.AddWithValue("@pur", textBox3.Text);
                            cmd.Parameters.AddWithValue("@am", textBox4.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    setcusremain();
                    MessageBox.Show("Cash Paid Successfully...");
                    textBox3.Text = textBox4.Text = textBox1.Text = textBox2.Text = "";
                    get();
                }
                else
                    MessageBox.Show("Please Enter Cash Details..!!");
            }
            else
                MessageBox.Show("Please select Supplier first..!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            DataTable dt2 = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM supcash WHERE Date>='" + dateTimePicker3.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";
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
                    data1.Rows[i].Cells[3].Value = dt2.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt2.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt2.Rows[i][5].ToString();
                }
                gettotal();
            }
            else
            {
                MessageBox.Show("No Data Found..!!");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            get();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            get();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (textBox5.Text != "")
            {
                qry = "SELECT * FROM supcash WHERE name LIKE '%" + textBox5.Text + "%' ORDER BY name ASC";
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
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                }
            }
            else
                MessageBox.Show("Please Enter Supplier name to search !!");
        
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {

                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[1].Value);
                int cash = Convert.ToInt32(data1.Rows[row].Cells[0].Value.ToString());
                float am1 = float.Parse(data1.Rows[row].Cells[5].Value.ToString());


                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * From supplier WHERE ID='" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
                float re = float.Parse(dt.Rows[0][2].ToString());
                float tr = 0;
                    tr = am1 + re;

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "Update supplier SET remain='" + tr + "' WHERE ID = '" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM supcash WHERE payid = '" + cash + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                get();
                MessageBox.Show("Deleted Successfully.");

            }
        }
    }
}
