#region Using directives

using System;

#endregion

namespace CPECentral.CustomEventArgs
{
    public class ExceptionEventArgs : EventArgs
    {
        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }
    }
}