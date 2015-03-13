#region Using directives

using System.Windows.Forms;
using CPECentral.QMS.Model;

#endregion

namespace CPECentral.Views
{
    public partial class NonConformanceView : UserControl
    {
        public NonConformanceView()
        {
            InitializeComponent();
        }

        public void ShowNonConformance(NonConformance nonConformance)
        {
            if (nonConformance == null) {
                Visible = false;
                return;
            }

            Visible = true;

            headerLabel.Text = "Non-conformance report: #" + nonConformance.ReportNumber.ToString("D4");
            reportNumberTextBox.Text = nonConformance.ReportNumber.ToString("D4");
            customerSupplierTextBox.Text = nonConformance.RaisedBy;
            reasonTextBox.Text = nonConformance.Reason;
            categoryTextBox.Text = nonConformance.Category;
            contactTextBox.Text = nonConformance.Contact;
            raisedAgainstTextBox.Text = nonConformance.Employee;
            descriptionTextBox.Text = nonConformance.Description;
            correctiveActionTextBox.Text = nonConformance.CorrectiveAction;
            preventativeActionTextBox.Text = nonConformance.PreventativeAction;
            conclusionTextBox.Text = nonConformance.Conclusion;
            raisedOnTextBox.Text = nonConformance.RaisedOn == null
                ? "N/A"
                : nonConformance.RaisedOn.Value.ToShortDateString();
            authorizedByTextBox.Text = nonConformance.AuthorizedBy;
            resultsOfInspectionTextBox.Text = nonConformance.ResultsOfInspection;
        }
    }
}