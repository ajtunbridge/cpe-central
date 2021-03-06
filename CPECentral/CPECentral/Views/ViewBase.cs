﻿#region Using directives

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public class ViewBase : UserControl, IView
    {
        private readonly IDialogService _dialogService;

        public ViewBase()
        {
            if (!IsInDesignMode) {
                _dialogService = Session.GetInstanceOf<IDialogService>();
            }
        }

        protected bool IsInDesignMode
        {
            get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        #region IView Members

        public IDialogService DialogService
        {
            get { return _dialogService; }
        }

        #endregion
    }
}