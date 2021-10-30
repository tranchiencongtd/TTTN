using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL_CongTC1_Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            float x, y;
            Console.WriteLine("Nhap x: ");
            x = float.Parse(Console.ReadLine());
            y = 2 * x * x * x - 6 * x * x + 2 * x - 1;
            Console.WriteLine($"x = {x}, y = {y} ");
        }
    }
}
