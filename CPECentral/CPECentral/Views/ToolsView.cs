#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Delegates;
using CPECentral.Messages;
using CPECentral.Presenters;

#endregion

namespace CPECentral.Views
{
    public interface IToolsView : IView
    {
        bool EditMode { get; set; }
        ToolGroup CurrentToolGroup { get; }

        Holder CurrentHolder { get; }

        Tool SelectedTool { get; }

        IEnumerable<Tool> SelectedTools { get; }

        event EventHandler<ToolGroupEventArgs> AddTool;
        event EventHandler<ToolGroupEventArgs> LoadGroupTools;
        event EventHandler<HolderEventArgs> LoadHolderTools;
        event EventHandler<ToolEventArgs> ToolSelectionChanged;
        event EventHandler<ToolEventArgs> ToolPicked;
        event UpdateResultCallbackDelegate<Tool> ToolRenamed;
        event EventHandler<ToolEventArgs> EditTool;
        event EventHandler<ToolEventArgs> DeleteTool;

        void ClearTools();
        void LoadTools(ToolGroup toolGroup);
        void LoadTools(Holder holder);
        void DisplayTools(IEnumerable<Tool> tools);
        void RefreshTools();
    }

    public partial class ToolsView : ViewBase, IToolsView
    {
        private readonly ToolsPresenter _presenter;
        private Holder _currentHolder;
        private ToolGroup _currentToolGroup;
        private bool _editMode;
        private List<Tool> _tools;

