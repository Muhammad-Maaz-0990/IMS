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
    public partial class addpurpose : Form
    {
        public addpurpose()
        {
            InitializeComponent();
        }
        String datasource = "Data Source=MDdb.db;Version=3;";
        private void addpurpose_Load(object sender, EventArgs e)
        {
            get();
        }

        public void get()
        {
            data1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                string qry = "SELECT * FROM expcate ORDER BY Purpose ASC";
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
                data1.Rows[i].Cells[0].Value = i + 1;
                data1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "INSERT INTO expcate ([Purpose]) VALUES (@cname)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@cname", textBox5.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Purpose Added Successfully...");
                textBox5.Text = "";
            }
            else
                MessageBox.Show("Please Enter Purpose..!!");
            get();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Rows.Count > 0)
            {
                int row = data1.CurrentCell.RowIndex;
                String cname = data1.Rows[row].Cells[1].Value.ToString();


                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    String query = "DELETE FROM expcate WHERE Purpose = '" + cname + "' ";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                data1.Rows.RemoveAt(row);
                MessageBox.Show(cname + " has been deleted from your record.");
                get();
            }
            else
                MessageBox.Show("Please add a Purpose first...!!");
        }
    }
}
