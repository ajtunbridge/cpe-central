using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

namespace CPECentral.Presenters
{
    public class TurnoverTargetViewPresenter
    {
        private readonly ITurnoverTargetView _view;

        public TurnoverTargetViewPresenter(ITurnoverTargetView view)
        {
            _view = view;

            _view.RefreshData += _view_RefreshData;
        }

        private void _view_RefreshData(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var model = e.Result as TurnoverTargetViewModel;

            _view.DisplayModel(model);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal targetAmount = 0;

            using (var cpe = new CPEUnitOfWork()) {
                targetAmount = cpe.ClientSettings.GetTurnoverTargetAmount();
            }

            using (var tricorn = new TricornDataProvider()) {
                var turnoverThisMonth = tricorn.GetTurnoverThisMonth() ?? 0;
                var turnoverLastMonth = tricorn.GetTurnoverLastMonth() ?? 0;

                int currentMonthProgress = 0, lastMonthProgress = 0;

                if (turnoverThisMonth > 0) {
                    currentMonthProgress = Convert.ToInt32((turnoverThisMonth/targetAmount)*100);
                    currentMonthProgress = Math.Min(currentMonthProgress, 100);
                }

                if (turnoverLastMonth > 0) {

                    lastMonthProgress = Convert.ToInt32((turnoverLastMonth/targetAmount)*100);
                    lastMonthProgress = Math.Min(lastMonthProgress, 100);
                }

                var model = new TurnoverTargetViewModel(currentMonthProgress, lastMonthProgress);

                e.Result = model;
            }
        }
    }
}