        public ToolsView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new ToolsPresenter(this);
            }
        }

        public bool MultiSelect
        {
            get { return toolsEnhancedListView.MultiSelect; }
            set
            {
                toolsEnhancedListView.MultiSelect = value;
                toolsEnhancedListView.CheckBoxes = value;
            }
        }

        #region IToolsView Members

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                toolStrip.Visible = value;
                toolsEnhancedListView.ContextMenuStrip = value ? listViewContextMenuStrip : null;
                toolsEnhancedListView.ItemContextMenuStrip = value ? listViewItemContextMenuStrip : null;
                toolsEnhancedListView.LabelEdit = value;
            }
        }

        public ToolGroup CurrentToolGroup
        {
            get { return _currentToolGroup; }
        }

        public Holder CurrentHolder { get; private set; }

        public Tool SelectedTool
        {
            get
            {
                if (toolsEnhancedListView.SelectionCount == 0) {
                    return null;
                }

                return toolsEnhancedListView.SelectedItems[0].Tag as Tool;
            }
        }

        public IEnumerable<Tool> SelectedTools
        {
            get
            {
                IEnumerable<Tool> checkedTools =
                    (from ListViewItem item in toolsEnhancedListView.CheckedItems select item.Tag as Tool);
                return checkedTools;
            }
        }

        public event EventHandler<ToolGroupEventArgs> AddTool;
        public event EventHandler<ToolGroupEventArgs> LoadGroupTools;
        public event EventHandler<HolderEventArgs> LoadHolderTools;

        public event EventHandler<ToolEventArgs> ToolSelectionChanged;
        public event EventHandler<ToolEventArgs> ToolPicked;
        public event UpdateResultCallbackDelegate<Tool> ToolRenamed;
        public event EventHandler<ToolEventArgs> EditTool;
        public event EventHandler<ToolEventArgs> DeleteTool;

        public void ClearTools()
        {
            toolsEnhancedListView.Items.Clear();
            OnToolSelected(new ToolEventArgs(null));
        }

        public void LoadTools(ToolGroup toolGroup)
        {
            Enabled = false;

            _tools = new List<Tool>();

            toolsEnhancedListView.Items.Clear();

            filterTextBox.Text = string.Empty;

            _currentToolGroup = toolGroup;
            _currentHolder = null;

            if (toolGroup == null) {
                toolsEnhancedListView.Items.Add("Please select a holder or tool group!");
                return;
            }

            toolsEnhancedListView.Items.Add("retrieving...");

            OnLoadGroupTools(new ToolGroupEventArgs(toolGroup));

            OnToolSelected(new ToolEventArgs(null));
        }

        public void LoadTools(Holder holder)
        {
            Enabled = false;

            toolsEnhancedListView.Items.Clear();

            _currentToolGroup = null;
            _currentHolder = holder;

            if (holder == null) {
                toolsEnhancedListView.Items.Add("Please select a holder or tool group!");
                return;
            }
            toolsEnhancedListView.Items.Add("retrieving...");

            OnLoadHolderTools(new HolderEventArgs(holder));

            OnToolSelected(new ToolEventArgs(null));
        }

        public void DisplayTools(IEnumerable<Tool> tools)
        {
            Enabled = true;

            toolsEnhancedListView.Items.Clear();

            if (tools == null || !tools.Any()) {
                toolsEnhancedListView.Items.Add("No tools found!");
                return;
            }

            foreach (Tool tool in tools) {
                ListViewItem item = toolsEnhancedListView.Items.Add(tool.Description);
                item.Tag = tool;

                _tools.Add(tool);
            }

            Focus();
        }

        public void RefreshTools()
        {
            if (CurrentToolGroup != null) {
                OnLoadGroupTools(new ToolGroupEventArgs(CurrentToolGroup));
            }
            else if (CurrentHolder != null) {
                OnLoadHolderTools(new HolderEventArgs(CurrentHolder));
            }
        }

        #endregion

        #region Event Invocators

        protected virtual void OnAddTool(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = AddTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnToolSelected(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ToolSelectionChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadGroupTools(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = LoadGroupTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadHolderTools(HolderEventArgs e)
        {
            EventHandler<HolderEventArgs> handler = LoadHolderTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnEditTool(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = EditTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnDeleteTool(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = DeleteTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual bool OnToolRenamed(ToolEventArgs e)
        {
            bool updatedOk = false;

            UpdateResultCallbackDelegate<Tool> handler = ToolRenamed;
            if (handler != null) {
                updatedOk = handler(e.Tool);
            }

            return updatedOk;
        }

        protected virtual void OnToolPicked(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ToolPicked;
            if (handler != null) {
                handler(this, e);
            }
        }

        #endregion

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectionCount = toolsEnhancedListView.SelectionCount;

            editToolStripButton.Enabled = selectionCount == 1;
            deleteToolStripButton.Enabled = selectionCount == 1;
            renameToolStripButton.Enabled = selectionCount == 1;

            if (toolsEnhancedListView.SelectionCount == 1) {
                object tag = toolsEnhancedListView.SelectedItems[0].Tag;

                if (!(tag is Tool)) {
                    return;
                }

                var tool = tag as Tool;

                OnToolSelected(new ToolEventArgs(tool));
            }
            else {
                OnToolSelected(new ToolEventArgs(null));
            }
        }

        private void listViewItemContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            listViewItemContextMenuStrip.Hide();

            ListViewItem clickedItem = toolsEnhancedListView.SelectedItems[0];

            switch (e.ClickedItem.Name) {
                case "editToolStripMenuItem":
                    OnEditTool(new ToolEventArgs(SelectedTool));
                    break;
                case "renameToolStripMenuItem":
                    clickedItem.BeginEdit();
                    break;
                case "deleteToolStripMenuItem":
                    OnDeleteTool(new ToolEventArgs(SelectedTool));
                    break;
            }
        }

        private void listViewContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            listViewContextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "addToolToolStripMenuItem":
                    OnAddTool(new ToolGroupEventArgs(CurrentToolGroup));
                    break;
            }
        }

        private void toolsEnhancedListView_ItemActivate(object sender, EventArgs e)
        {
            if (EditMode) {
                OnEditTool(new ToolEventArgs(SelectedTool));
            }
            else {
                OnToolPicked(new ToolEventArgs(SelectedTool));
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addToolStripButton":
                    OnAddTool(new ToolGroupEventArgs(CurrentToolGroup));
                    break;
                case "editToolStripButton":
                    OnEditTool(new ToolEventArgs(SelectedTool));
                    break;
                case "renameToolStripButton":
                    toolsEnhancedListView.SelectedItems[0].BeginEdit();
                    break;
                case "deleteToolStripButton":
                    OnDeleteTool(new ToolEventArgs(SelectedTool));
                    break;
            }
        }

        private void toolsEnhancedListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label.IsNullOrWhitespace()) {
                e.CancelEdit = true;
                return;
            }

            string newDescription = e.Label.ToUpper().Trim();

            SelectedTool.Description = newDescription;

            bool updatedOk = OnToolRenamed(new ToolEventArgs(SelectedTool));

            if (updatedOk) {
                Session.MessageBus.Publish(new ToolRenamedMessage(SelectedTool));
            }

            e.CancelEdit = !updatedOk;
        }

        private void toolsEnhancedListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            toolsEnhancedListView.DoDragDrop(toolsEnhancedListView.SelectedItems, DragDropEffects.Move);
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            toolsEnhancedListView.Items.Clear();

            string searchValue = filterTextBox.Text.Trim();

            IEnumerable<Tool> filteredTools = searchValue.Length == 0
                ? _tools
                : _tools.Where(t => t.Description.Contains(searchValue));

            foreach (Tool tool in filteredTools) {
                ListViewItem item = toolsEnhancedListView.Items.Add(tool.Description);
                item.Tag = tool;
            }
        }

        private void ToolsView_Enter(object sender, EventArgs e)
        {
            filterTextBox.Select();
            filterTextBox.SelectAll();
        }
    }
}