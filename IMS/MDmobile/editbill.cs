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
    public partial class editbill : Form
    {
        public static editbill instance;
        public TextBox tb1;
        public TextBox tb2;
        public TextBox tb3;
        public editbill()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox2;
            tb2 = textBox3;
            tb3 = textBox5;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";

        public int netbill = 0;

        public static int supid;

        public static int cusid;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Customer")
            {
                cusearch ob = new cusearch(4);
                ob.ShowDialog();
            }
            else if(comboBox1.Text=="Supplier")
            {
                supsearch ob = new supsearch(4);
                ob.ShowDialog();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (comboBox1.Text == "Customer")
                {
                    cuspnl.Visible = true;
                    suppnl.Visible = false;
                    getdata(1);
                }
                else if (comboBox1.Text == "Supplier")
                {
                    suppnl.Visible = true;
                    cuspnl.Visible = false;
                    getdata(2);
                }
            }
        }
        public void getdata(int x)
        {
            if (x == 1)
            {
                data1.Rows.Clear();
                DataTable dt = new DataTable();

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM report WHERE cusid='" + cusid + "' AND sprice='"+0+"'";
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
                        data1.Rows[i].Cells[10].Value = dt.Rows[i][10].ToString();
                    }
                    
                }
                else
                {
                    MessageBox.Show("No Data Found..!!");
                    textBox1.Text = "0";
                }
            }
            else if(x==2)
            {
                data2.Rows.Clear();
                DataTable dt = new DataTable();

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * FROM supplierLedger WHERE sid='" + supid + "' AND pprice='" + 0 + "'";
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
                        data2.Rows.Add();
                        data2.Rows[i].Cells[0].Value = i + 1;
                        data2.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                        data2.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        data2.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                        data2.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        data2.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                        data2.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                        data2.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                        data2.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                        data2.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
                    }

                }
                else
                {
                    MessageBox.Show("No Data Found..!!");
                    textBox4.Text = "0";
                }
            }
        }

        public float cusam;
        public float supam;
        public void colectc()
        {
            if (data1.Rows.Count > 0)
            {
                float net = 0;

                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    data1.Rows[i].Cells[9].Value = float.Parse(data1.Rows[i].Cells[7].Value.ToString()) * float.Parse(data1.Rows[i].Cells[8].Value.ToString());
                }

                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    net += float.Parse(data1.Rows[i].Cells[9].Value.ToString());
                }
                textBox1.Text = net.ToString(); ;
                cusam = float.Parse(textBox3.Text) + float.Parse(textBox1.Text);
            }
        }
        public void colectsup()
        {
            if (data2.Rows.Count > 0)
            {
                float net = 0;

                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    data2.Rows[i].Cells[8].Value = float.Parse(data2.Rows[i].Cells[5].Value.ToString()) * float.Parse(data2.Rows[i].Cells[7].Value.ToString());
                }

                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    net += float.Parse(data2.Rows[i].Cells[8].Value.ToString());
                }
                textBox4.Text = net.ToString();
                supam = float.Parse(textBox5.Text) + float.Parse(textBox4.Text);
            }
        }
        private void data1_Click(object sender, EventArgs e)
        {
            colectc();
        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
                colectc();
        }

        private void data1_KeyDown(object sender, KeyEventArgs e)
        {
            colectc();
        }

        private void data1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            colectc();
        }

        private void data2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            colectsup();
        }

        private void data2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data2_Click(object sender, EventArgs e)
        {
            colectsup();
        }

        private void data2_KeyDown(object sender, KeyEventArgs e)
        {
            colectsup();
        }

        private void data2_KeyPress(object sender, KeyPressEventArgs e)
        {
            colectsup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                colectc();

                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query = "UPDATE report SET sprice= '" + data1.Rows[i].Cells[7].Value + "' , amount='" + data1.Rows[i].Cells[9].Value + "' , date='" + data1.Rows[i].Cells[2].Value+ "' WHERE Eid='" + data1.Rows[i].Cells[10].Value + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE customer SET remain= '" + cusam + "' WHERE ID='" + cusid + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Bill saved Successfully.");
                comboBox1.SelectedIndex = -1;
                textBox2.Text = "";
                textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = "0";
                data1.Rows.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (data2.Rows.Count > 0)
            {
                colectsup();

                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query = "UPDATE supplierLedger SET pprice= '" + data2.Rows[i].Cells[5].Value + "' , sprice='" + data2.Rows[i].Cells[6].Value + "', amount='" + data2.Rows[i].Cells[8].Value + "' , date='" + data2.Rows[i].Cells[2].Value + "' WHERE Eid='" + data2.Rows[i].Cells[9].Value + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }


                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query2 = "UPDATE product SET purchaseprice= '" + data2.Rows[i].Cells[5].Value + "' , saleprice='" + data2.Rows[i].Cells[6].Value + "' WHERE cname='" + data2.Rows[i].Cells[3].Value + "' AND name='" + data2.Rows[i].Cells[4].Value + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                        {
                            con.Open();

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    
                }

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE supplier SET remain= '" + supam + "' WHERE ID='" + supid + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Bill saved Successfully.");
                comboBox1.SelectedIndex = -1;
                textBox2.Text = "";
                textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = "0";
                data2.Rows.Clear();
            }
        }

    }
}
