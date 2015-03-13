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
        private const int CS_DROPSHADOW = 0x20000;

        public ImagePopupForm(Image image)
        {
            InitializeComponent();

            pictureBox.Image = image;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void ImagePopupForm_MouseLeave(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Close();
        }
    }
}
