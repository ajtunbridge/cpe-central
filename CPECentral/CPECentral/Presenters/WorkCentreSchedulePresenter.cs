using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;
using Tricorn;
using Customer = CPECentral.Data.EF5.Customer;

namespace CPECentral.Presenters
{
    public class WorkCentreSchedulePresenter
    {
        private IWorkCentreScheduleView _view;

        public WorkCentreSchedulePresenter(IWorkCentreScheduleView view)
        {
            _view = view;
            _view.RetrieveMachines += _view_RetrieveMachines;
            _view.MachineSelected += _view_MachineSelected;
            _view.PartSelected += ViewPartSelected;
        }

        private void ViewPartSelected(object sender, EventArgs e)
        {
            using (BusyCursor.Show())
            {
                if (_view.ShowJobTotalCost)
                {
                    using (var tricorn = new TricornDataProvider())
                    {
                        _view.ShowJobTotalCost = false;
                        var worder = tricorn.GetWorksOrdersByUserReference(_view.SelectedJob.WorksOrderNumber).SingleOrDefault();

                        var totalValue = worder.Batch_Total_Cost.Value.ToString("C");

                        var msg = $"The value of this job is {totalValue}";

                        _view.DialogService.Notify(msg);

                        return;
                    }
                }

                using (var cpe = new CPEUnitOfWork())
                {
                    var part = cpe.Parts.GetWhereDrawingNumberMatches(_view.SelectedJob.DrawingNumber).FirstOrDefault();

                    if (part == null)
                    {
                        var okToAdd =
                            _view.DialogService.AskQuestion(
                                "This part doesn't appear to be in the system yet!\n\nWould you like to add it now?");

                        if (okToAdd)
                        {
                            if (!AppSecurity.Check(AppPermission.ManageParts, true))
                            {
                                return;
                            }

                            using (var addPartDialog = new AddPartDialog(_view.SelectedJob.WorksOrderNumber))
                            {
                                addPartDialog.ShowDialog(_view.ParentForm);
                            }
                        }
                    }
                    else
                    {
                        Session.MessageBus.Publish(new LoadPartMessage(part));
                    }
                }
            }
        }

        private void _view_RetrieveMachines(object sender, EventArgs e)
        {
            var retrieveMachinesWorker = new BackgroundWorker();
            retrieveMachinesWorker.DoWork += RetrieveMachinesWorker_DoWork;
            retrieveMachinesWorker.RunWorkerCompleted += RetrieveMachinesWorker_RunWorkerCompleted;
            retrieveMachinesWorker.RunWorkerAsync();
        }

        private void RetrieveMachinesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                var ex = e.Result as Exception;

            }
            else
            {
                _view.DisplayMachines(e.Result as IEnumerable<WCentre>);
            }
        }

        private void RetrieveMachinesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var cpe = new CPEUnitOfWork())
            {
                var workCentres = cpe.EmployeeWorkCentres.GetEmployeeWorkCentreReferences(Session.CurrentEmployee.Id);

                using (var tricorn = new TricornDataProvider())
                {
                    var wc = tricorn.GetWorkCentres();

                    var machines = workCentres.Select(id => wc.Single(w => w.WCentre_Reference == id)).ToList();

                    e.Result = machines.OrderBy(m => m.Name);
                }
            }
        }

        private void _view_MachineSelected(object sender, EventArgs e)
        {
            var getJobsWorker = new BackgroundWorker();
            getJobsWorker.DoWork += GetJobsWorker_DoWork;
            getJobsWorker.RunWorkerCompleted += GetJobsWorker_RunWorkerCompleted;

            object args = null;

            if (_view.SelectedMachine != null)
            {
                args = _view.SelectedMachine.WCentre_Reference;
            }
            else
            {
                args = _view.AllMachines.Skip(1).Select(m => m.WCentre_Reference);
            }

            getJobsWorker.RunWorkerAsync(args);
        }

        private void GetJobsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {

            }
            else
            {
                _view.DisplayModel(e.Result as WorkCentreScheduleViewModel);
            }
        }

        private void GetJobsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var tricorn = new TricornDataProvider())
            {
                var model = new WorkCentreScheduleViewModel();

                var machineReferences = new List<int>();

                if (e.Argument is int)
                {
                    machineReferences.Add((int)e.Argument);
                }
                else
                {
                    machineReferences.AddRange(e.Argument as IEnumerable<int>);
                }

                foreach (var machineReference in machineReferences)
                {
                    var nextJobs = tricorn.GetNextJobsForWorkCentre(machineReference);

                    foreach (var nextJob in nextJobs)
                    {
                        if (model.NextJobs.Any(j => j.WorksOrderNumber == nextJob.User_Reference))
                            continue;

                        var job = new WorkCentreScheduleViewModel.ScheduledJob();
                        job.WorksOrderNumber = nextJob.User_Reference;
                        job.DrawingNumber = nextJob.Drawing_Number;
                        job.Version = nextJob.Drawing_Issue;
                        job.Name = nextJob.Description;
                        job.DueOn = nextJob.Delivery.Value;
                        job.ScheduledStart = nextJob.ScheduledStart;
                        job.ScheduledEnd = nextJob.Current_End_Date;
                        
                        model.AddJob(job);
                    }
                }

                e.Result = model;
            }
        }
    }
}
