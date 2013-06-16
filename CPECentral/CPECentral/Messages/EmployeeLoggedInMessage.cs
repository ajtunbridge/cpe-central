#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public sealed class EmployeeLoggedInMessage
    {
        public EmployeeLoggedInMessage(Employee employee)
        {
            Employee = employee;
        }

        public Employee Employee { get; private set; }
    }
}