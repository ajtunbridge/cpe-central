#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;

#endregion

namespace CPECentral.Views
{
    public interface IToolSelectorView : IView
    {
        event EventHandler<StringEventArgs> FilterTools;
        event EventHandler<ToolEventArgs> ToolSelectionChanged;
        event EventHandler<ToolEventArgs> ToolSelected;
 
        void DisplayFilterResults(IEnumerable<Tool> filterResults);
    }

    public partial class ToolSelectorView : ViewBase, IToolSelectorView
    {
        private readonly ToolSelectorPresenter _presenter;

        public Tool SelectedTool { get; private set; }

        public ToolSelectorView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new ToolSelectorPresenter(this);
                Disposed += ToolSelectorView_Disposed;
            }
        }

        void ToolSelectorView_Disposed(object sender, EventArgs e)
        {
            _presenter.Dispose();
        }

        #region IToolSelectorView Members

        public event EventHandler<StringEventArgs> FilterTools;
        public event EventHandler<ToolEventArgs> ToolSelectionChanged;
        public event EventHandler<ToolEventArgs> ToolSelected;

        public void DisplayFilterResults(IEnumerable<Tool> filterResults)
        {
            asyncIndicatorPictureBox.Visible = false;
            filterButton.Enabled = true;

            resultsObjectListView.EmptyListMsg = "No matches found!";

            resultsObjectListView.SetObjects(filterResults);

            resultsObjectListView.Select();

            if (resultsObjectListView.GetItemCount() > 0) {
                resultsObjectListView.Items[0].Selected = true;
            }
        }

        #endregion

        protected virtual void OnFilterTools(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = FilterTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnToolSelectionChanged(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ToolSelectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnToolSelected(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ToolSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            asyncIndicatorPictureBox.Visible = true;
            filterButton.Enabled = false;

            resultsObjectListView.SetObjects(null);
            
            resultsObjectListView.EmptyListMsg = "searching for " + filterTextBox.Text;

            OnFilterTools(new StringEventArgs(filterTextBox.Text));
        }

        private void filterTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            filterButton.PerformClick();
        }

        private void resultsObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            SelectedTool = resultsObjectListView.SelectedObject as Tool;

            OnToolSelectionChanged(new ToolEventArgs(SelectedTool));
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            filterButton.Enabled = filterTextBox.Text.Trim().Length > 0;
        }

        private void resultsObjectListView_ItemActivate(object sender, EventArgs e)
        {
            OnToolSelected(new ToolEventArgs(SelectedTool));
        }
    }
}