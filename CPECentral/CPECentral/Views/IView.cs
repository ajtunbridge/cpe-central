#region Using directives

using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public interface IView
    {
        Form ParentForm { get; }
        IDialogService DialogService { get; }
    }
}