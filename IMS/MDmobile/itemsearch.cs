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
    public partial class itemsearch : Form
    {
        public itemsearch(string cate,int pg)
        {
            InitializeComponent();
            cat = cate;
            pag = pg;

        }
                String datasource = "Data Source=MDdb.db;Version=3;";
                String cat;
                int pag;
        private void button1_Click(object sender, EventArgs e)
        {
           /* String qry;
            if(cat=="All")
                qry = "SELECT * FROM product WHERE name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            else
                qry = "SELECT * FROM product WHERE cname LIKE '%" + cat + "%' AND name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            
            
            if (textBox2.Text != "" )
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
                    data1.Rows[i].Cells[0].Value = i + 1;
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1];
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][0];
                }
            }
            else
                MessageBox.Show("Please Enter Company name or Product name to search !!");*/
        }

        private void data1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String qry;
            if (cat == "All")
                qry = "SELECT * FROM product WHERE name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            else
                qry = "SELECT * FROM product WHERE cname LIKE '%" + cat + "%' AND name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";


            if (textBox2.Text != "")
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
                    data1.Rows[i].Cells[1].Value = dt.Rows[i][1];
                }
            }
                
        }

        private void itemsearch_Load(object sender, EventArgs e)
        {

        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                data1.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                data1.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int row = data1.CurrentCell.RowIndex;
                String nm = data1.Rows[row].Cells[1].Value.ToString();
                String cat = data1.Rows[row].Cells[0].Value.ToString();
                if (pag == 1)
                {
                    Billing.cat = cat;
                    Billing.instance.tb1.Text = nm;

                    this.Close();
                }
                else if (pag == 2)
                {
                    cusbill.cat = cat;
                    cusbill.instance.tb1.Text = nm;
                    this.Close();
                }
                else if (pag == 3)
                {
                    addpitems.cat = cat;
                    addpitems.instance.tb1.Text = nm;
                    this.Close();
                }
                else if (pag == 4)
                {
                    salereport.cat = cat;
                    salereport.instance.tb1.Text = nm;

                    this.Close();
                }
            }
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = data1.CurrentCell.RowIndex;
            String nm = data1.Rows[row].Cells[1].Value.ToString();
            String cat = data1.Rows[row].Cells[0].Value.ToString();
            if (pag == 1)
            {
                Billing.cat = cat;
                Billing.instance.tb1.Text = nm;

                this.Close();
            }
            else if (pag == 2)
            {
                cusbill.cat = cat;
                cusbill.instance.tb1.Text = nm;
                this.Close();
            }
            else if (pag == 3)
            {
                addpitems.cat = cat;
                addpitems.instance.tb1.Text = nm;
                this.Close();
            }
            else if (pag == 4)
            {
                salereport.cat = cat;
                salereport.instance.tb1.Text = nm;

                this.Close();
            }
        }

        private void data1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = data1.CurrentCell.RowIndex;
                String nm = data1.Rows[row].Cells[1].Value.ToString();
                String cat = data1.Rows[row].Cells[0].Value.ToString();
                if (pag == 1)
                {
                    Billing.cat = cat;
                    Billing.instance.tb1.Text = nm;

                    this.Close();
                }
                else if (pag == 2)
                {
                    cusbill.cat = cat;
                    cusbill.instance.tb1.Text = nm;
                    this.Close();
                }
                else if (pag == 3)
                {
                    addpitems.cat = cat;
                    addpitems.instance.tb1.Text = nm;
                    this.Close();
                }
                else if (pag == 4)
                {
                    salereport.cat = cat;
                    salereport.instance.tb1.Text = nm;

                    this.Close();
                }
            }
        
        }
    }
}
