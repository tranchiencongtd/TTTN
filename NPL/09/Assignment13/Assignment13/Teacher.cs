using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{
    class Teacher : Staff
    {
        public string Degree { set; get; }
        public double TeachingHour { set; get; }

        public override double GetAllowance()
        {
            double allowance = 0;
            if (Degree == "Bachelor")
                allowance = 300;
            if (Degree == "Master")
                allowance = 500;
            if (Degree == "Doctor")
                allowance = 1000;
            return allowance;
        }

        public override double GetSalary()
        {
            return SalaryRate * 730 + this.GetAllowance() + TeachingHour * 45;
        }

        public override void AddStaff()
        {
            base.AddStaff();
            Console.Write("Faculty: ");
            Department = Console.ReadLine().Trim();
            Console.Write("Degree (1=BACHELOR; 2=MASTER; 3=DOCTOR): ");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Degree = "Bachelor";
                        break;
                    }
                case 2:
                    {
                        Degree = "Master";
                        break;
                    }
                case 3:
                    {
                        Degree = "Doctor";
                        break;
                    }
            }
            Console.Write("Number of teaching hours: ");
            TeachingHour = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", FullName, Department, Degree, SalaryRate, GetAllowance(), TeachingHour, GetSalary());
        }
    }
}
