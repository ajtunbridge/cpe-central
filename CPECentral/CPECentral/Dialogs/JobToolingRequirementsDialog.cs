using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using Tricorn;

namespace CPECentral.Dialogs
{
    public partial class JobToolingRequirementsDialog : Form
    {
        private readonly int _partId;

        public JobToolingRequirementsDialog(int partId)
        {
            InitializeComponent();

            _partId = partId;
        }

        private void JobToolingRequirementsDialog_Load(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var cpe = new CPEUnitOfWork();
            var tricorn = new TricornDataProvider();

            try
            {
               
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
            finally
            {
                cpe.Dispose();
                tricorn.Dispose();
            }
        }
    }
}
