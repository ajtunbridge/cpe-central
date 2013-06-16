using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Views
{
    public interface IView
    {
        IDialogService DialogService { get; }
    }
}
