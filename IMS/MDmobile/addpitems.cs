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
    public partial class addpitems : Form
    {
        public static addpitems instance;
        public TextBox tb1;
        public TextBox tb2;
        public TextBox tb3;

        public addpitems()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox5;
            tb2 = textBox1;
            tb3 = textBox7;

        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        int id = 0;
        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(id) From supplierLedger";
                using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                {
                    con.Open();

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    con.Close();
                }
            }
            if (dt.Rows[0][0] != DBNull.Value)
            {
                id = Convert.ToInt32(dt.Rows[0][0]) + 1;
                label14.Text = id.ToString();
            }
            else
            {
                id = 1;
                label14.Text = id.ToString();
            }
        }
        public void loaddata()
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
            comboBox1.Items.Add("All");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            comboBox1.Text = "All";
        }
        private void addpitems_Load(object sender, EventArgs e)
        {
            getid();
            loaddata();
            button4.Enabled = false;
        }

        public static String cat;
        public static String nm;
        public static int pid;

        public static String sname;
        public static int sid;
        public static float sremain;

        private void button4_Click(object sender, EventArgs e)
        {
            itemsearch ob = new itemsearch(comboBox1.Text, 3);
            ob.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT purchaseprice,saleprice FROM product WHERE cname = '" + cat + "' and name = '" + textBox5.Text + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
                textBox2.Text = (dt.Rows[0][0].ToString());
                textBox4.Text = (dt.Rows[0][1].ToString());
                textBox3.Text = "0";
            }
            else
            {
                textBox2.Text = textBox4.Text="";
                textBox3.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            supsearch ob = new supsearch(1);
            ob.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }
        public float am = 0;
        public float netbill = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                if (textBox3.Text != "" && Convert.ToInt32(textBox3.Text) > 0)
                {
                    netbill = 0;
                    textBox6.Text = "1";
                    am = float.Parse(textBox2.Text) * float.Parse(textBox3.Text);
                    //add item button
                    if (comboBox1.Text != "")
                    {
                        String[] row = { cat, textBox5.Text, textBox2.Text, textBox4.Text, textBox3.Text, am.ToString() };
                        data1.Rows.Add(row);
                    }

                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        netbill += float.Parse(data1.Rows[i].Cells[5].Value.ToString());
                    }
                    textBox6.Text = netbill.ToString();
                    textBox5.Text = "";

                    if (data1.Rows.Count < 1)
                    {
                        button3.Enabled = false;
                        textBox6.Text = "0";
                    }
                    else
                        button3.Enabled = true;
                }
                else
                    MessageBox.Show("Please enter quantity ...!!");
            }
            else
                MessageBox.Show("Please select product ...!!");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(textBox9.Text!="")
            textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text) + float.Parse(textBox9.Text)).ToString();
            else
                textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text)).ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
                textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text) + float.Parse(textBox9.Text)).ToString();
            else
                textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text)).ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                data1.Rows.RemoveAt(row);
            }
            netbill = 0;
            textBox6.Text = "1";
            for (int i = 0; i < data1.Rows.Count; i++)
            {
                netbill += float.Parse(data1.Rows[i].Cells[5].Value.ToString());
            }
            textBox6.Text = netbill.ToString();

            if (data1.Rows.Count < 1)
            {
                button3.Enabled = false;
                textBox6.Text = "0";
            }
            else
                button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            up();
            setcus();
            MessageBox.Show("Bill Saved Successfully.");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox10.Text = "";
            textBox6.Text = textBox7.Text = textBox8.Text = "0";
            data1.Rows.Clear();
            button3.Enabled = false;
            button4.Enabled = false;
            getid();
            
        }
        public void setcus()
        {
            if (textBox10.Text != "")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO supcash ([ID],[name],[Date],[Purpose],[Amount]) VALUES (@id,@cname,@date,@pur,@am)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", sid);
                        cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@pur", "Billing");
                        cmd.Parameters.AddWithValue("@am", textBox10.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            
            
            
            float re;
            if (textBox10.Text != "")
            {
                re = float.Parse(textBox8.Text) - float.Parse(textBox10.Text);
            }
            else
                re = float.Parse(textBox8.Text);


            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                String query = "UPDATE supplier SET remain= '" + re + "' WHERE ID='" + sid + "'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void up()
        {
            for (int i = 0; i < data1.Rows.Count; i++)
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO supplierLedger ([ID],[sid],[date],[cname],[pname],[pprice],[sprice],[qty],[amount]) VALUES (@id,@sid,@date,@cname,@pname,@pprice,@sprice,@qty,@amount)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sid", sid);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@cname", data1.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@pname", data1.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@pprice", data1.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@sprice", data1.Rows[i].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@qty", data1.Rows[i].Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@amount", data1.Rows[i].Cells[5].Value.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            for (int i = 0; i < data1.Rows.Count; i++)
            {
                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT total,remaining FROM product WHERE cname='" + data1.Rows[i].Cells[0].Value + "' and name='" + data1.Rows[i].Cells[1].Value + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
                float tre;
                float tt;
                tt = float.Parse(dt.Rows[0][0].ToString());
                tre = float.Parse(dt.Rows[0][1].ToString());
                float re;
                float ttre;
                ttre = tt + float.Parse(data1.Rows[i].Cells[4].Value.ToString());
                re = tre + float.Parse(data1.Rows[i].Cells[4].Value.ToString());
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE product SET purchaseprice='" + data1.Rows[i].Cells[2].Value + "' , saleprice='" + data1.Rows[i].Cells[3].Value + "' , total='" + ttre + "' , remaining= '" + re + "' WHERE cname='" + data1.Rows[i].Cells[0].Value + "' and name='" + data1.Rows[i].Cells[1].Value + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
                textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text) + float.Parse(textBox9.Text)).ToString();
            else
                textBox8.Text = (float.Parse(textBox6.Text) + float.Parse(textBox7.Text)).ToString();
        }
    }
}
