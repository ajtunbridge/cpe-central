#region Using directives

using System;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class TurnoverGraphPresenter
    {
        private readonly TurnoverGraphView _view;

        public TurnoverGraphPresenter(TurnoverGraphView view)
        {
            _view = view;
        }

        public void RetrieveData()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                // TODO: handle exception
                return;
            }

            var model = e.Result as TurnoverGraphViewModel;

            _view.DisplayData(model);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var model = new TurnoverGraphViewModel();

            decimal targetAmount = 0;

            using (var cpe = new CPEUnitOfWork())
            {
                targetAmount = cpe.ClientSettings.GetTurnoverTargetAmount();
            }

            using (var tricorn = new TricornDataProvider())
            {
                int medianValue = 0;

                // get the turnover target percentages for the past 12 months
                for (var i = -11; i <= 0; i++)
                {
                    var month = DateTime.Today.AddMonths(i);

                    var start = new DateTime(month.Year, month.Month, 1);
                    var end = start.AddMonths(1).AddDays(-1);

                    var turnover = tricorn.GetTurnoverForPeriod(start, end);

                    var targetPercentage = Convert.ToInt32((turnover/targetAmount)*100);

                    //targetPercentage = Math.Min(targetPercentage, 100);

                    var point = new TurnoverGraphViewModel.GraphPoint(start.ToString("MMM"), targetPercentage);
                    model.GraphPoints.Add(point);

                    medianValue += targetPercentage;
                }

                model.MedianValue = medianValue/12;
            }

            e.Result = model;
        }
    }
}