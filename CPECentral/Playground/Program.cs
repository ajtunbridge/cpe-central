using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CPE Central Playground");
            Console.WriteLine("-----------------------------------------------------");

            CreateNewUser();

            Console.WriteLine();
            Console.WriteLine("All done. Have a nice day :)");
            Console.ReadLine();
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

            Console.Write("Enter the first and last names of this employee: ");
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
