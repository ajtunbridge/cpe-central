#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Controls;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
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
        private readonly PartLibraryPresenter _presenter;
        private Employee _sessionEmployee;

        public PartLibraryView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new PartLibraryPresenter(this);

                resultsObjectListView.SmallImageList = new ImageList {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };

                resultsObjectListView.SmallImageList.Images.Add("PartIcon", Resources.PartIcon_16x16);

                _sessionEmployee = Session.CurrentEmployee;

                Session.MessageBus.Subscribe<LoadPartMessage>(HandleLoadPartMessage);
                Session.MessageBus.Subscribe<PartEditedMessage>(HandlePartEditedMessage);
            }
        }

        private void HandlePartEditedMessage(PartEditedMessage partEditedMessage)
        {
            foreach (TabPage tabPage in closableTabControl.TabPages)
            {
                if (tabPage.Tag is Part)
                {
                    var part = tabPage.Tag as Part;
                    if (part == partEditedMessage.EditedPart)
                    {
                        tabPage.Text = partEditedMessage.EditedPart.DrawingNumber;
                        break;
                    }
                }
            }
        }

        private void HandleLoadPartMessage(LoadPartMessage loadPartMessage)
        {
            // we don't want to load other employees parts
            if (_sessionEmployee != Session.CurrentEmployee)
            {
                return;
            }

            foreach (TabPage existingTab in closableTabControl.TabPages)
            {
                if (existingTab.Tag is Part)
                {
                    var part = existingTab.Tag as Part;
                    if (part != loadPartMessage.PartToLoad)
                    {
                        continue;
                    }
                    closableTabControl.SelectTab(existingTab);
                    Select();
                    return;
                }
            }

            var newTab = new ClosableTabPage(loadPartMessage.PartToLoad.DrawingNumber);
            newTab.Tag = loadPartMessage.PartToLoad;
            //newTab.ImageIndex = 2;

            var partView = new PartView();
            partView.Dock = DockStyle.Fill;

            newTab.Controls.Add(partView);

            partView.LoadPart(loadPartMessage.PartToLoad);

            closableTabControl.TabPages.Add(newTab);

            closableTabControl.SelectTab(newTab);
            Select();
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

            var isWorksOrder = searchValueTextBox.Text.All(char.IsNumber) &
                               searchValueTextBox.Text.Length == 4 || searchValueTextBox.Text.Length == 5;

            if (resultsObjectListView.Items.Count == 0 && isWorksOrder)
            {
                var dialog = new AddPartDialog(searchValueTextBox.Text);
                dialog.ShowDialog(ParentForm);
            }
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
    }
}