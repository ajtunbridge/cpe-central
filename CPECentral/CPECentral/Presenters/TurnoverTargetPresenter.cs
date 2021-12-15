#region Using directives

using System;
using System.ComponentModel;
using System.Threading;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class TurnoverTargetPresenter
    {
        private readonly ITurnoverTargetView _view;

        public TurnoverTargetPresenter(ITurnoverTargetView view)
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
            if (e.Result is Exception) {
                var ex = e.Result as Exception;
                string msg = ex.InnerException?.Message ?? ex.Message;
                _view.DialogService.ShowError(msg);
                return;
            }

            var model = e.Result as TurnoverTargetViewModel;

            _view.DisplayModel(model);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);

            try {
                decimal targetAmount = 0;

                using (var cpe = new CPEUnitOfWork()) {
                    targetAmount = cpe.ClientSettings.GetTurnoverTargetAmount();
                }

                using (var tricorn = new TricornDataProvider()) {
                    var monthToday = DateTime.Today.Month;
                    int year = DateTime.Today.Year;

                    //if (monthToday < 4)
                    //{
                    //    year -= 1;
                    //}

                    var startOfFiscalYear = new DateTime(year, 1, 1);
                    
                    decimal turnoverThisMonth = tricorn.GetTurnoverThisMonth() ?? 0;
                    decimal turnoverLastMonth = tricorn.GetTurnoverLastMonth() ?? 0;
                    decimal turnoverFiscalYear = tricorn.GetTurnoverForPeriod(startOfFiscalYear, DateTime.Now) ?? 0;

                    int currentMonthProgress = 0, lastMonthProgress = 0, fiscalYearProgress = 0;

                    if (turnoverThisMonth > 0) {
                        currentMonthProgress = Convert.ToInt32((turnoverThisMonth/targetAmount)*100);
                        currentMonthProgress = Math.Min(currentMonthProgress, 100);
                    }

                    if (turnoverLastMonth > 0) {
                        lastMonthProgress = Convert.ToInt32((turnoverLastMonth/targetAmount)*100);
                        lastMonthProgress = Math.Min(lastMonthProgress, 100);
                    }

                    if (turnoverFiscalYear > 0)
                    {
                        var fiscalYearTarget = targetAmount * 12;

                        fiscalYearProgress = Convert.ToInt32((turnoverFiscalYear/fiscalYearTarget)*100);
                        fiscalYearProgress = Math.Min(fiscalYearProgress, 100);
                    }

                    var model = new TurnoverTargetViewModel(currentMonthProgress, lastMonthProgress, fiscalYearProgress, turnoverThisMonth, turnoverLastMonth, turnoverFiscalYear);

                    e.Result = model;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }
    }
}