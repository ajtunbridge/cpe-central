using NcCommunicator.Data.Model;

namespace CPECentral.Messages
{
    public class SerialMachineLogUpdatedMessage
    {
        public SerialMachine Machine { get; private set;}

        public SerialMachineLogUpdatedMessage(SerialMachine machine)
        {
            Machine = machine;
        }
    }
}