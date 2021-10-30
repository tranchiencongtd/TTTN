using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL_CongTC1_Asssignment_06
{
    class HourlyEmployee : Employee
    {
        public double Wage { get; set; }
        public double WorkingHour { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\nWage: {Wage} \t WorkingHour: {WorkingHour}\n");
        }
    }
}
