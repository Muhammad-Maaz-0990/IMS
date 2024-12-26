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
using System.IO;

namespace MDmobile
{
    public partial class cusledgercs : Form
    {
        public static cusledgercs instance;
        public TextBox tb1;
        public TextBox tb2;
        public cusledgercs()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox2;
            tb2 = textBox4;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static String cusname;
        public static int cusid;
        public static float cusremain;
        private void button1_Click(object sender, EventArgs e)
        {
            cusearch ob = new cusearch(2);
            ob.ShowDialog();
        }

        public void getdata()
        {

            data1.Rows.Clear();
            DataTable dt = new DataTable();
            
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE cusid='" + cusid + "'";
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
                    data1.Rows[i].Cells[0].Value = i + 1;
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][9];
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                    data1.Rows[i].Cells[8].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[9].Value = dt.Rows[i][8].ToString();
                    float pr, to;
                    to = float.Parse(dt.Rows[i][5].ToString()) * float.Parse(dt.Rows[i][7].ToString());
                    pr = float.Parse(dt.Rows[i][8].ToString()) - to;

                    data1.Rows[i].Cells[10].Value = pr.ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[10].Value.ToString());
                }
                textBox3.Text = tpr.ToString();

                float ta = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    ta += float.Parse(data1.Rows[i].Cells[9].Value.ToString());
                }
                textBox1.Text = ta.ToString();
            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                textBox1.Text=textBox3.Text= "0";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            getdata();
            get(0);
            if (textBox2.Text != "")
                button2.Enabled = true;
            else
                button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get(1);
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM report WHERE cusid='" + cusid + "' AND date>='" + dateTimePicker1.Text + "' AND date<='" + dateTimePicker2.Text + "' ORDER BY date DESC ";
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
                    data1.Rows[i].Cells[0].Value = i + 1;
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][9];
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                    data1.Rows[i].Cells[8].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[9].Value = dt.Rows[i][8].ToString();
                    float pr, to;
                    to = float.Parse(dt.Rows[i][5].ToString()) * float.Parse(dt.Rows[i][7].ToString());
                    pr = float.Parse(dt.Rows[i][8].ToString()) - to;

                    data1.Rows[i].Cells[10].Value = pr.ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[10].Value.ToString());
                }
                textBox3.Text = tpr.ToString();

                float ta = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    ta += float.Parse(data1.Rows[i].Cells[9].Value.ToString());
                }
                textBox1.Text = ta.ToString();
            }
            else
            {
                textBox1.Text = textBox3.Text = "0";
            }

        }


        public void get(int x)
        {
            string qry="";
            data2.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                if(x==0)
                qry = "SELECT * From cuscash WHERE ID='" + cusid + "' ORDER BY Date DESC";
                else if(x==1)
                    qry = "SELECT * From cuscash WHERE ID='" + cusid + "' AND Date>='" + dateTimePicker1.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC";
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
                data2.Rows.Add();
                data2.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                data2.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                data2.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                data2.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                data2.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                data2.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                data2.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
            }
        }
        private void cusledgercs_Load(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
