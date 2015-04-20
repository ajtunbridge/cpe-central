using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using NcCommunicator.Data.Model;

namespace NcCommunicator
{
    public class SerialMachineLink
    {
        private readonly SerialMachine _machine;
        private readonly SerialPort _port;
        private Queue<byte[]> _transmitQueue;

        private const byte DefaultBlockSize = 16;

        public SerialMachineLink(SerialMachine machine)
        {
            _machine = machine;
            _port = new SerialPort(_machine.ComPort);
        }

        public void Transmit(string text)
        {
            var bytes = Encoding.ASCII.GetBytes(text);
            _transmitQueue.Enqueue(bytes);
        }
    }
}