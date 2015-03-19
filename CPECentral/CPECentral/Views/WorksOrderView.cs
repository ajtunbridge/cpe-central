using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using Tricorn;

namespace CPECentral.Views
{
    public interface IWorksOrderView : IView
    {
        void InitializeView(string worksOrderNumber);
    }

    public sealed partial class WorksOrderView : ViewBase, IWorksOrderView
    {
        public event EventHandler<StringEventArgs> RetrieveWorksOrderData;

        private void OnRetrieveWorksOrderData(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = RetrieveWorksOrderData;
            if (handler != null) {
                handler(this, e);
            }
        }

        public WorksOrderView()
        {
            InitializeComponent();
        }

        public void InitializeView(string worksOrderNumber)
        {
            if (string.IsNullOrWhiteSpace(worksOrderNumber)) {
                throw new ArgumentException("Null or empty works order number supplied!", "worksOrderNumber");
            }

            OnRetrieveWorksOrderData(new StringEventArgs(worksOrderNumber));
        }
    }
}
