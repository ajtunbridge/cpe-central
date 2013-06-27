using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using nGenLibrary;

namespace CPECentral.Dialogs
{
    public partial class ImportMillingProgramDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly Operation _operation;
        private MachineGroup _millingGroup;

        public ImportMillingProgramDialog(Operation operation)
        {
            InitializeComponent();

            _operation = operation;
        }

        private void ImportMillingProgramDialog_Load(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                _millingGroup = uow.MachineGroups.GetByName("CNC Mills");

                nextProgramNumberLabel.Text = _millingGroup.NextNumber.ToString();
            }
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            var foundFile = false;
            using (BusyCursor.Show())
            {
                foreach (var fileName in Directory.GetFiles(Settings.Default.MillingProgramDirectory))
                {
                    var ext = Path.GetExtension(fileName).ToLower();

                    if (ext != ".h" && ext != ".txt")
                        continue;

                    var lastIndexOfDot = fileName.LastIndexOf(".");

                    if (lastIndexOfDot == -1)
                        continue;

                    var withoutExt = Path.GetFileNameWithoutExtension(fileName);

                    if (!withoutExt.All(char.IsNumber))
                        continue;

                    var fileNumber = Convert.ToInt32(withoutExt);

                    if (fileNumber != _millingGroup.NextNumber)
                        continue;

                    Session.DocumentService.QueueUpload(fileName, _operation);

                    using (var uow = new UnitOfWork())
                    {
                        _millingGroup.NextNumber += 1;

                        uow.MachineGroups.Update(_millingGroup);

                        uow.Commit();
                    }

                    foundFile = true;

                    break;
                }
            }

            if (foundFile)
            {
                Close();
            }
            else
            {
                _dialogService.Notify("Couldn't find program file in milling directory!");
            }
        }
    }
}