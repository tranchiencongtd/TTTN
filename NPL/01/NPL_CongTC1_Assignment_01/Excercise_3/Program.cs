using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckPrimeNumber();
            Console.ReadKey();
        }

        private static void CheckPrimeNumber()
        {
            int n;
            do
            {
                Console.Write("Nhap n: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            if(n%2!=0)
            {
                Console.WriteLine($"{n} is prime number ");
            } else
            {
                Console.WriteLine($"{n} is NOT prime number ");
            }
        }
    }
}
