#region Using directives

using System;
using System.Collections.Generic;
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
        bool ShowStockLevels { get; set; }

        event EventHandler<ToolGroupEventArgs> LoadTools;

        event EventHandler<ToolEventArgs> ToolSelected;

        void DisplayTools(IEnumerable<Tool> tools);
    }

    public partial class ToolsView : ViewBase, IToolsView
    {
        private readonly ToolsViewPresenter _presenter;

        private bool _showStockLevels = true;

        public ToolsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new ToolsViewPresenter(this);
            }
        }

        public event EventHandler<ToolGroupEventArgs> LoadTools;
        public event EventHandler<ToolEventArgs> ToolSelected;

        protected virtual void OnToolSelected(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ToolSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadTools(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = LoadTools;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DisplayTools(IEnumerable<Tool> tools)
        {
            toolsEnhancedListView.Items.Clear();

            if (!tools.Any()) {
                toolsEnhancedListView.Items.Add("No tools found!");
                return;
            }

            foreach (Tool tool in tools) {
                ListViewItem item = toolsEnhancedListView.Items.Add(tool.Description);
                item.Tag = tool;
            }
        }

        public bool ShowStockLevels
        {
            get { return _showStockLevels; }
            set
            {
                mainSplitContainer.Panel2Collapsed = !value;
                _showStockLevels = value;
            }
        }

        public void LoadGroupTools(ToolGroup toolGroup)
        {
            toolsEnhancedListView.Items.Clear();
            stockLevelsEnhancedListView.Items.Clear();

            toolsEnhancedListView.Items.Add("retrieving...");
            OnLoadTools(new ToolGroupEventArgs(toolGroup));
        }

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_showStockLevels) {
                stockLevelsEnhancedListView.Items.Clear();
            }

            if (toolsEnhancedListView.SelectionCount == 1) {
                var tag = toolsEnhancedListView.SelectedItems[0].Tag;

                if (!(tag is Tool)) {
                    return;
                }

                var tool = tag as Tool;

                OnToolSelected(new ToolEventArgs(tool));
            }
        }
    }
}