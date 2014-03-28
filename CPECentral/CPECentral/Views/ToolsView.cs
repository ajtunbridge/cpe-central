#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
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

        event EventHandler<ToolGroupEventArgs> AddTool;
        event EventHandler<ToolGroupEventArgs> LoadGroupTools;
        event EventHandler<HolderEventArgs> LoadHolderTools;
        event EventHandler<ToolEventArgs> ToolSelectionChanged;
        event EventHandler<ToolEventArgs> ToolPicked;
        event EventHandler<ToolEventArgs> ToolRenamed;
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
        private readonly ToolsViewPresenter _presenter;
        private ToolGroup _currentToolGroup;
        private Holder _currentHolder;
        private bool _editMode;

        public ToolsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new ToolsViewPresenter(this);
            }
        }

        #region IToolsView Members

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
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

        public event EventHandler<ToolGroupEventArgs> AddTool;
        public event EventHandler<ToolGroupEventArgs> LoadGroupTools;
        public event EventHandler<HolderEventArgs> LoadHolderTools;

        public event EventHandler<ToolEventArgs> ToolSelectionChanged;
        public event EventHandler<ToolEventArgs> ToolPicked;
        public event EventHandler<ToolEventArgs> ToolRenamed;
        public event EventHandler<ToolEventArgs> EditTool;
        public event EventHandler<ToolEventArgs> DeleteTool;

        public void ClearTools()
        {
            toolsEnhancedListView.Items.Clear();
            OnToolSelected(new ToolEventArgs(null));
        }

        public void LoadTools(ToolGroup toolGroup)
        {
            _currentToolGroup = toolGroup;
            _currentHolder = null;

            toolsEnhancedListView.Items.Clear();

            toolsEnhancedListView.Items.Add("retrieving...");

            OnLoadGroupTools(new ToolGroupEventArgs(toolGroup));

            OnToolSelected(new ToolEventArgs(null));
        }

        public void LoadTools(Holder holder)
        {
            _currentToolGroup = null;
            _currentHolder = holder;

            toolsEnhancedListView.Items.Clear();

            toolsEnhancedListView.Items.Add("retrieving...");

            OnLoadHolderTools(new HolderEventArgs(holder));

            OnToolSelected(new ToolEventArgs(null));
            
        }
        public void DisplayTools(IEnumerable<Tool> tools)
        {
            toolsEnhancedListView.Items.Clear();

            if (tools == null || !tools.Any()) {
                toolsEnhancedListView.Items.Add("No tools found!");
                return;
            }

            foreach (var tool in tools) {
                var item = toolsEnhancedListView.Items.Add(tool.Description);
                item.Tag = tool;
            }
        }
        public void RefreshTools()
        {
            if (CurrentToolGroup == null) {
                Debug.Write("ToolsView.RefreshTools(): CurrentToolGroup is null!");
                return;
            }

            if (CurrentHolder == null)
            {
                Debug.Write("ToolsView.RefreshTools(): CurrentHolder is null!");
                return;
            }

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
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnToolSelected(ToolEventArgs e)
        {
            var handler = ToolSelectionChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadGroupTools(ToolGroupEventArgs e)
        {
            var handler = LoadGroupTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadHolderTools(HolderEventArgs e)
        {
            EventHandler<HolderEventArgs> handler = LoadHolderTools;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEditTool(ToolEventArgs e)
        {
            var handler = EditTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnDeleteTool(ToolEventArgs e)
        {
            var handler = DeleteTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnToolPicked(ToolEventArgs e)
        {
            var handler = ToolPicked;
            if (handler != null) {
                handler(this, e);
            }
        }

        #endregion

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolsEnhancedListView.SelectionCount == 1) {
                var tag = toolsEnhancedListView.SelectedItems[0].Tag;

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

            var clickedItem = toolsEnhancedListView.SelectedItems[0];

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
    }
}