#region Using directives

using System;
using System.Windows.Forms;
using nGenLibrary;

#endregion

namespace CPECentral
{
    public class NoFlicker : IDisposable
    {
        private readonly Control _control;

        private NoFlicker(Control control)
        {
            _control = control;

            Win32.SuspendDrawing(control);
        }

        #region IDisposable Members

        public void Dispose()
        {
            Win32.ResumeDrawing(_control);
        }

        #endregion

        public static NoFlicker On(Control control)
        {
            return new NoFlicker(control);
        }
    }
}