#region Using directives

using System;
using System.Drawing;
using System.IO;
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

            base.Font = Session.AppFont;

            base.Dock = DockStyle.Fill;

            _customer = customer;
        }

        public Customer Customer
        {
            get { return _customer; }
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            customerNameLabel.Text = _customer.Name;

            if (_customer.LogoBlob != null) {
                using (var ms = new MemoryStream(_customer.LogoBlob)) {
                    logoPictureBox.Image = Image.FromStream(ms);
                }
            }
        }
    }
}