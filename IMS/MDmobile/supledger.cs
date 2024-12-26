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
    public partial class supledger : Form
    {
        public static supledger instance;
        public TextBox tb1;
        public TextBox tb2;
        public supledger()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox2;
            tb2 = textBox4;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        
        public static int supid;
        private void button1_Click(object sender, EventArgs e)
        {
            supsearch ob = new supsearch(3);
            ob.ShowDialog();
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

        public void getdata()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();

            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM supplierLedger WHERE sid='" + supid + "'";
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
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][8].ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[7].Value.ToString());
                }
                textBox1.Text = tpr.ToString();
            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                textBox1.Text = "0";
                textBox4.Text = "0";
            }
        }

        public void get(int x)
        {
            string qry = "";
            data2.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                if (x == 0)
                    qry = "SELECT * From supcash WHERE ID='" + supid + "' ORDER BY Date DESC";
                else if (x == 1)
                    qry = "SELECT * From supcash WHERE ID='" + supid + "' AND Date>='" + dateTimePicker1.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC";
                else if (x == 2)
                    qry = "SELECT * From supcash WHERE Date>='" + dateTimePicker1.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC";
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get(1);
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM supplierLedger WHERE sid='" + supid + "' AND date>='" + dateTimePicker1.Text + "' AND date<='" + dateTimePicker2.Text + "' ORDER BY date DESC ";
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
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][8].ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[7].Value.ToString());
                }
                textBox1.Text = tpr.ToString();

            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                textBox1.Text  = "0";
                textBox4.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get(2);
            float re = 0;
            DataTable dt2 = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT remain FROM supplier";
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
                    re += float.Parse(dt2.Rows[i][0].ToString());
                }
            }
            textBox4.Text = re.ToString();
            
            
            textBox2.Text = "";
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM supplierLedger WHERE date>='" + dateTimePicker4.Text + "' AND date<='" + dateTimePicker3.Text + "' ORDER BY date DESC ";
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
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    data1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    data1.Rows[i].Cells[6].Value = dt.Rows[i][7].ToString();
                    data1.Rows[i].Cells[7].Value = dt.Rows[i][8].ToString();

                }
                float tpr = 0;
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    tpr += float.Parse(data1.Rows[i].Cells[7].Value.ToString());
                }
                textBox1.Text = tpr.ToString();

            }
            else
            {
                MessageBox.Show("No Data Found..!!");
                textBox1.Text = "0";
                textBox4.Text = "0";
            }
        }

        private void supledger_Load(object sender, EventArgs e)
        {

        }
    }
}
