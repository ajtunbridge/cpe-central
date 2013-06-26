using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Dialogs
{
    public partial class ImportMillingProgramDialog : Form
    {
        public ImportMillingProgramDialog()
        {
            InitializeComponent();
        }

        private void ImportMillingProgramDialog_Load(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                var millingGroup = uow.MachineGroups.GetByName("CNC Mills");

                nextProgramNumberLabel.Text = millingGroup.NextNumber.ToString("D4");
            }
        }
    }
}
