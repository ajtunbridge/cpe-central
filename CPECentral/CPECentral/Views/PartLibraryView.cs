#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
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

                autoShowDrawingCheckBox.Checked = Settings.Default.AutomaticallyShowDrawing;

                resultsObjectListView.SmallImageList = new ImageList {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };

                resultsObjectListView.RowFormatter = (listItem) => {
                    var model = listItem.RowObject as PartLibraryViewModel;
                    if (!string.IsNullOrWhiteSpace(model.PathToDrawingFile)) {
                        listItem.ForeColor = Color.Firebrick;
                    }
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
            filePreviewPanel1.ClearPreview();

            if (resultsObjectListView.SelectedItem != null && Settings.Default.AutomaticallyShowDrawing) {
                var model = resultsObjectListView.SelectedItem.RowObject as PartLibraryViewModel;
                if (!string.IsNullOrWhiteSpace(model.PathToDrawingFile)) {
                    filePreviewPanel1.ShowFile(model.PathToDrawingFile);
                }
            }
        }

        private void resultsObjectListView_ItemActivate(object sender, EventArgs e)
        {
            Part part = (resultsObjectListView.SelectedObject as PartLibraryViewModel).Part;

            Session.MessageBus.Publish(new LoadPartMessage(part));
        }

        private void resultsObjectListView_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }

            var part = (e.Item.RowObject as PartLibraryViewModel).Part;

            var photo = Session.PartPartPhotoCache[part.Id];

            if (photo == null)
            {
                return;
            }

            var popupForm = new ImagePopupForm(photo);
            popupForm.Location = new Point(MousePosition.X + 20, MousePosition.Y + 20);
            popupForm.Show();
        }

        private void autoShowDrawingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutomaticallyShowDrawing = autoShowDrawingCheckBox.Checked;
            Settings.Default.Save();
        }
    }
}