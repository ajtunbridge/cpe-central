using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.CustomEventArgs;
using CPECentral.QMS;
using CPECentral.QMS.Model;
using CPECentral.ViewModels;
using CPECentral.Views;

namespace CPECentral.Presenters
{
    public class ComplaintStatisticsPresenter
    {
        private readonly ComplaintStatisticsView _view;

        public ComplaintStatisticsPresenter(ComplaintStatisticsView view)
        {
            _view = view;

            _view.TimePeriodChanged += ViewTimePeriodChanged;
        }

        private void ViewTimePeriodChanged(object sender, EventArgs e)
        {
            var refreshWorker = new BackgroundWorker();
            refreshWorker.DoWork += RefreshWorker_DoWork;
            refreshWorker.RunWorkerCompleted += RefreshWorker_RunWorkerCompleted;

            var args = new WorkerArgs(_view.SelectedTimePeriod, _view.SelectedComplaintType);

            refreshWorker.RunWorkerAsync(args);
        }

        private void RefreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var model = e.Result as ComplaintStatisticsViewModel;

            if (model == null)
            {
                // TODO: handle exception
                return;
            }

            _view.DisplayModel(model);
        }

        private void RefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as WorkerArgs;

            DateTime today = DateTime.Today;

            DateTime startDate = today;

            switch (args.Period)
            {
                case ComplaintStatisticsView.TimePeriod.ThisMonth:
                    startDate = new DateTime(today.Year, today.Month, 1);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastThreeMonths:
                    startDate = today.AddMonths(-3);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastSixMonths:
                    startDate = today.AddMonths(-6);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastYear:
                    startDate = today.AddYears(-1);
                    break;
                case ComplaintStatisticsView.TimePeriod.AllTime:
                    startDate = DateTime.MinValue;
                    break;
            }

            var qms = new QMSDataProvider();

            var customerComplaints = qms.GetCustomerComplaints(startDate, today);
            var internalComplaints = qms.GetInternalComplaints(startDate, today);
            var supplierComplaints = qms.GetSupplierComplaints(startDate, today);

            var complaints = new[] {customerComplaints, internalComplaints, supplierComplaints};

            var model = new ComplaintStatisticsViewModel();

            for (int i = 0; i < complaints.Count(); i++)
            {
                var currentComplaints = complaints[i];

                var categories = currentComplaints.Select(c => c.Category).Distinct();

                int totalCount = currentComplaints.Count();

                foreach (var category in categories)
                {
                    var results = currentComplaints.Where(c => c.Category == category);

                    int count = results.Count();

                    var percentage = (double)count / totalCount;

                    var result = new ComplaintStatisticsViewModel.CategoryAndPercentage();
                    result.Category = category + " (" + count + ")";
                    result.Percentage = percentage * 100;

                    switch (i)
                    {
                        case 0: // customer complaints
                            model.CustomerResults.Add(result);
                            break;
                        case 1: // internal complaints
                            model.InternalResults.Add(result);
                            break;
                        case 2: // supplier complaints
                            model.SupplierResults.Add(result);
                            break;
                    }
                }
            }

            e.Result = model;
        }

        private class WorkerArgs
        {
            public ComplaintStatisticsView.TimePeriod Period { get; private set; }
            public ComplaintStatisticsView.ComplaintType Type { get; private set; }

            public WorkerArgs(ComplaintStatisticsView.TimePeriod period, ComplaintStatisticsView.ComplaintType type)
            {
                Period = period;
                Type = type;
            }
        }
    }
}
