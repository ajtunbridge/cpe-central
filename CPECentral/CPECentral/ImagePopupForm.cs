using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral
{
    public partial class ImagePopupForm : Form
    {
        public ImagePopupForm(Image image)
        {
            InitializeComponent();

            pictureBox1.Image = image;
        }

        private void ImagePopupForm_MouseLeave(object sender, EventArgs e)
        {
            Close();
        }
    }
}
