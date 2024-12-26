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
    public partial class allproducts : Form
    {
        public allproducts()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";

        public void loaddata()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM product ORDER BY cname ASC";
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
        private void allproducts_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data1.Rows.Clear();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qry ="";
            if (textBox1.Text != "" && textBox2.Text!="")
            {
                qry = "SELECT * FROM product WHERE cname LIKE '%" + textBox1.Text + "%' AND name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            }
            
            else if(textBox1.Text!="" && textBox2.Text=="")
            {
                qry = "SELECT * FROM product WHERE cname LIKE '%" + textBox1.Text + "%' ORDER BY name ASC";
            }
            else if(textBox1.Text=="" && textBox2.Text!="")
            {
                qry = "SELECT * FROM product WHERE name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            }
            
            if(qry!="")
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
                MessageBox.Show("Please Enter Category or Product name to search !!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                String cname = data1.Rows[row].Cells[0].Value.ToString();
                String name = data1.Rows[row].Cells[1].Value.ToString();


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM product WHERE cname = '" + cname + "' and name='"+name+"'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                data1.Rows.RemoveAt(row);
                MessageBox.Show(cname +" "+name + " has been deleted from your record.");
                loaddata();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                String cname = data1.Rows[row].Cells[0].Value.ToString();
                String name = data1.Rows[row].Cells[1].Value.ToString();
                float pp = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
                float sp = float.Parse(data1.Rows[row].Cells[3].Value.ToString());
                int tq = Convert.ToInt32(data1.Rows[row].Cells[4].Value);
                int rq = Convert.ToInt32(data1.Rows[row].Cells[5].Value);


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "UPDATE product SET purchaseprice='" + pp + "', saleprice='" + sp + "', total='" + tq + "', remaining='"+rq+"' WHERE cname = '" + cname + "' and name='" + name + "'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show(cname + " " + name + " has been updated in your record.");
                loaddata();
            }
        }

        private void data1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(column3_keypress);
            if (data1.CurrentCell.ColumnIndex == 2 || data1.CurrentCell.ColumnIndex == 3 || data1.CurrentCell.ColumnIndex == 4 || data1.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(column3_keypress);
                }
            }
        }
        private void column3_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;
        }
    }
}
