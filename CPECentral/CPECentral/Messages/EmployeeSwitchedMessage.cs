using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Messages
{
    public class EmployeeSwitchedMessage
    {
        public Employee Employee { get; private set; }

        public EmployeeSwitchedMessage(Employee employee)
        {
            Employee = employee;
        }
    }
}
