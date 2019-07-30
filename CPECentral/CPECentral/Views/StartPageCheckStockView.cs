#region Using directives

using System;
using System.Collections.Generic;
using CPECentral.CustomEventArgs;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface ICheckStockLevelsView
    {
        event EventHandler<StringEventArgs> PerformSearch;

        void DisplayResults(List<CheckStockLevelsViewModel> modelItems);
    }

    public partial class StartPageCheckStockView : ViewBase, ICheckStockLevelsView
    {
        private readonly CheckStockLevelsPresenter _presenter;

        public StartPageCheckStockView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new CheckStockLevelsPresenter(this);
                resultsTreeListView.SmallImageList.Images.Add("parent", Resources.FolderClosedIcon_16x16);
                resultsTreeListView.SmallImageList.Images.Add("child", Resources.GenericFileIcon);
                nameBatchNumberOlvColumn.ImageGetter = ImageGetter;
            }
        }

        #region ICheckStockLevelsView Members

        public event EventHandler<StringEventArgs> PerformSearch;

        public void DisplayResults(List<CheckStockLevelsViewModel> modelItems)
        {
            resultsTreeListView.CanExpandGetter = o => {
                var item = o as CheckStockLevelsViewModel;
                return item.Children != null && item.Children.Count > 0;
            };

            resultsTreeListView.ChildrenGetter = o => {
                var item = o as CheckStockLevelsViewModel;
                return item.Children;
            };

            resultsTreeListView.EmptyListMsg = "No items found!";

            resultsTreeListView.SetObjects(modelItems);

            searchButton.Text = "Search";
            searchButton.Enabled = true;
            searchingPictureBox.Visible = false;
        }

        #endregion

        protected virtual void OnPerformSearch(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = PerformSearch;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchValueTextBox.Text.Length == 0) {
                DialogService.Notify("You have not entered a search value!");
                return;
            }

            resultsTreeListView.SetObjects(null);

            resultsTreeListView.EmptyListMsg = "Searching for " + searchValueTextBox.Text;

            searchButton.Text = "searching...";

            searchButton.Enabled = false;

            searchingPictureBox.Visible = true;

            OnPerformSearch(new StringEventArgs(searchValueTextBox.Text));
        }

        private object ImageGetter(object rowObject)
        {
            var model = rowObject as CheckStockLevelsViewModel;

            if (model.Children != null && model.Children.Count > 0) {
                return "parent";
            }

            return "child";
        }

        private void searchValueTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            searchButton.PerformClick();
        }

        private void searchValueTextBox_SizeChanged(object sender, EventArgs e)
        {
            searchButton.Left = searchValueTextBox.Right + 10;
        }
    }
}