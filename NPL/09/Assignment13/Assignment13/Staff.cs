using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{
    abstract class Staff
    {
        public string FullName { set; get; }
        public string Department { set; get; }
        public double SalaryRate { set; get; }
        public abstract double GetAllowance();
        public abstract double GetSalary();

        public Staff()
        {

        }

        public virtual void AddStaff()
        {
            Console.Write("Name: ");
            FullName = Console.ReadLine().Trim();
            Console.Write("Salary ratio: ");
            SalaryRate = Double.Parse(Console.ReadLine());
        }
    }
}
