#region Using directives

using System;

#endregion

namespace CPECentral.Data.EF5
{
    public class DataProviderException : Exception
    {
        private readonly DataProviderError _error;

        public DataProviderException(string message, DataProviderError error, Exception innerException)
            : base(message, innerException)
        {
            _error = error;
        }

        public DataProviderError Error
        {
            get { return _error; }
        }
    }
}