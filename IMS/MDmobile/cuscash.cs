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
    public partial class cuscash : Form
    {
        public static cuscash instance;
        public TextBox tb1;
        public TextBox tb2;
        public cuscash()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        public static int cusid;
        public int chid;
        private void button5_Click(object sender, EventArgs e)
        {
            cusearch ob = new cusearch(3);
            ob.ShowDialog();
        }
        public void getid()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT max(cashid) From cuscash";
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
                    chid = Convert.ToInt32(dt.Rows[0][0]) + 1;
                else
                    chid = 1;
            }
            else
                chid = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getid();
            if (textBox1.Text != "")
            {
                if ( textBox4.Text != "" && textBox4.Text != "0")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        String query = "INSERT INTO cuscash ([cashid],[ID],[name],[Date],[Purpose],[Amount],[flag]) VALUES (@cashid,@id,@cname,@date,@pur,@am,@flag)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@cashid", chid);
                            cmd.Parameters.AddWithValue("@id", cusid);
                            cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                            cmd.Parameters.AddWithValue("@pur", textBox3.Text);
                            cmd.Parameters.AddWithValue("@am", textBox4.Text);
                            if(checkBox1.Checked)
                                cmd.Parameters.AddWithValue("@flag", 1);
                            else
                                cmd.Parameters.AddWithValue("@flag", 0);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    setcusremain();
                    if (checkBox1.Checked)
                        MessageBox.Show("Amount Added Successfully.");
                    else
                        MessageBox.Show("Cash received Successfully.");
                    textBox3.Text = textBox4.Text = textBox1.Text = textBox2.Text = "";
                    get();
                }
                else
                    MessageBox.Show("Please Enter Cash Details..!!");
            }
            else
                MessageBox.Show("Please select Customer first..!!");
            
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
            if(checkBox1.Checked)
                am = re+float.Parse(textBox4.Text);
            else
                am = re - float.Parse(textBox4.Text);
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE customer SET remain='" + am + "' WHERE ID = '" + cusid + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            
        }

        public void get()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * From cuscash ORDER BY Date DESC";
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
                data1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
            }
            gettotal();
        }

        private void cuscash_Load(object sender, EventArgs e)
        {
            getid();
            get();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                string qry = "";
                data1.Rows.Clear();
                DataTable dt2 = new DataTable();

                if (radioButton1.Checked == true)
                    qry = "SELECT * FROM cuscash WHERE flag='" + 1 + "' AND Date>='" + dateTimePicker3.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";
                if (radioButton2.Checked == true)
                    qry = "SELECT * FROM cuscash WHERE flag='" + 0 + "' AND Date>='" + dateTimePicker3.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";
                if (radioButton3.Checked == true)
                    qry = "SELECT * FROM cuscash WHERE Date>='" + dateTimePicker3.Text + "' AND Date<='" + dateTimePicker2.Text + "' ORDER BY Date DESC ";


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {

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
                        data1.Rows[i].Cells[6].Value = dt2.Rows[i][6].ToString();
                    }
                    gettotal();
                }
                else
                {
                    MessageBox.Show("No Data Found..!!");

                }
            }
            else
                MessageBox.Show("Please Select One of the option\n1. Only added amount\n2. Only received cash\n3. All");
        }
        public void gettotal()
        {
            float netbill = 0;
            float tadd = 0;
            if (data1.Rows.Count > 0)
            {
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data1.Rows[i].Cells[6].Value)==1)
                    tadd += float.Parse(data1.Rows[i].Cells[5].Value.ToString());
                }
                textBox7.Text = tadd.ToString();
                
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data1.Rows[i].Cells[6].Value) == 0)
                    netbill += float.Parse(data1.Rows[i].Cells[5].Value.ToString());
                }
                textBox6.Text = netbill.ToString();
            }
            else
                textBox6.Text = "0";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            get();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true)
            {
                string qry = "";
                if (textBox5.Text != "")
                {
                    if (radioButton4.Checked == true)
                        qry = "SELECT * FROM cuscash WHERE name LIKE '%" + textBox5.Text + "%' AND flag='" + 1 + "' ORDER BY name ASC";
                    if (radioButton5.Checked == true)
                        qry = "SELECT * FROM cuscash WHERE name LIKE '%" + textBox5.Text + "%' AND flag='" + 0 + "' ORDER BY name ASC";
                    if (radioButton6.Checked == true)
                        qry = "SELECT * FROM cuscash WHERE name LIKE '%" + textBox5.Text + "%' ORDER BY name ASC";
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
                        data1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    }
                    gettotal();
                }
                else
                    MessageBox.Show("Please Enter Customer name to search !!");
            }
            else
                MessageBox.Show("Please Select One of the option\n1. Only added amount\n2. Only received cash\n3. All");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                button1.Text = "Add Amount";
            else
                button1.Text = "Add Cash";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {

                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[1].Value);
                int cash = Convert.ToInt32(data1.Rows[row].Cells[0].Value.ToString());
                int fla = Convert.ToInt32(data1.Rows[row].Cells[6].Value);
                float am1 = float.Parse(data1.Rows[row].Cells[5].Value.ToString());


                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT * From customer WHERE ID='"+id+"'";
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
                if (fla == 0)
                    tr = am1 + re;
                else if (fla == 1)
                    tr = re - am1;

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "Update customer SET remain='" + tr + "' WHERE ID = '" + id + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM cuscash WHERE cashid = '" + cash + "'";
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
