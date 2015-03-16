#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace CPECentral
{
    public partial class ImagePopupForm : Form
    {
        private const int CS_DROPSHADOW = 0x20000;

        private readonly MouseHook _mouseHook;

        public ImagePopupForm(Image image)
        {
            InitializeComponent();

            pictureBox.Image = image;

            _mouseHook = new MouseHook();
            _mouseHook.MouseMovement += _mouseHook_MouseMovement;
            _mouseHook.StartMouseHook();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void _mouseHook_MouseMovement(object sender, MouseHookEventArgs e)
        {
            if (_mouseHook != null) {
                _mouseHook.StopMouseHook();
                _mouseHook.Dispose();
                Close();
            }
        }

        private void ImagePopupForm_MouseLeave(object sender, EventArgs e)
        {
            //Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //Close();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}