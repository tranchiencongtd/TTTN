using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    class Employee
    {
        public Employee(int id, string firstName, string lastName, string email, DateTime dateOfBirth, bool status,decimal salary, string level, string departmentName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
            this.Status = status;
            this.Salary = salary;
            this.Level = level;
            this.DepartmentName = departmentName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public decimal Salary { get; set; }
        public string Level { get; set; }
        public string DepartmentName { get; set; }

        public override string ToString()
        {
            
            return String.Format("{0,-5}{1,-10}{2,-10}{3,-25}{4,-15}{5,-10}{6,-10}{7,-5}{8,-10}",Id,FirstName,LastName,Email,DateOfBirth.ToString("dd/MM/yyyy"),Status,Salary,Level,DepartmentName);
        }


    }
}
