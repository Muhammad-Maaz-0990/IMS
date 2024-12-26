using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Rendering;

namespace MDmobile
{
    public partial class BarcodeForm : Form
    {
        public BarcodeForm(string product)
        {
            InitializeComponent();
            generate_barcode(product);
            label1.Text = product + " Added Successfully";
        }

        private void generate_barcode(string product)
        {
            // Check if the product string is null or empty
            if (string.IsNullOrEmpty(product))
            {
                MessageBox.Show("Product code cannot be null or empty.");
                return;
            }

            // Check if pictureBox1 is initialized
            if (pictureBox1 == null)
            {
                MessageBox.Show("PictureBox is not initialized.");
                return;
            }

            try
            {
                // Create a BarcodeWriter instance with Bitmap as the output type
                var barcodeWriter = new BarcodeWriter<Bitmap>
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Width = 300,
                        Height = 150
                    }
                };

                // Generate the barcode as a Bitmap
                using (Bitmap bitmap = barcodeWriter.Write(product))
                {
                    // Set the PictureBox's Image property to the generated bitmap
                    pictureBox1.Image = new Bitmap(bitmap); // Create a new Bitmap to avoid disposing the original
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating barcode: " + ex.Message);
            }
        }
        private void BarcodeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
