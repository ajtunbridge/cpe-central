#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BrightIdeasSoftware;
using CPECentral.Presenters;
using CPECentral.ViewModels;
using nGenLibrary;
using Tricorn;

#endregion

namespace CPECentral.Views
{
    public interface IWorkCentreScheduleView : IView
    {
        WCentre SelectedMachine { get; }
        WorkCentreScheduleViewModel.ScheduledJob SelectedJob { get; }
        IEnumerable<WCentre> AllMachines { get; }
        void DisplayModel(WorkCentreScheduleViewModel model);
        void DisplayMachines(IEnumerable<WCentre> machines);
        event EventHandler MachineSelected;
        event EventHandler RetrieveMachines;
        event EventHandler PartSelected;
    }

    public sealed partial class WorkCentreScheduleView : ViewBase, IWorkCentreScheduleView
    {
        private WorkCentreSchedulePresenter _presenter;

        public WorkCentreScheduleView()
        {
            InitializeComponent();

            if (DesignMode || IsInDesignMode)
            {
                return;
            }

            _presenter = new WorkCentreSchedulePresenter(this);
        }

        public event EventHandler MachineSelected;
        public event EventHandler RetrieveMachines;
        public event EventHandler PartSelected;
        public WCentre SelectedMachine => machinesComboBox.SelectedItem as WCentre;

        public WorkCentreScheduleViewModel.ScheduledJob SelectedJob
            => (jobsObjectListView.SelectedObject as WorkCentreScheduleViewModel.ScheduledJob);

        public IEnumerable<WCentre> AllMachines
            => (from object item in machinesComboBox.Items select item as WCentre).ToList();

        public void DisplayModel(WorkCentreScheduleViewModel model)
        {
            using (BusyCursor.Show())
            {
                jobsObjectListView.SetObjects(model.NextJobs);
            }
            
            progressBar.Visible = false;
        }

        public void DisplayMachines(IEnumerable<WCentre> machines)
        {
            machinesComboBox.Items.Clear();

            if (machines.Any())
            {
                machinesComboBox.Items.Add("All machines");
                machinesComboBox.Items.AddRange(machines.ToArray());

                machinesComboBox.Enabled = true;

                machinesComboBox.SelectedIndex = 0;
            }

            progressBar.Visible = false;
        }

        private void WorkCentreScheduleView_Load(object sender, EventArgs e)
        {
            if (IsInDesignMode || DesignMode)
            {
                return;
            }

            OnRetrieveMachines();
        }

        private void OnMachineSelected()
        {
            progressBar.Visible = true;
            jobsObjectListView.SetObjects(null);

            MachineSelected?.Invoke(this, EventArgs.Empty);
        }

        private void OnRetrieveMachines()
        {
            progressBar.Visible = true;

            RetrieveMachines?.Invoke(this, EventArgs.Empty);
        }

        private void machinesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnMachineSelected();
        }

        private void jobsObjectListView_ItemActivate(object sender, EventArgs e)
        {
            OnPartSelected();
        }

        private void OnPartSelected()
        {
            PartSelected?.Invoke(this, EventArgs.Empty);
        }

        private void jobsObjectListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void jobsObjectListView_FormatRow(object sender, FormatRowEventArgs e)
        {
            var job = e.Model as WorkCentreScheduleViewModel.ScheduledJob;

            if (job.ScheduledStart < DateTime.Today)
            {
                e.Item.ForeColor = Color.Red;
            }
            else if (job.ScheduledStart > DateTime.Today)
            {
                e.Item.ForeColor = Color.Green;
            }
        }
    }
}