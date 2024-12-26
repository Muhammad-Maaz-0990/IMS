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
    public partial class cusearch : Form
    {
        public cusearch(int pg)
        {
            InitializeComponent();
            x = pg;
        }
        int x ;
        String datasource = "Data Source=MDdb.db;Version=3;";
        private void cusearch_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String qry;
            qry = "SELECT * FROM customer WHERE name LIKE '%" + textBox2.Text + "%' ORDER BY name ASC";
            
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
                    data1.Rows[i].Cells[2].Value = dt.Rows[i][2];
                }
            }
        }

        private void data1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void data1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void data1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = data1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                String nm = data1.Rows[row].Cells[1].Value.ToString();
                float re = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
                if (x == 1)
                {
                    cusbill.cusid = id;
                    cusbill.instance.tb2.Text = nm;
                    cusbill.cusremain = re;
                    cusbill.cusname = nm;
                    cusbill.instance.tb3.Text = re.ToString();
                    this.Close();
                }
                else if (x == 2)
                {
                    cusledgercs.cusid = id;
                    cusledgercs.instance.tb1.Text = nm;
                    cusledgercs.cusremain = re;
                    cusledgercs.cusname = nm;
                    cusledgercs.instance.tb2.Text = re.ToString();
                    this.Close();
                }
                else if (x == 3)
                {
                    cuscash.cusid = id;
                    cuscash.instance.tb1.Text = nm;
                    cuscash.instance.tb2.Text = re.ToString();
                    this.Close();
                }
                else if (x == 4)
                {
                    editbill.cusid = id;
                    editbill.instance.tb2.Text = re.ToString();
                    editbill.instance.tb1.Text = nm;
                    this.Close();
                }
            }
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
                int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
                String nm = data1.Rows[row].Cells[1].Value.ToString();
                float re = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
                if (x == 1)
                {
                    cusbill.cusid = id;
                    cusbill.instance.tb2.Text = nm;
                    cusbill.cusremain = re;
                    cusbill.cusname = nm;
                    cusbill.instance.tb3.Text = re.ToString();
                    this.Close();
                }
                else if (x == 2)
                {
                    cusledgercs.cusid = id;
                    cusledgercs.instance.tb1.Text = nm;
                    cusledgercs.cusremain = re;
                    cusledgercs.cusname = nm;
                    cusledgercs.instance.tb2.Text = re.ToString();
                    this.Close();
                }
                else if (x == 3)
                {
                    cuscash.cusid = id;
                    cuscash.instance.tb1.Text = nm;
                    cuscash.instance.tb2.Text = re.ToString();
                    this.Close();
                }
                else if (x == 4)
                {
                    editbill.cusid = id;
                    editbill.instance.tb2.Text = re.ToString();
                    editbill.instance.tb1.Text = nm;
                    this.Close();
                }
            }
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = data1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(data1.Rows[row].Cells[0].Value);
            String nm = data1.Rows[row].Cells[1].Value.ToString();
            float re = float.Parse(data1.Rows[row].Cells[2].Value.ToString());
            if (x == 1)
            {
                cusbill.cusid = id;
                cusbill.instance.tb2.Text = nm;
                cusbill.cusremain = re;
                cusbill.cusname = nm;
                cusbill.instance.tb3.Text = re.ToString();
                this.Close();
            }
            else if (x == 2)
            {
                cusledgercs.cusid = id;
                cusledgercs.instance.tb1.Text = nm;
                cusledgercs.cusremain = re;
                cusledgercs.cusname = nm;
                cusledgercs.instance.tb2.Text = re.ToString();
                this.Close();
            }
            else if (x == 3)
            {
                cuscash.cusid = id;
                cuscash.instance.tb1.Text = nm;
                cuscash.instance.tb2.Text = re.ToString();
                this.Close();
            }
            else if (x == 4)
            {
                editbill.cusid = id;
                editbill.instance.tb2.Text = re.ToString();
                editbill.instance.tb1.Text = nm;
                this.Close();
            }
        }

        private void data1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
