#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartLibraryView3 : IView
    {
        event EventHandler<StringEventArgs> PerformSearch;
        void DisplayResults(IEnumerable<PartLibraryView3Model> results);
    }

    [DefaultEvent("PartSelected")]
    public partial class PartLibraryView3 : ViewBase, IPartLibraryView3
    {
        private readonly PartLibraryView3Presenter _presenter;

        public event EventHandler<PartEventArgs> PartSelected;

        protected virtual void OnPartSelected(PartEventArgs e)
        {
            EventHandler<PartEventArgs> handler = PartSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        public PartLibraryView3()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new PartLibraryView3Presenter(this);

                resultsObjectListView.SmallImageList = new ImageList {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };

                resultsObjectListView.SmallImageList.Images.Add("PartIcon", Resources.PartIcon_16x16);
            }
        }

        #region IPartLibraryView3 Members

        public event EventHandler<StringEventArgs> PerformSearch;

        public void DisplayResults(IEnumerable<PartLibraryView3Model> results)
        {
            searchButton.Enabled = true;

            searchButton.Text = "Go";

            searchingBarPictureBox.Visible = false;

            drawingNumberOlvColumn.ImageKey = "PartIcon";

            resultsObjectListView.SetObjects(results);
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
                pdfViewer.LoadFile(null);
                pdfViewer.Enabled = false;
            }
            else {
                var item = resultsObjectListView.SelectedObject as PartLibraryView3Model;
                pdfViewer.LoadFile(item.PathToDrawingFile);
                pdfViewer.Enabled = true;
            }
        }

        private void resultsObjectListView_ItemActivate(object sender, EventArgs e)
        {
            var part = (resultsObjectListView.SelectedObject as PartLibraryView3Model).Part;

            OnPartSelected(new PartEventArgs(part));
        }
    }
}