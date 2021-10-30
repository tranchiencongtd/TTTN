using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFibonacci();
        }

        static int fibonacci(int n)
        {
            int f0 = 0;
            int f1 = 1;
            int fn = 1;
            int i;

            if (n < 0)
            {
                return -1;
            }
            else if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                for (i = 2; i < n; i++)
                {
                    f0 = f1;
                    f1 = fn;
                    fn = f0 + f1;
                }
            }
            return fn;
        }

        private static void PrintFibonacci()
        {
            int n;
            Console.Write("Nhap n: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(fibonacci(i));
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
