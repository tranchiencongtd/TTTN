using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    class Employee
    {   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public decimal Salary { get; set; }
        public string Level { get; set; }
        public string DepartmentName { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string firstName, string lastName, string email, DateTime dateOfBirth, bool status, decimal salary, string level, string departmentName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Status = status;
            Salary = salary;
            Level = level;
            DepartmentName = departmentName;
        }

        public override string ToString()
        {

            return String.Format("{0,-15}{1,-15}{2,-15}{3,-25}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}", Id, FirstName, LastName, Email, DateOfBirth.ToString("dd/MM/yyyy"), Status, Salary, Level, DepartmentName);
        }
    }
}
