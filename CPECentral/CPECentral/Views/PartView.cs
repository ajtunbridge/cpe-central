#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPECentral.Controls;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace CPECentral.Views
{
    public interface IPartView : IView
    {
        Part Part { get; }
        PartVersion SelectedPartVersion { get; }
        event EventHandler ReloadData;
        event EventHandler<PartVersionEventArgs> SelectedVersionChanged;
        event EventHandler SetPartVersionPhoto;
        event EventHandler RemovePartVersionPhoto;
        event EventHandler CheckForNonConformances;

        void LoadPart(Part part);

        void DisplayModel(PartViewModel model);

        void FinishedNonConformanceCheck(bool hasNonConformances);

        void ShowVersionWarning();
    }

    public partial class PartView : ViewBase, IPartView
    {
        private const int NonConformanceWarningBlinkCount = 3;
        private readonly PartViewPresenter _presenter;

        private int _currentBlinkCount = 0;
        private Timer _nonConformanceWarningBlinkTimer;

        public PartView()
        {
            InitializeComponent();

            //Font = Session.AppFont;

            base.Dock = DockStyle.Fill;

            if (!IsInDesignMode) {
                _presenter = new PartViewPresenter(this);
                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);

                Session.MessageBus.Subscribe<PartVersionPhotoChangedMessage>(msg => {
                    if (partInformationView.SelectedVersion == msg.PartVersion) {
                        var image = Session.PartPartPhotoCache[msg.PartVersion.PartId];
                        if (image == null) {
                            partPhotoPictureBox.Image = Resources.NoImageAvailableImage;
                            partPhotoPictureBox.BackgroundImage = null;
                            removeImageButton.Enabled = false;
                        }
                        else {
                            partPhotoPictureBox.Image = image;
                            partPhotoPictureBox.BackgroundImage = Resources.DocumentPreviewBgTile;
                            removeImageButton.Enabled = true;
                        }
                    }
                });
            }
        }

        #region IPartView Members

        public PartVersion SelectedPartVersion
        {
            get { return partInformationView.SelectedVersion; }
        }

        public event EventHandler ReloadData;
        public event EventHandler<PartVersionEventArgs> SelectedVersionChanged;
        public event EventHandler SetPartVersionPhoto;
        public event EventHandler RemovePartVersionPhoto;
        public event EventHandler CheckForNonConformances;

        public Part Part { get; private set; }

        public void LoadPart(Part part)
        {
            using (NoFlicker.On(this)) {
                Part = part;
                partDescriptionLabel.Text = string.Format("{0} - {1}", part.DrawingNumber, part.Name);
                partInformationView.LoadPart(part);
                partDocumentsView.LoadDocuments(part);
                partWorksOrdersView.InitializeView(part);
                RefreshData();
            }
        }

        public void DisplayModel(PartViewModel model)
        {
            Session.MessageBus.Publish(new RecentPartsChangedMessage());
        }

        public void FinishedNonConformanceCheck(bool hasNonConformances)
        {
            checkingQMSLabel.Visible = false;
            checkingQMSPictureBox.Visible = false;

            if (!hasNonConformances) {
                return;
            }

            _nonConformanceWarningBlinkTimer = new Timer();
            _nonConformanceWarningBlinkTimer.Interval = 500;
            _nonConformanceWarningBlinkTimer.Tick += (o, e) => {
                if (nonConformanceWarningPictureBox.Visible && _currentBlinkCount <= NonConformanceWarningBlinkCount) {
                    nonConformanceWarningPictureBox.Visible = false;
                }
                else if (!nonConformanceWarningPictureBox.Visible) {
                    nonConformanceWarningPictureBox.Visible = true;
                    _currentBlinkCount += 1;
                    if (_currentBlinkCount == NonConformanceWarningBlinkCount) {
                        _nonConformanceWarningBlinkTimer.Dispose();
                    }
                }
            };

            _nonConformanceWarningBlinkTimer.Start();
        }

        public void ShowVersionWarning()
        {
            var versionWarningPanel = new VersionWarningPanel();
            Controls.Add(versionWarningPanel);
            versionWarningPanel.BringToFront();
            versionWarningPanel.Dock = DockStyle.Fill;
        }

        #endregion

        protected virtual void OnSelectedVersionChanged(PartVersionEventArgs e)
        {
            EventHandler<PartVersionEventArgs> handler = SelectedVersionChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnSetPartVersionPhoto()
        {
            EventHandler handler = SetPartVersionPhoto;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCheckForNonConformances()
        {
            EventHandler handler = CheckForNonConformances;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnRemovePartVersionPhoto()
        {
            EventHandler handler = RemovePartVersionPhoto;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnReloadData()
        {
            EventHandler handler = ReloadData;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (!Equals(Part, message.EditedPart)) {
                return;
            }

            partDescriptionLabel.Text = string.Format("{0} - {1}", message.EditedPart.DrawingNumber,
                message.EditedPart.Name);
        }

        private void RefreshData()
        {
            OnReloadData();
            OnCheckForNonConformances();
        }

        private void partInformationView_VersionSelected(object sender, PartVersionEventArgs e)
        {
            OnSelectedVersionChanged(new PartVersionEventArgs(e.PartVersion));

            operationsView.LoadMethods(e.PartVersion);

            versionDocumentsView.LoadDocuments(e.PartVersion);

            var photo = Session.PartPartPhotoCache[e.PartVersion.PartId];

            if (photo == null) {
                partPhotoPictureBox.Image = Resources.NoImageAvailableImage;
                partPhotoPictureBox.BackgroundImage = null;
                removeImageButton.Enabled = false;
            }
            else {
                partPhotoPictureBox.Image = photo;
                partPhotoPictureBox.BackgroundImage = Resources.DocumentPreviewBgTile;
                removeImageButton.Enabled = true;
            }
        }

        private void documentsView_OpenDocument(object sender, EventArgs e)
        {
            var view = (DocumentsView) sender;

            Document doc = view.SelectedDocuments.First();

            string[] viewInternallyFileExtensions = Settings.Default.ViewInternallyFileExtensions.Split(new[] {"|"},
                StringSplitOptions.None);

            string docExt = doc.FileName.Substring(doc.FileName.LastIndexOf("."));

            if (!viewInternallyFileExtensions.Any(ext => ext.Equals(docExt, StringComparison.OrdinalIgnoreCase))) {
                documentsView_OpenDocumentExternally(sender, e);
                return;
            }

            ThreadPool.QueueUserWorkItem(delegate {
                string pathToDocument = Session.DocumentService.GetPathToDocument(doc);

                operationDocumentsTabControl.InvokeEx(() => {
                    var tabPage = new TabPage(doc.FileName);
                    var editorPanel = new NcProgrammingView();
                    tabPage.Controls.Add(editorPanel);
                    editorPanel.Dock = DockStyle.Fill;
                    operationDocumentsTabControl.TabPages.Add(tabPage);
                    operationDocumentsTabControl.SelectedTab = tabPage;
                });
            });
        }

        private void documentsView_OpenDocumentExternally(object sender, EventArgs e)
        {
            try {
                var view = (DocumentsView) sender;

                Document doc = view.SelectedDocuments.First();

                Task.Factory.StartNew(() => Session.DocumentService.OpenDocument(doc));
            }
            catch (Exception ex) {
                DialogService.ShowError(ex.Message);
            }
        }

        private void operationsView1_OperationSelected(object sender, OperationEventArgs e)
        {
            if (e.Operation == null) {
                selectedOperationTabControl.Enabled = false;
                operationDocumentsView.ClearDocuments();
                operationToolsView.RetrieveOperationTools(null);
                return;
            }

            selectedOperationTabControl.Enabled = true;
            operationDocumentsView.LoadDocuments(e.Operation);
            operationToolsView.RetrieveOperationTools(e.Operation);
        }

        private void setImageButton_Click(object sender, EventArgs e)
        {
            OnSetPartVersionPhoto();
        }

        private void removeImageButton_Click(object sender, EventArgs e)
        {
            OnRemovePartVersionPhoto();
        }

        private void operationDocumentsView_TextFileSelected(object sender, DocumentEventArgs e)
        {
            //machineTransferView.RefreshMachineList();
            
            //if (machineTransferView.MachineCount > 0) {
            //    machineTransferView.Visible = true;
            //}
        }

        private void operationDocumentsView_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void nonConformanceWarningPictureBox_Click(object sender, EventArgs e)
        {
            new NonConformanceViewerDialog(Part.DrawingNumber).ShowDialog(ParentForm);
        }
    }
}