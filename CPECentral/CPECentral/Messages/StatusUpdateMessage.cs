namespace CPECentral.Messages
{
    public class StatusUpdateMessage
    {
        public StatusUpdateMessage(string status)
        {
            Status = status;
        }

        public string Status { get; private set; }
    }
}