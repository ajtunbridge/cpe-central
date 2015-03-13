#region Using directives

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
        private readonly TurnoverTargetViewPresenter _presenter;
        private readonly Timer _refreshTimer;

        private readonly Color _targetReachedColorEnd = Color.LightGreen;
        private readonly Color _targetReachedColorStart = Color.ForestGreen;

        public StartPageTargetView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new TurnoverTargetViewPresenter(this);

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
            currentMonthEasyProgressBar.Value = model.CurrentMonthProgress;
            lastMonthEasyProgressBar.Value = model.LastMonthProgress;

            loadingPictureBox.Visible = false;

            label4.Text = "updated at " + DateTime.Now.ToShortTimeString();

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
        }

        #endregion

        ~StartPageTargetView()
        {
            _refreshTimer.Dispose();
        }

        private void OnRefreshData()
        {
            loadingPictureBox.Visible = true;

            EventHandler handler = RefreshData;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void TurnoverTargetView_Load(object sender, EventArgs e)
        {
            OnRefreshData();
        }
    }
}