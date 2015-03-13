#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.QMS.Model;

#endregion

namespace CPECentral.Views
{
    public interface INonConformanceSelectorView : IView
    {
        event EventHandler<StringEventArgs> RetrieveNonConformances;
        void DisplayNonConformances(IEnumerable<NonConformance> nonConformances);
    }

    public partial class NonConformanceSelectorView : ViewBase, INonConformanceSelectorView
    {
        private readonly NonConformanceSelectorViewPresenter _presenter;
        private string _drawingNumber;

        public NonConformanceSelectorView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new NonConformanceSelectorViewPresenter(this);
            }
        }

        public string DrawingNumber
        {
            get { return _drawingNumber; }
            set
            {
                _drawingNumber = value;
                if (value != null) {
                    objectListView.SetObjects(null);
                    pictureBox1.BringToFront();
                    OnRetrieveNonConformances(new StringEventArgs(value));
                }
            }
        }

        #region INonConformanceSelectorView Members

        public event EventHandler<StringEventArgs> RetrieveNonConformances;

        public void DisplayNonConformances(IEnumerable<NonConformance> nonConformances)
        {
            pictureBox1.SendToBack();

            objectListView.SetObjects(nonConformances);

            if (objectListView.Items.Count > 0) {
                objectListView.Items[0].Selected = true;
            }
        }

        #endregion

        public event EventHandler<NonConformanceEventArgs> NonConformanceSelected;

        protected virtual void OnNonConformanceSelected(NonConformanceEventArgs e)
        {
            EventHandler<NonConformanceEventArgs> handler = NonConformanceSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnRetrieveNonConformances(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = RetrieveNonConformances;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void NonConformanceSelectorView_SizeChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void objectListView_SelectionChanged(object sender, EventArgs e)
        {
            var nc = (objectListView.SelectedObject == null) ? null : objectListView.SelectedObject as NonConformance;

            OnNonConformanceSelected(new NonConformanceEventArgs(nc));
        }
    }
}