using System.Windows.Forms;

namespace CPECentral.Views
{
    public interface IView
    {
        Form ParentForm { get;  }
        IDialogService DialogService { get; }
    }
}