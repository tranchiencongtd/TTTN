using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{
    class Officer : Staff
    {
        public int WorkingDay { set; get; }

        public string Position { set; get; }

        public override double GetAllowance()
        {
            double allowance = 0;
            if (Position == "Head officer")
                allowance = 2000;
            if (Position == "Deputy officer")
                allowance = 1000;
            if (Position == "Officer")
                allowance = 500;
            return allowance;
        }

        public override double GetSalary()
        {
            return SalaryRate * 730 + this.GetAllowance() + WorkingDay * 30;
        }

        public override void AddStaff()
        {
            base.AddStaff();
            Console.Write("Department: ");
            Department = Console.ReadLine().Trim();
            Console.Write("Position (1=HEAD; 2=VICE HEAD; 3=STAFF): ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Position = "Head officer";
                        break;
                    }
                case 2:
                    {
                        Position = "Deputy officer";
                        break;
                    }
                case 3:
                    {
                        Position = "Officer";
                        break;
                    }
            }
            Console.Write("Number of working days: ");
            WorkingDay = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", FullName, Department, Position, SalaryRate, GetAllowance(), WorkingDay, GetSalary());
        }
    }
}
