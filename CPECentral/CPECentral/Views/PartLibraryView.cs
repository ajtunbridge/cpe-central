#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.Controls;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartLibraryView : IView
    {
        event EventHandler<StringEventArgs> PerformSearch;
        void DisplayResults(IEnumerable<PartLibraryViewModel> results);
    }

    [DefaultEvent("PartSelected")]
    public partial class PartLibraryView : ViewBase, IPartLibraryView
    {
        private readonly PartLibraryViewPresenter _presenter;

        public PartLibraryView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new PartLibraryViewPresenter(this);

                resultsObjectListView.SmallImageList = new ImageList {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };

                resultsObjectListView.SmallImageList.Images.Add("PartIcon", Resources.PartIcon_16x16);
            }
        }

        #region IPartLibraryView Members

        public event EventHandler<StringEventArgs> PerformSearch;

        public void DisplayResults(IEnumerable<PartLibraryViewModel> results)
        {
            resultsObjectListView.EmptyListMsg = "No parts found!";

            searchButton.Enabled = true;

            searchButton.Text = "Go";

            searchingBarPictureBox.Visible = false;

            drawingNumberOlvColumn.ImageKey = "PartIcon";

            resultsObjectListView.SetObjects(results);

            resultsObjectListView.AlwaysGroupByColumn = groupOlvColumn;
            resultsObjectListView.BuildGroups();
        }

        #endregion

        public event EventHandler<PartEventArgs> PartSelected;

        protected virtual void OnPartSelected(PartEventArgs e)
        {
            EventHandler<PartEventArgs> handler = PartSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnPerformSearch(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = PerformSearch;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultsObjectListView.SetObjects(null);
            resultsObjectListView.EmptyListMsg = "Searching  for " + searchValueTextBox.Text;

            searchButton.Text = "Searching...";

            searchButton.Enabled = false;

            searchingBarPictureBox.Visible = true;

            OnPerformSearch(new StringEventArgs(searchValueTextBox.Text));
        }

        private void searchValueTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void searchValueTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            searchButton.PerformClick();
        }

        private void resultsObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            if (resultsObjectListView.SelectedObject == null) {
                filePreviewPanel1.ClearPreview();
            }
            else {
                var item = resultsObjectListView.SelectedObject as PartLibraryViewModel;
                if (string.IsNullOrWhiteSpace(item.PathToDrawingFile)) {
                    filePreviewPanel1.ClearPreview();
                    return;
                }
                filePreviewPanel1.ShowFile(item.PathToDrawingFile);
            }
        }

        private void resultsObjectListView_ItemActivate(object sender, EventArgs e)
        {
            Part part = (resultsObjectListView.SelectedObject as PartLibraryViewModel).Part;

            Session.MessageBus.Publish(new LoadPartMessage(part));
        }

        private void resultsObjectListView_CellToolTipShowing(object sender, BrightIdeasSoftware.ToolTipShowingEventArgs e)
        {
            // only display popup image if control key is pressed
            if (Control.ModifierKeys != Keys.Control) {
                return;
            }

            if (e.ColumnIndex != 0)
            {
                return;
            }

            var versionPhoto = (e.Item.RowObject as PartLibraryViewModel).CurrentVersionPhoto;

            if (versionPhoto == null)
            {
                return;
            }

            var popupForm = new ImagePopupForm(versionPhoto);
            popupForm.Location = new Point(MousePosition.X - 1, MousePosition.Y - 1);
            popupForm.Show();
        }
    }
}