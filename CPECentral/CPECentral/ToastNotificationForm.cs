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
    public partial class ToastNotificationForm : Form
    {
        private int _secondsToShow = 0;
        private Timer _closeTimer;

        public ToastNotificationForm(int secondsToShow, string message)
        {
            InitializeComponent();

            _secondsToShow = secondsToShow;
            messageLabel.Text = message;

            Load += ToastNotificationForm_Load;
        }

        void ToastNotificationForm_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);

            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            _closeTimer = new Timer();
            _closeTimer.Interval = _secondsToShow * 1000;
            _closeTimer.Tick += closeTimer_Tick;
            _closeTimer.Start();
        }

        void closeTimer_Tick(object sender, EventArgs e)
        {
            _closeTimer.Dispose();

            Close();
        }
    }
}
