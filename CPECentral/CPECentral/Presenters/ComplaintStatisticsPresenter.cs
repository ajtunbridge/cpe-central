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

            _view.ParametersChanged += ViewParametersChanged;
        }

        private void ViewParametersChanged(object sender, EventArgs e)
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

            IEnumerable<Complaint> complaints = null;

            switch (args.Type)
            {
                case ComplaintStatisticsView.ComplaintType.Customer:
                    complaints = qms.GetCustomerComplaints(startDate, today);
                    break;
                case ComplaintStatisticsView.ComplaintType.Internal:
                    complaints = qms.GetInternalComplaints(startDate, today);
                    break;
                case ComplaintStatisticsView.ComplaintType.Supplier:
                    complaints = qms.GetSupplierComplaints(startDate, today);
                    break;
            }

            var categories = complaints.Select(c => c.Category).Distinct();

            int totalCount = complaints.Count();

            var model = new ComplaintStatisticsViewModel();

            foreach (var category in categories)
            {
                var results = complaints.Where(c => c.Category == category);

                int count = results.Count();

                var percentage = (double)count / totalCount;

                var result = new ComplaintStatisticsViewModel.Result();
                result.Category = category + " (" + count + ")";
                result.Percentage = percentage * 100;

                model.Results.Add(result);
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
