#region Using directives

using System;
using CPECentral.CustomEventArgs;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IStartPageFindToolBoxView : IView
    {
        event EventHandler<StringEventArgs> PerformSearch;
        void DisplayResults(StartPageFindToolBoxViewModel model);
    }

    public partial class StartPageFindToolBoxView : ViewBase, IStartPageFindToolBoxView
    {
        private readonly StartPageFindToolBoxViewPresenter _presenter;

        public StartPageFindToolBoxView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new StartPageFindToolBoxViewPresenter(this);
            }
        }

        #region IStartPageFindToolBoxView Members

        public event EventHandler<StringEventArgs> PerformSearch;

        public void DisplayResults(StartPageFindToolBoxViewModel model)
        {
            drawingNumberMatchesComboBox.Items.Clear();

            goButton.Text = "Go";
            goButton.Enabled = true;

            foreach (StartPageFindToolBoxViewModelItem item in model.Results) {
                drawingNumberMatchesComboBox.Items.Add(item);
            }

            if (drawingNumberMatchesComboBox.Items.Count == 0) {
                locationTextBox.Text = "None found";
                drawingNumberMatchesComboBox.Enabled = false;
                return;
            }

            drawingNumberMatchesComboBox.Enabled = true;
            drawingNumberMatchesComboBox.SelectedIndex = 0;
        }

        #endregion

        protected virtual void OnPerformSearch(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = PerformSearch;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void drawingNumberEnhancedTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            goButton.PerformClick();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (drawingNumberEnhancedTextBox.Text.Length == 0) {
                DialogService.Notify("Please enter the drawing number to search for!");
                return;
            }

            goButton.Text = "searching...";
            goButton.Enabled = false;

            drawingNumberMatchesComboBox.Enabled = false;

            OnPerformSearch(new StringEventArgs(drawingNumberEnhancedTextBox.Text.Trim()));
        }

        private void drawingNumberMatchesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = drawingNumberMatchesComboBox.SelectedItem as StartPageFindToolBoxViewModelItem;

            locationTextBox.Text = item.Location.IsNullOrWhitespace()
                ? "No tooling"
                : item.Location;
        }
    }
}