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
    public partial class NewVersionDialog : Form
    {
        public NewVersionDialog()
        {
            InitializeComponent();

            base.Font = Session.AppFont;
        }
    }
}
