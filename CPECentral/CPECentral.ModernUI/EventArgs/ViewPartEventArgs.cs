using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPECentral.ModernUI.ViewModels;

namespace CPECentral.ModernUI.EventArgs
{
    public class ViewPartEventArgs : System.EventArgs
    {
        public PartViewModel ViewModel { get; private set; }

        public ViewPartEventArgs(PartViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
