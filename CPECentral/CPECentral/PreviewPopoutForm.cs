#region Using directives

using System.Windows.Forms;
using CPECentral.Properties;

#endregion

namespace CPECentral
{
    public partial class PreviewPopoutForm : Form
    {
        private Control _previewControl;

        public PreviewPopoutForm(Control control)
        {
            InitializeComponent();

            Location = Settings.Default.PreviewFormLocation;
            Size = Settings.Default.PreviewFormSize;
            WindowState = Settings.Default.PreviewFormState;

            PreviewControl = control;
        }

        public Control PreviewControl
        {
            get { return _previewControl; }
            set
            {
                Controls.Remove(_previewControl);

                _previewControl = value;

                Controls.Add(_previewControl);

                _previewControl.Dock = DockStyle.Fill;
                _previewControl.BringToFront();
            }
        }

        private void PreviewPopoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized) {
                Settings.Default.PreviewFormLocation = Location;
                Settings.Default.PreviewFormSize = Size;
            }

            Settings.Default.PreviewFormState = WindowState;

            Settings.Default.Save();
        }
    }
}