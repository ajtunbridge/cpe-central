#region Using directives

using System.Windows.Forms;

#endregion

namespace CPECentral
{
    public sealed class StandardDialogService : IDialogService
    {
        #region IDialogService Members

        public bool AskQuestion(string question)
        {
            return MessageBox.Show(question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                   DialogResult.Yes;
        }

        public void Notify(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}