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
    public partial class DeleteBill : Form
    {
        public DeleteBill()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        private void DeleteBill_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            if (comboBox1.Text != "")
            {
                dt.Rows.Clear();
                if (comboBox1.Text == "Customer")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT DISTINCT id FROM report WHERE cusid>'" + 0 + "' AND date='"+dateTimePicker1.Text+"' ORDER BY id DESC";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();

                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                }
                else if(comboBox1.Text=="Cash")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT DISTINCT id FROM report WHERE cusid='" + 0 + "' AND date='" + dateTimePicker1.Text + "' ORDER BY id DESC";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();

                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                }
                else if(comboBox1.Text=="Supplier")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT DISTINCT ID FROM supplierLedger WHERE date='" + dateTimePicker1.Text + "' ORDER BY ID DESC";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();
                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                }
                comboBox2.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
                button2.Enabled = true;
            else
                button2.Enabled = false;
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            if (comboBox2.SelectedIndex != -1)
            {
                dt.Rows.Clear();
                if (comboBox1.Text == "Customer" || comboBox1.Text == "Cash")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT * FROM report WHERE id='" + Convert.ToInt32(comboBox2.Text) + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();
                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                }
                else if (comboBox1.Text == "Supplier")
                {
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT * FROM supplierLedger WHERE ID='" + Convert.ToInt32(comboBox2.Text) + "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();
                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            con.Close();
                        }
                    }
                }

                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data1.Rows.Add();
                        data1.Rows[i].Cells[0].Value = i + 1;
                        data1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                        data1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        data1.Rows[i].Cells[3].Value = dt.Rows[i][3];
                        data1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        data1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                        data1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                        data1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                        data1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                    }
                    total();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Customer" || comboBox1.Text == "Cash")
            {
                if(comboBox1.Text == "Customer")
                {
                    int cusid=0;
                    float re=0;
                    DataTable dt2 = new DataTable();
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT cusid From report WHERE id='"+Convert.ToInt32(comboBox2.Text)+"'";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();

                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt2.Load(dr);
                            con.Close();
                        }
                    }
                    cusid = Convert.ToInt32(dt2.Rows[0][0]);
                    DataTable dt3 = new DataTable();
                    using (SQLiteConnection con = new SQLiteConnection(datasource))
                    {
                        string qry = "SELECT remain From customer WHERE ID='" + cusid+ "'";
                        using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                        {
                            con.Open();

                            SQLiteDataReader dr = cmd.ExecuteReader();
                            dt3.Load(dr);
                            con.Close();
                        }
                    }
                    re = float.Parse(dt3.Rows[0][0].ToString()) - float.Parse(textBox1.Text);
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
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM report WHERE id='" + Convert.ToInt32(comboBox2.Text) + "' ";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            else if (comboBox1.Text == "Supplier")
            {
                int sid = 0;
                float sre = 0;
                DataTable dt5 = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT sid From supplierLedger WHERE ID='" + Convert.ToInt32(comboBox2.Text) + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt5.Load(dr);
                        con.Close();
                    }
                }
                sid = Convert.ToInt32(dt5.Rows[0][0].ToString());
                DataTable dt6 = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT remain From supplier WHERE ID='" + sid + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt6.Load(dr);
                        con.Close();
                    }
                }
                sre = float.Parse(dt6.Rows[0][0].ToString()) - float.Parse(textBox1.Text);
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE supplier SET remain= '" + sre + "' WHERE ID='" + sid + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
               
                
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM supplierLedger WHERE ID='" + Convert.ToInt32(comboBox2.Text) + "' ";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            DataTable dt9 = new DataTable();
            for (int i = 0; i < data1.Rows.Count; i++)
            {
                int pre = 0;
                int pt = 0;
                dt9.Rows.Clear();
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    string qry = "SELECT remaining,total From product WHERE cname='" + data1.Rows[i].Cells[3].Value.ToString() + "' AND name='" + data1.Rows[i].Cells[4].Value.ToString() + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(qry, con))
                    {
                        con.Open();

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt9.Load(dr);
                        con.Close();
                    }
                }
                if(dt9.Rows.Count>0)
                {
                    if (comboBox1.Text == "Customer" || comboBox1.Text == "Cash")
                    {
                        pre = Convert.ToInt32(dt9.Rows[0][0]) + Convert.ToInt32(data1.Rows[i].Cells[7].Value);
                    }
                    else if (comboBox1.Text == "Supplier")
                    {
                        pre = Convert.ToInt32(dt9.Rows[0][0]) - Convert.ToInt32(data1.Rows[i].Cells[7].Value);
                        pt = Convert.ToInt32(dt9.Rows[0][1]) - Convert.ToInt32(data1.Rows[i].Cells[7].Value);
                    }

                    if (comboBox1.Text == "Customer" || comboBox1.Text == "Cash")
                    {
                        using (SQLiteConnection con = new SQLiteConnection(datasource))
                        {
                            String query = "UPDATE product SET remaining= '" + pre + "' WHERE cname='" + data1.Rows[i].Cells[3].Value.ToString() + "' AND name='" + data1.Rows[i].Cells[4].Value.ToString() + "'";
                            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    else if (comboBox1.Text == "Supplier")
                    {
                        using (SQLiteConnection con = new SQLiteConnection(datasource))
                        {
                            String query = "UPDATE product SET remaining= '" + pre + "' , total='" + pt + "' WHERE cname='" + data1.Rows[i].Cells[3].Value.ToString() + "' AND name='" + data1.Rows[i].Cells[4].Value.ToString() + "'";
                            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }

            data1.Rows.Clear();
            MessageBox.Show("Bill No. " + comboBox2.Text + " is deleted from your record.");
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            comboBox1.SelectedIndex = -1;
        }

        public void total()
        {
            if (data1.Rows.Count > 0)
            {
                float net = 0;

                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    net += float.Parse(data1.Rows[i].Cells[8].Value.ToString());
                }
                textBox1.Text = net.ToString();
            }
        }
    }
}
