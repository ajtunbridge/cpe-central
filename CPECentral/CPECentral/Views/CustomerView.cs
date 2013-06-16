#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Views
{
    public partial class CustomerView : ViewBase
    {
        private readonly Customer _customer;

        public CustomerView(Customer customer)
        {
            InitializeComponent();
            base.Dock = DockStyle.Fill;

            _customer = customer;
        }

        public Customer Customer
        {
            get { return _customer; }
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            label1.Text = _customer.Name;
        }
    }
}