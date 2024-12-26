using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDmobile
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.OrangeRed;
        }

        private void label1_DragLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DarkSlateGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label1_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void label1_Move(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
