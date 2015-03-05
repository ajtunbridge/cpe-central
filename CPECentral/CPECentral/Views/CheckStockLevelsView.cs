using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

namespace CPECentral.Views
{
    public interface ICheckStockLevelsView
    {
        event EventHandler<StringEventArgs> PerformSearch;

        void DisplayResults(List<CheckStockLevelsViewModel> modelItems);
    }

    public partial class CheckStockLevelsView : ViewBase, ICheckStockLevelsView
    {
        public event EventHandler<StringEventArgs> PerformSearch;
        private readonly CheckStockLevelsViewPresenter _presenter;

        protected virtual void OnPerformSearch(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = PerformSearch;
            if (handler != null) {
                handler(this, e);
            }
        }

        public CheckStockLevelsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new CheckStockLevelsViewPresenter(this);
                resultsTreeListView.SmallImageList.Images.Add("parent", Resources.StockMaterialImage_16x16);
                resultsTreeListView.SmallImageList.Images.Add("child", Resources.BatchImage_16x16);
                nameBatchNumberOlvColumn.ImageGetter = ImageGetter;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchValueTextBox.Text.Length == 0) {
                DialogService.Notify("You have not entered a search value!");
                return;
            }

            searchButton.Text = "searching...";

            searchButton.Enabled = false;

            OnPerformSearch(new StringEventArgs(searchValueTextBox.Text));
        }

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

            resultsTreeListView.SetObjects(modelItems);

            searchButton.Text = "Search";
            searchButton.Enabled = true;
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