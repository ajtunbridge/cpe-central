﻿#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface ITurnoverTargetView : IView
    {
        event EventHandler RefreshData;

        void DisplayModel(TurnoverTargetViewModel model);
    }

    public partial class StartPageTargetView : ViewBase, ITurnoverTargetView
    {
        private readonly Color _lowColorEnd = Color.IndianRed;
        private readonly Color _lowColorStart = Color.Firebrick;

        private readonly Color _mediumColorEnd = Color.Gold;
        private readonly Color _mediumColorStart = Color.LightGoldenrodYellow;
        private readonly TurnoverTargetPresenter _presenter;
        private readonly Timer _refreshTimer;

        private readonly Color _targetReachedColorEnd = Color.LightGreen;
        private readonly Color _targetReachedColorStart = Color.ForestGreen;

        public StartPageTargetView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new TurnoverTargetPresenter(this);

                _refreshTimer = new Timer();
                _refreshTimer.Interval = 3600000; // update every hour
                _refreshTimer.Tick += (o, e) => OnRefreshData();
                _refreshTimer.Start();
            }
        }

        #region ITurnoverTargetView Members

        public event EventHandler RefreshData;

        public void DisplayModel(TurnoverTargetViewModel model)
        {
            Cursor = Cursors.Default;

            updateNowLinkLabel.Enabled = true;

            currentMonthEasyProgressBar.Value = model.CurrentMonthProgress;
            lastMonthEasyProgressBar.Value = model.LastMonthProgress;
            fiscalYearEasyProgressBar.Value = model.FiscalYearProgress;

            toolTip.SetToolTip(currentMonthEasyProgressBar, model.TotalTurnoverThisMonth.ToString("C"));

            toolTip.SetToolTip(lastMonthEasyProgressBar, model.TotalTurnoverLastMonth.ToString("C"));

            toolTip.SetToolTip(fiscalYearEasyProgressBar, model.TotalTurnoverFiscalYear.ToString("C"));

            if (model.CurrentMonthProgress < 60) {
                currentMonthEasyProgressBar.ProgressGradient.ColorStart = _lowColorStart;
                currentMonthEasyProgressBar.ProgressGradient.ColorEnd = _lowColorEnd;
            }
            else if (model.CurrentMonthProgress >= 60 && model.CurrentMonthProgress < 100) {
                currentMonthEasyProgressBar.ProgressGradient.ColorStart = _mediumColorStart;
                currentMonthEasyProgressBar.ProgressGradient.ColorEnd = _mediumColorEnd;
            }
            else {
                currentMonthEasyProgressBar.ProgressGradient.ColorStart = _targetReachedColorStart;
                currentMonthEasyProgressBar.ProgressGradient.ColorEnd = _targetReachedColorEnd;
            }

            if (model.LastMonthProgress < 60) {
                lastMonthEasyProgressBar.ProgressGradient.ColorStart = _lowColorStart;
                lastMonthEasyProgressBar.ProgressGradient.ColorEnd = _lowColorEnd;
            }
            else if (model.LastMonthProgress >= 60 && model.LastMonthProgress < 100) {
                lastMonthEasyProgressBar.ProgressGradient.ColorStart = _mediumColorStart;
                lastMonthEasyProgressBar.ProgressGradient.ColorEnd = _mediumColorEnd;
            }
            else {
                lastMonthEasyProgressBar.ProgressGradient.ColorStart = _targetReachedColorStart;
                lastMonthEasyProgressBar.ProgressGradient.ColorEnd = _targetReachedColorEnd;
            }


            if (model.FiscalYearProgress < 60)
            {
                fiscalYearEasyProgressBar.ProgressGradient.ColorStart = _lowColorStart;
                fiscalYearEasyProgressBar.ProgressGradient.ColorEnd = _lowColorEnd;
            }
            else if (model.FiscalYearProgress >= 60 && model.FiscalYearProgress < 100)
            {
                fiscalYearEasyProgressBar.ProgressGradient.ColorStart = _mediumColorStart;
                fiscalYearEasyProgressBar.ProgressGradient.ColorEnd = _mediumColorEnd;
            }
            else
            {
                fiscalYearEasyProgressBar.ProgressGradient.ColorStart = _targetReachedColorStart;
                fiscalYearEasyProgressBar.ProgressGradient.ColorEnd = _targetReachedColorEnd;
            }
        }

        #endregion

        ~StartPageTargetView()
        {
            _refreshTimer.Dispose();
        }

        private void OnRefreshData()
        {
            currentMonthEasyProgressBar.Value = 0;
            lastMonthEasyProgressBar.Value = 0;
            fiscalYearEasyProgressBar.Value = 0;
            toolTip.SetToolTip(currentMonthEasyProgressBar, "refreshing...");
            toolTip.SetToolTip(currentMonthEasyProgressBar, "refreshing...");

            updateNowLinkLabel.Enabled = false;

            EventHandler handler = RefreshData;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void TurnoverTargetView_Load(object sender, EventArgs e)
        {
            OnRefreshData();
        }

        private void updateNowLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OnRefreshData();
        }
    }
}