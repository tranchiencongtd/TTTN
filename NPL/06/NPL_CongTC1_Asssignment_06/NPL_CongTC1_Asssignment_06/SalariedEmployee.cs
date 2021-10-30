using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL_CongTC1_Asssignment_06
{
    class SalariedEmployee : Employee
    {
        public double CommissionRate { get; set; }
        public double GrossSales { get; set; }
        public double BasicSalary { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\nCommissionRate: {CommissionRate} \t GrossSales: {GrossSales} \t BasicSalary: {BasicSalary}\n");
        }
    }
}
