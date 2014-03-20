namespace NcCommunicator.Data.Model
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ComPort { get; set; }
        public int MachineControlId { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, ComPort);
        }
    }
}