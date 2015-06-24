#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public class OperationToolListChangedMessage
    {
        public OperationToolListChangedMessage(Operation operation)
        {
            Operation = operation;
        }

        public Operation Operation { get; private set; }
    }
}