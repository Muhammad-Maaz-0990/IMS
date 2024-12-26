using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollManagementSystem
{
    public partial class PictureboxButton : PictureBox
    {
        public PictureboxButton()
        {
            InitializeComponent();
        }
        private Image normal;
        private Image hover;
        public Image imagenormal
        {
            get { return normal; }
            set{normal=value;}
        }
        public Image imagehover
        {
            get { return hover; }
            set { hover = value; }
        }

        private void PictureboxButton_MouseHover(object sender, EventArgs e)
        {
            this.Size = new Size(30,30);
            this.Image = hover;
        }

        private void PictureboxButton_MouseLeave(object sender, EventArgs e)
        {
            this.Size = new Size(28, 28);
            this.Image = normal;
        }
    }
}
