using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

namespace Playground
{
    class Program
    {
        static SerialPort _port;
        static StringBuilder _received = new StringBuilder();
        static string _textToSend;

        static void Main(string[] args)
        {
            // SendProgram(@"C:\Users\adam.tunbridge\Desktop\6215.txt");

            CreateNewUser();

            Console.ReadLine();
        }

        private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var received = _port.ReadExisting();

            _received.Append(received);
            
            foreach (var character in received)
            {
                Console.Write($"{ Convert.ToInt32(character)} ");
            }
        }

        private static void Port_DataReceived_Sending(object sender, SerialDataReceivedEventArgs e)
        {
            var received = _port.ReadExisting();

            if (received[0] == 17) {
                _port.Write(_textToSend);
            }
            else if (received.IndexOfAny(new[] { Convert.ToChar(4) }) >= 0)
            {
                _port.Close();

                Console.WriteLine("Program sent ok");
            }
        }

        static void SendProgram(string fileName)
        {
            _textToSend = System.IO.File.ReadAllText(fileName);
            _textToSend += Convert.ToChar(3);

            _port = new SerialPort();
            _port.PortName = "COM2";
            _port.DataBits = 7;
            _port.Parity = Parity.Even;
            _port.StopBits = StopBits.Two;
            _port.DtrEnable = true;
            _port.RtsEnable = true;
            _port.Handshake = Handshake.RequestToSend;
            _port.BaudRate = 9600;
            _port.WriteTimeout = 2000;
            _port.DataReceived += Port_DataReceived_Sending;
            _port.ErrorReceived += _port_ErrorReceived;
            _port.Open();
        }

        private static void _port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            _port.Write(new[] { Convert.ToChar(19) }, 0, 1);
        }

        static void ReceiveProgram()
        {
            _port = new SerialPort();
            _port.PortName = "COM2";
            _port.DataBits = 7;
            _port.Parity = Parity.Even;
            _port.StopBits = StopBits.Two;
            _port.DtrEnable = true;
            _port.RtsEnable = true;
            _port.BaudRate = 9600;

            _port.DataReceived += Port_DataReceived;

            _port.Open();
        }

        static void CreateNewUser()
        {
            var entities = new CPECentralEntities();

            int index = 0;
            var groups = entities.EmployeeGroups.ToList();

            foreach (var group in groups)
            {
                Console.WriteLine("{0}: {1}", index, group.Name);
                index++;
            }

            Console.WriteLine();

            Console.Write("Enter the number of the group this employee belongs to: ");
            var retval = Console.ReadLine();
            index = Convert.ToInt32(retval);

            Console.Write("Enter the first and last name of this employee: ");
            retval = Console.ReadLine();

            var firstName = retval.Substring(0, retval.IndexOf(" ")).Trim();
            var lastName = retval.Substring(retval.IndexOf(" ")).Trim();

            Console.Write("Enter the user name: ");
            retval = Console.ReadLine();

            var userName = retval;

            Console.Write("Enter the password for this user: ");
            retval = Console.ReadLine();

            var password = new PBKDF2PasswordService().SecurePassword(retval);

            var employee = new Employee
            {
                EmployeeGroupId = groups[index].Id,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password.Hash,
                Salt = password.Salt
            };

            entities.Employees.Add(employee);

            entities.SaveChanges();
        }
    }
}
