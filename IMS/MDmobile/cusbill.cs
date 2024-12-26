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
    public partial class cusbill : Form
    {
        public static cusbill instance;
        public TextBox tb1;
        public TextBox tb2;
        public TextBox tb3;
        public cusbill()
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
                string qry = "SELECT max(id) From report";
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
        

        private void cusbill_Load(object sender, EventArgs e)
        {
            loaddata();
            getid();

            button4.Enabled = false;
        }

        public float am = 0;
        public float netbill = 0;

        public static String cat;
        public static String nm;

        public static String cusname;
        public static int cusid;
        public static float cusremain;

        

        private void button4_Click(object sender, EventArgs e)
        {
            itemsearch ob = new itemsearch(comboBox1.Text,2);
            ob.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }
        public String pprice;
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
                pprice = (dt.Rows[0][0].ToString());
                textBox2.Text = (dt.Rows[0][1].ToString());
                textBox3.Text = "0";
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                if (textBox3.Text != "" && Convert.ToInt32(textBox3.Text) > 0)
                {
                    DataTable dt = new DataTable();
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT remaining FROM product WHERE cname='" + cat + "' and name='" + textBox5.Text + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();

                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                    if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= Convert.ToInt32(textBox3.Text))
                    {
                        int qty = 0;
                        for (int i = 0; i < data1.Rows.Count; i++)
                        {
                            if (data1.Rows[i].Cells[0].Value.ToString() == cat && data1.Rows[i].Cells[1].Value.ToString() == textBox5.Text)
                            {
                                qty += Convert.ToInt32(data1.Rows[i].Cells[3].Value);
                            }
                        }
                        if (Convert.ToInt32(dt.Rows[0][0].ToString()) > qty)
                        {
                            int ck;
                            ck = Convert.ToInt32(dt.Rows[0][0].ToString()) - qty;
                            if (ck >= Convert.ToInt32(textBox3.Text))
                            {
                                netbill = 0;
                                textBox4.Text = "1";
                                am = float.Parse(textBox2.Text) * float.Parse(textBox3.Text);
                                //add item button
                                if (comboBox1.Text != "")
                                {
                                    String[] row = { cat, textBox5.Text, textBox2.Text, textBox3.Text, am.ToString(), pprice.ToString() };
                                    data1.Rows.Add(row);
                                }

                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    netbill += float.Parse(data1.Rows[i].Cells[4].Value.ToString());
                                }
                                textBox4.Text = netbill.ToString();
                                textBox5.Text = "";

                                if (data1.Rows.Count < 1)
                                {
                                    button3.Enabled = false;
                                    textBox4.Text = "0";
                                }
                                else
                                    button3.Enabled = true;
                            }
                            else
                                MessageBox.Show("only " + ck + " pieces remaining...!!\nPlease Select Quantity less then or equal to " + ck);
                        }
                        else
                            MessageBox.Show("No more pieces remaining...!!");
                    }
                    else
                        MessageBox.Show("Only " + dt.Rows[0][0].ToString() + " pieces remaining.\nPlease Enter Quantity less or equal to " + dt.Rows[0][0].ToString() + ".");

                }
                else
                    MessageBox.Show("Please enter quantity ...!!");
            }
            else
                MessageBox.Show("Please select product ...!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                data1.Rows.RemoveAt(row);
            }
            netbill = 0;
            textBox4.Text="1";
            for (int i = 0; i < data1.Rows.Count; i++)
            {
                netbill += float.Parse(data1.Rows[i].Cells[4].Value.ToString());
            }
            textBox4.Text = netbill.ToString();

            if (data1.Rows.Count < 1)
            {
                button3.Enabled = false;
                textBox4.Text = "0";
            }
            else
                button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cusearch ob = new cusearch(1);
            ob.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            textBox8.Text = (float.Parse(textBox4.Text) + float.Parse(textBox7.Text)).ToString();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        public void up()
        {


            for (int i = 0; i < data1.Rows.Count; i++)
            {

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO report ([id],[cusid],[date],[cname],[pname],[pprice],[sprice],[quantity],[amount],[purpose]) VALUES (@id,@cusid,@date,@cname,@pname,@pprice,@sprice,@qty,@amount,@pur)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@cusid", cusid);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@cname", data1.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@pname", data1.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@pprice", data1.Rows[i].Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@sprice", data1.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@qty", data1.Rows[i].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@amount", data1.Rows[i].Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@pur", textBox6.Text);
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
                    string qry = "SELECT remaining FROM product WHERE cname='" + data1.Rows[i].Cells[0].Value + "' and name='" + data1.Rows[i].Cells[1].Value + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
                float tre;
                tre = float.Parse(dt.Rows[0][0].ToString());
                float re;
                re = tre - float.Parse(data1.Rows[i].Cells[3].Value.ToString());
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE product SET remaining= '" + re + "' WHERE cname='" + data1.Rows[i].Cells[0].Value + "' and name='" + data1.Rows[i].Cells[1].Value + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
        }

        public void setcus()
        {
            if (textBox10.Text != "" && float.Parse(textBox10.Text) != 0)
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO cuscash ([ID],[name],[Date],[Purpose],[Amount],[flag]) VALUES (@id,@cname,@date,@pur,@am,@fl)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", cusid);
                        cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        if(textBox6.Text=="")
                            cmd.Parameters.AddWithValue("@pur", "Billing");
                        else
                            cmd.Parameters.AddWithValue("@pur", textBox6.Text);
                        cmd.Parameters.AddWithValue("@am", textBox10.Text);
                        cmd.Parameters.AddWithValue("@fl", 0);
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
                String query = "UPDATE customer SET remain= '" + re + "' WHERE ID='" + cusid + "'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");

            for (int i = 0; i < data1.Rows.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][0] = data1.Rows[i].Cells[1].Value.ToString();
                dt.Rows[i][1] = data1.Rows[i].Cells[2].Value.ToString();
                dt.Rows[i][2] = data1.Rows[i].Cells[3].Value.ToString();
                dt.Rows[i][3] = data1.Rows[i].Cells[4].Value.ToString();
            }
            float tbal=0;
            if(textBox10.Text=="")
                tbal = float.Parse(textBox8.Text) - 0;
            else
                tbal = float.Parse(textBox8.Text) - float.Parse(textBox10.Text);
            view ob = new view(dt, textBox1.Text, dateTimePicker1.Text, id, textBox4.Text,textBox10.Text,textBox7.Text,tbal.ToString());
            ob.ShowDialog();
            up();
            setcus();
            textBox1.Text = textBox2.Text = textBox3.Text =textBox10.Text= "";
            textBox4.Text =textBox7.Text=textBox8.Text= "0";
            data1.Rows.Clear();
            button3.Enabled = false;
            getid();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = (float.Parse(textBox4.Text) + float.Parse(textBox7.Text)).ToString();
        }

    }
}
