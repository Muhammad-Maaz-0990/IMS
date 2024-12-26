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
    public partial class salevsexp : Form
    {
        public salevsexp()
        {
            InitializeComponent();
        }
                String datasource = "Data Source=MDdb.db;Version=3;";
        private void button1_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            String qry="";
            qry = "SELECT * FROM report WHERE cusid='" + "0" + "' AND date>='" + dateTimePicker1.Text + "' AND date<='" + dateTimePicker2.Text + "' ORDER BY date DESC";
            
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
                        data1.Rows[i].Cells[0].Value = dt.Rows[i][2].ToString();
                        data1.Rows[i].Cells[1].Value = dt.Rows[i][3].ToString();
                        data1.Rows[i].Cells[2].Value = dt.Rows[i][4].ToString();
                        data1.Rows[i].Cells[3].Value = dt.Rows[i][7].ToString();
                        data1.Rows[i].Cells[4].Value = dt.Rows[i][8].ToString();
                    }
                    float tsale = 0;
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        tsale += float.Parse(data1.Rows[i].Cells[4].Value.ToString());
                    }
                    textBox1.Text = tsale.ToString();
                }
                else
                    textBox1.Text = "0";

            //////////....................table 2........./////////////////


                data2.Rows.Clear();
                DataTable dt2 = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry2 = "SELECT * FROM expenses WHERE date>='" + dateTimePicker1.Text + "' AND date<='" + dateTimePicker2.Text + "' ORDER BY date DESC ";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry2, con))
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
                        data2.Rows.Add();
                        data2.Rows[i].Cells[0].Value = dt2.Rows[i][1].ToString();
                        data2.Rows[i].Cells[1].Value = dt2.Rows[i][2].ToString();
                        data2.Rows[i].Cells[3].Value = dt2.Rows[i][3].ToString();
                        data2.Rows[i].Cells[2].Value = dt2.Rows[i][4].ToString();
                    }

                    int texp = 0;
                    for (int i = 0; i < data2.Rows.Count; i++)
                    {
                        texp += Convert.ToInt32(data2.Rows[i].Cells[3].Value);
                    }
                    textBox2.Text = texp.ToString();
                }
                else
                {
                    textBox2.Text = "0";
                }

            ////////////.............table 3................./////////////////


                data3.Rows.Clear();
                DataTable dt3 = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry3 = "SELECT * FROM cuscash WHERE Date>='" + dateTimePicker1.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry3, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt3.Load(dr);
                        con.Close();
                    }
                }
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        data3.Rows.Add();
                        data3.Rows[i].Cells[0].Value = dt3.Rows[i][2].ToString();
                        data3.Rows[i].Cells[1].Value = dt3.Rows[i][3].ToString();
                        data3.Rows[i].Cells[2].Value = dt3.Rows[i][4].ToString();
                        data3.Rows[i].Cells[3].Value = dt3.Rows[i][5].ToString();
                    }

                    float trcash = 0;
                    for (int i = 0; i < data3.Rows.Count; i++)
                    {
                        trcash += float.Parse(data3.Rows[i].Cells[3].Value.ToString());
                    }
                    textBox6.Text = trcash.ToString();
                }
                else
                {
                    textBox6.Text = "0";
                }

            /////////............table 4......./////////////////

                data4.Rows.Clear();
                DataTable dt4 = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry4 = "SELECT * FROM supcash WHERE Date>='" + dateTimePicker1.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry4, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt4.Load(dr);
                        con.Close();
                    }
                }
                if (dt4.Rows.Count > 0)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        data4.Rows.Add();
                        data4.Rows[i].Cells[0].Value = dt4.Rows[i][2].ToString();
                        data4.Rows[i].Cells[1].Value = dt4.Rows[i][3].ToString();
                        data4.Rows[i].Cells[2].Value = dt4.Rows[i][4].ToString();
                        data4.Rows[i].Cells[3].Value = dt4.Rows[i][5].ToString();
                    }

                    float tpcash = 0;
                    for (int i = 0; i < data4.Rows.Count; i++)
                    {
                        tpcash += float.Parse(data4.Rows[i].Cells[3].Value.ToString());
                    }
                    textBox8.Text = tpcash.ToString();
                }
                else
                {
                    textBox8.Text = "0";
                }


                float tcr = 0;
                float tcp = 0;
                tcr = float.Parse(textBox1.Text) + float.Parse(textBox6.Text);
                tcp = float.Parse(textBox2.Text) + float.Parse(textBox8.Text);
                textBox9.Text = tcr.ToString();
                textBox10.Text = tcp.ToString();
            
        }

        private void salevsexp_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            float tin = 0;
            tin = float.Parse(textBox9.Text) - float.Parse(textBox10.Text);
                textBox11.Text=tin.ToString();
        }
    }
}
