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
    public partial class salereport : Form
    {
        public static salereport instance;
        public TextBox tb1;
        public salereport()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox3;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static String cat;
        

        

        private void salereport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public void getdata(int x)
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            if(x==1)
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE cname='" + cat + "' and pname='" + textBox3.Text + "' AND sprice!='" + 0 + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
            }
            if (x == 4)
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE cname='" + cat + "' AND pname='" + textBox3.Text + "' AND date>='" + dateTimePicker4.Text + "' AND date<='" + dateTimePicker3.Text + "' AND sprice!='" + 0 + "' ORDER BY date DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
            }
            if(x==2)
            {
                textBox3.Text = "";
                dt.Rows.Clear();
                DataTable dt2=new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE date>='" + dateTimePicker1.Text + "' AND date<='" + dateTimePicker2.Text + "' AND sprice!='" + 0 + "' ORDER BY date DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }

                
            }
            if(x==3)
            {
                textBox3.Text = "";
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE id='" + textBox2.Text + "' AND sprice!='" + 0 + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    data1.Rows.Add();
                    data1.Rows[i].Cells[0].Value = i + 1;
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                    float pr, to;
                    to = float.Parse(dt.Rows[i][5].ToString()) * float.Parse(dt.Rows[i][7].ToString());
                    pr = float.Parse(dt.Rows[i][8].ToString()) - to;

                    data1.Rows[i].Cells[9].Value = pr.ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[9].Value.ToString());
                }
                textBox4.Text = tpr.ToString();

                float ta = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    ta += float.Parse(data1.Rows[i].Cells[8].Value.ToString());
                }
                textBox1.Text = ta.ToString();
            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                textBox1.Text = textBox4.Text = "0";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getdata(2);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getdata(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemsearch ob = new itemsearch("All",4);
            ob.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


            if (textBox3.Text != "")
            {
                getdata(1);
                button2.Enabled = true;
            }
            else
                button2.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            getdata(4);
        }
    }
}
