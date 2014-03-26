#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using nGenLibrary;

#endregion

namespace CPECentral.Dialogs
{
    public partial class ToolManagementDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private Tool _toolToSelect;

        public ToolManagementDialog()
        {
            InitializeComponent();

            toolLibraryView.LibraryRefreshStarted += toolLibraryView_LibraryRefreshStarted;
            toolLibraryView.LibraryRefreshFinished += toolLibraryView_LibraryRefreshFinished;
        }

        private void toolLibraryView_LibraryRefreshStarted(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "reloading library...";
            toolStripProgressBar.Visible = true;
        }

        private void toolLibraryView_LibraryRefreshFinished(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "library loaded ok!";
            toolStripProgressBar.Visible = false;

            if (_toolToSelect != null) {
                toolLibraryView.SelectTool(_toolToSelect);
            }
        }

        private void ToolManagementDialog_Load(object sender, EventArgs e)
        {
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addRootGroupToolStripMenuItem":
                    AddRootGroup();
                    break;
                case "addChildGroupToolStripMenuItem":
                    AddChildGroup();
                    break;
                case "refreshLibraryToolStripButton":
                    toolLibraryView.RefreshLibrary();
                    break;
            }
        }

        private void toolLibraryView_ToolActivated(object sender, ToolEventArgs e)
        {
            EditTool(e.Tool);

        }

        private void selectedGroupContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addToolToolStripMenuItem":
                    AddNewTool();
                    break;
            }
        }

        private void AddNewTool()
        {
            using (var editToolDialog = new EditToolDialog()) {
                if (editToolDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                try {
                    using (var uow = new UnitOfWork()) {
                        using (BusyCursor.Show()) {
                            var newTool = editToolDialog.Tool;
                            newTool.ToolGroupId = toolLibraryView.SelectedToolGroup.Id;
                            uow.Tools.Add(newTool);

                            foreach (var material in editToolDialog.TricornLinks) {
                                var tricornTool = new TricornTool();
                                tricornTool.Tool = editToolDialog.Tool;
                                tricornTool.TricornReference = material.Material_Reference;
                                uow.TricornTools.Add(tricornTool);
                            }

                            uow.Commit();

                            toolLibraryView.RefreshLibrary(newTool);
                        }
                    }
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
        }

        private void EditTool(Tool tool)
        {
            using (var editToolDialog = new EditToolDialog(tool)) {
                if (editToolDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                try {
                    using (var uow = new UnitOfWork()) {
                        using (BusyCursor.Show()) {
                            uow.Tools.Update(tool);
                            var existingTricornTools = uow.TricornTools.GetByTool(tool);
                            foreach (var material in editToolDialog.TricornLinks) {
                                if (existingTricornTools.Any(t => t.TricornReference == material.Material_Reference)) {
                                    continue;
                                }
                                var tricornTool = new TricornTool();
                                tricornTool.Tool = tool;
                                tricornTool.TricornReference = material.Material_Reference;
                                uow.TricornTools.Add(tricornTool);
                            }


                            uow.Commit();
                        }

                        toolLibraryView.RefreshLibrary(tool);
                    }
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
        }

        private void AddRootGroup()
        {
            var newGroupName = "NEW GROUP 01";

            using (var uow = new UnitOfWork()) {
                try {

                    using (BusyCursor.Show()) {
                        var rootGroups = uow.ToolGroups.GetRootGroups();

                        int currentNumber = 1;
                        while (rootGroups.Any(g => g.Name.Equals(newGroupName, StringComparison.OrdinalIgnoreCase))) {
                            currentNumber++;
                            newGroupName = "NEW GROUP " + currentNumber.ToString("00");
                        }
                        var newGroup = new ToolGroup {Name = newGroupName};
                        uow.ToolGroups.Add(newGroup);
                        uow.Commit();
                        toolLibraryView.RefreshLibrary();
                        toolLibraryView.SelectToolGroup(newGroup);
                    }
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
        }

        private void AddChildGroup()
        {
            var newGroupName = "NEW GROUP 01";

                using (var uow = new UnitOfWork()) {
                    var parentGroup = toolLibraryView.SelectedToolGroup;

                    try {
                        using (BusyCursor.Show()) {
                            IEnumerable<ToolGroup> childGroups = uow.ToolGroups.GetChildGroups(parentGroup);

                            int currentNumber = 1;
                            while (childGroups.Any(g => g.Name.Equals(newGroupName, StringComparison.OrdinalIgnoreCase))) {
                                currentNumber++;
                                newGroupName = "NEW GROUP " + currentNumber.ToString("00");
                            }
                            var newGroup = new ToolGroup {Name = newGroupName};
                            newGroup.ParentGroupId = parentGroup.Id;

                            uow.ToolGroups.Add(newGroup);
                            uow.Commit();

                            toolLibraryView.RefreshLibrary();
                            toolLibraryView.SelectToolGroup(newGroup);
                        }
                    }
                    catch (Exception ex) {
                        HandleException(ex);
                    }
                }
            }

        private void HandleException(Exception ex)
        {
            string message = null;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                if (dataEx.Error == DataProviderError.UniqueConstraintViolation) {
                    message = "A tool with this name already exists!";
                }
                else {
                    message = ex.Message;
                }
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _dialogService.ShowError(message);
        }
    }
}