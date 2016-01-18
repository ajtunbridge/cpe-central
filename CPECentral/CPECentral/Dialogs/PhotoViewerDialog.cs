using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Dialogs
{
    public partial class PhotoViewerDialog : Form
    {
        public PhotoViewerDialog(Image image)
        {
            InitializeComponent();

            pictureBox.Image = image;
        }

        private void PhotoViewerDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
